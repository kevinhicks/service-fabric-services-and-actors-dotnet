﻿// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------
namespace Microsoft.ServiceFabric.Actors.Runtime
{
    using System;
    using System.Collections.Generic;
    using System.Fabric;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Actors.Diagnostics;
    using Microsoft.ServiceFabric.Actors.Query;
    using Microsoft.ServiceFabric.Actors.Remoting.Runtime;
    using Microsoft.ServiceFabric.Services.Communication.Runtime;
    using Microsoft.ServiceFabric.Services.Runtime;

    /// <summary>
    /// Represents the base class for Microsoft Service Fabric based reliable actors service.
    /// </summary>
    /// <remarks>
    /// Derive from this class to implement your own custom actor service if you want to override
    /// any service level behavior for your actors.
    /// </remarks>
    public class ActorService : StatefulServiceBase, IActorService
    {
        private const string TraceType = "ActorService";
        private readonly ActorTypeInformation actorTypeInformation;
        private readonly IActorStateProvider stateProvider;
        private readonly ActorServiceSettings settings;
        private readonly IActorActivator actorActivator;
        private readonly ActorManagerAdapter actorManagerAdapter;
        private readonly Func<ActorBase, IActorStateProvider, IActorStateManager> stateManagerFactory;

        private ActorMethodDispatcherMap methodDispatcherMap;
        private ActorMethodFriendlyNameBuilder methodFriendlyNameBuilder;
        private ReplicaRole replicaRole;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActorService"/> class.
        /// </summary>
        /// <param name="context">Service context the actor service is operating under.</param>
        /// <param name="actorTypeInfo">The type information of the Actor.</param>
        /// <param name="actorFactory">The factory method to create Actor objects.</param>
        /// <param name="stateManagerFactory">The factory method to create <see cref="IActorStateManager"/></param>
        /// <param name="stateProvider">The state provider to store and access the state of the Actor objects.</param>
        /// <param name="settings">The settings used to configure the behavior of the Actor service.</param>
        public ActorService(
            StatefulServiceContext context,
            ActorTypeInformation actorTypeInfo,
            Func<ActorService, ActorId, ActorBase> actorFactory = null,
            Func<ActorBase, IActorStateProvider, IActorStateManager> stateManagerFactory = null,
            IActorStateProvider stateProvider = null,
            ActorServiceSettings settings = null)
            : base(
                context,
                stateProvider ?? ActorStateProviderHelper.CreateDefaultStateProvider(actorTypeInfo))
        {
            this.actorTypeInformation = actorTypeInfo;
            this.stateProvider = (IActorStateProvider) this.StateProviderReplica;
            this.settings = ActorServiceSettings.DeepCopyFromOrDefaultOnNull(settings);

            // Set internal components
            this.actorActivator = new ActorActivator(actorFactory ?? this.DefaultActorFactory);
            this.stateManagerFactory = stateManagerFactory ?? DefaultActorStateManagerFactory;
            this.actorManagerAdapter = new ActorManagerAdapter { ActorManager = new MockActorManager(this) };
            this.replicaRole = ReplicaRole.Unknown;
        }

        /// <summary>
        /// Gets ActorTypeInformation for actor service.
        /// </summary>
        /// <value>
        /// <see cref="Runtime.ActorTypeInformation"/>
        /// for the actor hosted by the service replica.
        /// </value>
        public ActorTypeInformation ActorTypeInformation
        {
            get { return this.actorTypeInformation; }
        }

        /// <summary>
        /// Gets a <see cref="IActorStateProvider"/> that represents the state provider for the actor service.
        /// </summary>
        /// <value>
        /// <see cref="IActorStateProvider"/>
        /// representing the state provider for the actor service.
        /// </value>
        public IActorStateProvider StateProvider
        {
            get { return this.stateProvider; }
        }

        /// <summary>
        /// Gets settings for the actor service. 
        /// </summary>
        /// <value>
        /// Settings for the actor service.
        /// </value>
        public ActorServiceSettings Settings
        {
            get { return this.settings; }
        }

        internal IActorActivator ActorActivator
        {
            get { return this.actorActivator; }
        }
        
        internal ActorMethodDispatcherMap MethodDispatcherMap
        {
            get { return this.methodDispatcherMap; }
        }

        internal ActorMethodFriendlyNameBuilder MethodFriendlyNameBuilder
        {
            get { return this.methodFriendlyNameBuilder; }
        }

        internal IActorManager ActorManager
        {
            get { return this.actorManagerAdapter.ActorManager; }
        }

        internal void InitializeInternal(ActorMethodDispatcherMap map, ActorMethodFriendlyNameBuilder methodNameBuilder)
        {
            this.methodDispatcherMap = map;
            this.methodFriendlyNameBuilder = methodNameBuilder;
        }

        #region IActorService Members        

        /// <summary>
        /// Deletes an Actor from the Actor service.
        /// </summary>
        /// <param name="actorId"><see cref="ActorId"/> of the actor to be deleted.</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns>A task that represents the asynchronous operation of call to server.</returns>
        /// <remarks>
        /// <para>An active actor, will be deactivated and its state will also be deleted from state provider.</para>
        /// <para>An in-active actor's state will be deleted from state provider.</para>
        /// <para>If this method is called for a non-existent actor id in the system, it will be a no-op.</para>
        /// </remarks>
        async Task IActorService.DeleteActorAsync(ActorId actorId, CancellationToken cancellationToken)
        {
            await this.ActorManager.DeleteActorAsync(
                Guid.NewGuid().ToString(),
                actorId,
                cancellationToken);
        }

        /// <summary>
        /// Gets the list of Actors by querying the actor service.
        /// </summary>
        /// <param name="continuationToken">A continuation token to start querying the results from.
        /// A null value of continuation token means start returning values form the beginning.</param>
        /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
        /// <returns>A task that represents the asynchronous operation of call to server.</returns>
        Task<PagedResult<ActorInformation>> IActorService.GetActorsAsync(
            ContinuationToken continuationToken,
            CancellationToken cancellationToken)
        {
            return this.ActorManager.GetActorsFromStateProvider(
                continuationToken,
                cancellationToken);
        }

        #endregion

        #region StatefulServiceBase Overrides

        /// <summary>
        /// Overrides <see cref="Microsoft.ServiceFabric.Services.Runtime.StatefulServiceBase.CreateServiceReplicaListeners()"/>.
        /// </summary>
        /// <returns>Endpoint string pairs like 
        /// {"Endpoints":{"Listener1":"Endpoint1","Listener2":"Endpoint2" ...}}</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new[]
            {
                new ServiceReplicaListener(this.CreateCommunicationListener)
            };
        }

        /// <summary>
        /// Overrides <see cref="StatefulServiceBase.RunAsync(CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation of loading reminders when the replica becomes primary.</returns>
        protected override Task RunAsync(CancellationToken cancellationToken)
        {
            return this.ActorManager.StartLoadingRemindersAsync(cancellationToken);
        }

        /// <summary>
        /// Overrides <see cref="StatefulServiceBase.OnChangeRoleAsync(ReplicaRole, CancellationToken)"/>.
        /// </summary>
        /// <param name="newRole">New role for the replica.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation performed when the replica becomes primary.</returns>
        protected override async Task OnChangeRoleAsync(ReplicaRole newRole, CancellationToken cancellationToken)
        {
            ActorTrace.Source.WriteInfoWithId(TraceType, this.Context.TraceId, "Begin change role. New role: {0}.", newRole);

            if (newRole == ReplicaRole.Primary)
            {
                this.actorManagerAdapter.ActorManager = new ActorManager(this);
                await this.actorManagerAdapter.OpenAsync(this.Partition, cancellationToken);
                this.ActorManager.DiagnosticsEventManager.ActorChangeRole(this.replicaRole, newRole);
            }
            else
            {
                if ((this.ActorManager != null) && (this.ActorManager.DiagnosticsEventManager != null))
                {
                    this.ActorManager.DiagnosticsEventManager.ActorChangeRole(this.replicaRole, newRole);
                }

                await this.actorManagerAdapter.CloseAsync(cancellationToken);
            }

            this.replicaRole = newRole;
            ActorTrace.Source.WriteInfoWithId(TraceType, this.Context.TraceId, "End change role. New role: {0}.", newRole);
        }

        /// <summary>
        /// Overrides <see cref="StatefulServiceBase.OnCloseAsync(CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation performed when the replica is closed.</returns>
        protected override async Task OnCloseAsync(CancellationToken cancellationToken)
        {
            ActorTrace.Source.WriteInfoWithId(TraceType, this.Context.TraceId, "Begin close.");

            await this.actorManagerAdapter.CloseAsync(cancellationToken);

            ActorTrace.Source.WriteInfoWithId(TraceType, this.Context.TraceId, "End close.");
        }

        /// <summary>
        /// Overrides <see cref="StatefulServiceBase.OnAbort()"/>.
        /// </summary>
        protected override void OnAbort()
        {
            ActorTrace.Source.WriteInfoWithId(TraceType, this.Context.TraceId, "Abort.");

            this.actorManagerAdapter.Abort();
        }

        #endregion

        #region Helper Functions
        
        private ICommunicationListener CreateCommunicationListener(StatefulServiceContext serviceContext)
        {
            return ActorServiceRemotingListener.CreateActorServiceRemotingListener(this);
        }

        private ActorBase DefaultActorFactory(ActorService actorService, ActorId actorId)
        {
            return (ActorBase)Activator.CreateInstance(
                this.ActorTypeInformation.ImplementationType,
                actorService,
                actorId);
        }

        private static IActorStateManager DefaultActorStateManagerFactory(ActorBase actorBase, IActorStateProvider actorStateProvider)
        {
            return new ActorStateManager(actorBase, actorStateProvider);
        }

        internal IActorStateManager CreateStateManager(ActorBase actor)
        {
            return this.stateManagerFactory.Invoke(actor, this.StateProvider);
        }

        #endregion
    }
}