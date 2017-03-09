﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.ServiceFabric.Services {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SR {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SR() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.ServiceFabric.Services.SR", typeof(SR).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Client is Not authorized to connect.
        /// </summary>
        internal static string Error_ConnectionDenied {
            get {
                return ResourceManager.GetString("Error_ConnectionDenied", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No endpoint found for the service &apos;{0}&apos; partition &apos;{1}&apos; that matches the specified TargetReplicaSelector : &apos;{2}&apos;.
        /// </summary>
        internal static string ErrorCommunicationTargetSelectorEndpointNotFound {
            get {
                return ResourceManager.GetString("ErrorCommunicationTargetSelectorEndpointNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value &apos;{0}&apos; of targetReplicaSelector argument is not a valid for a stateful service.
        /// </summary>
        internal static string ErrorCommunicationTargetSelectorInvalidStateful {
            get {
                return ResourceManager.GetString("ErrorCommunicationTargetSelectorInvalidStateful", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value &apos;{0}&apos; of targetReplicaSelector argument is not valid for a stateless service.
        /// </summary>
        internal static string ErrorCommunicationTargetSelectorInvalidStateless {
            get {
                return ResourceManager.GetString("ErrorCommunicationTargetSelectorInvalidStateless", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Config File was Not Found in this path {0}.
        /// </summary>
        internal static string ErrorConfigFileNotFound {
            get {
                return ResourceManager.GetString("ErrorConfigFileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ConfigPackageName {0} was not found..
        /// </summary>
        internal static string ErrorConfigPackageNotFound {
            get {
                return ResourceManager.GetString("ErrorConfigPackageNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Client is trying to connect to invalid address {0}..
        /// </summary>
        internal static string ErrorInvalidAddress {
            get {
                return ResourceManager.GetString("ErrorInvalidAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The EndpointAddress &apos;{0}&apos; for partition &apos;{1}&apos; is not in a format understood by the client.
        /// </summary>
        internal static string ErrorInvalidPartitionEndpointAddress {
            get {
                return ResourceManager.GetString("ErrorInvalidPartitionEndpointAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Listener with Name &apos;{0}&apos; already exists. When multiple communication listeners are used, a unique name should be specified for each listener..
        /// </summary>
        internal static string ErrorListenerAlreadyExists {
            get {
                return ResourceManager.GetString("ErrorListenerAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unique Name must be specified for each listener when multiple communication listeners are used.
        /// </summary>
        internal static string ErrorListenerNameNotSpecified {
            get {
                return ResourceManager.GetString("ErrorListenerNameNotSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NamedEndpoint &apos;{0}&apos; not found in the address &apos;{1}&apos; for partition &apos;{2}&apos;.
        /// </summary>
        internal static string ErrorPartitionNamedEndpointNotFound {
            get {
                return ResourceManager.GetString("ErrorPartitionNamedEndpointNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The primary or stateless instance for the partition &apos;{0}&apos; has invalid address, this means that right address from the replica/instance is not registered in the system..
        /// </summary>
        internal static string ErrorParttionInstanceInvalidAddress {
            get {
                return ResourceManager.GetString("ErrorParttionInstanceInvalidAddress", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SectionName {0} was Not Found in the Settings File.
        /// </summary>
        internal static string ErrorSectionNameNotFound {
            get {
                return ResourceManager.GetString("ErrorSectionNameNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Service &apos;{0}&apos; doesnot exist.
        /// </summary>
        internal static string ErrorServiceDoesNotExist {
            get {
                return ResourceManager.GetString("ErrorServiceDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Interface id {0} is not implemented by object {1}.
        /// </summary>
        internal static string ErrorServiceMethodDispatcher_InterfaceNotFound {
            get {
                return ResourceManager.GetString("ErrorServiceMethodDispatcher_InterfaceNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This can happen if message is dropped when service is busy or its long running operation and taking more time than configured Operation Timeout..
        /// </summary>
        internal static string ErrorServiceTooBusy {
            get {
                return ResourceManager.GetString("ErrorServiceTooBusy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RunAsync has been cancelled for a stateful service replica.  The cancellation will be considered &apos;slow&apos; if RunAsync does not halt execution within {6} milliseconds.  Application Type Name: {0}, Application Name: {1}, Service Type Name: {2}, Service Name: {3}, Partition Id: {4}, Replica Id: {5}.
        /// </summary>
        internal static string event_StatefulRunAsyncCancellation {
            get {
                return ResourceManager.GetString("event_StatefulRunAsyncCancellation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RunAsync has successfully completed for a stateful service replica.  Application Type Name: {0}, Application Name: {1}, Service Type Name: {2}, Service Name: {3}, Partition Id: {4}, Replica Id: {5}, WasCancelled: {6}.
        /// </summary>
        internal static string event_StatefulRunAsyncCompletion {
            get {
                return ResourceManager.GetString("event_StatefulRunAsyncCompletion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RunAsync has failed for a stateful service replica.  Application Type Name: {0}, Application Name: {1}, Service Type Name: {2}, Service Name: {3}, Partition Id: {4}, Replica Id: {5}, WasCancelled: {6}, Exception: {7}.
        /// </summary>
        internal static string event_StatefulRunAsyncFailure {
            get {
                return ResourceManager.GetString("event_StatefulRunAsyncFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RunAsync has been invoked for a stateful service replica.  Application Type Name: {0}, Application Name: {1}, Service Type Name: {2}, Service Name: {3}, Partition Id: {4}, Replica Id: {5}.
        /// </summary>
        internal static string event_StatefulRunAsyncInvocation {
            get {
                return ResourceManager.GetString("event_StatefulRunAsyncInvocation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RunAsync was slow to respect the cancellation token and halt execution for a stateful service replica.  Application Type Name: {0}, Application Name: {1}, Service Type Name: {2}, Service Name: {3}, Partition Id: {4}, Replica Id: {5}, Time to Cancel: {6} milliseconds, Slow Cancellation Timeout: {7} milliseconds.
        /// </summary>
        internal static string event_StatefulRunAsyncSlowCancellation {
            get {
                return ResourceManager.GetString("event_StatefulRunAsyncSlowCancellation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RunAsync has been cancelled for a stateless service instance.  The cancellation will be considered &apos;slow&apos; if RunAsync does not halt execution within {6} milliseconds.  Application Type Name: {0}, Application Name: {1}, Service Type Name: {2}, Service Name: {3}, Partition Id: {4}, Instance Id: {5}.
        /// </summary>
        internal static string event_StatelessRunAsyncCancellation {
            get {
                return ResourceManager.GetString("event_StatelessRunAsyncCancellation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RunAsync has successfully completed for a stateless service instance.  Application Type Name: {0}, Application Name: {1}, Service Type Name: {2}, Service Name: {3}, Partition Id: {4}, Instance Id: {5}, WasCancelled: {6}.
        /// </summary>
        internal static string event_StatelessRunAsyncCompletion {
            get {
                return ResourceManager.GetString("event_StatelessRunAsyncCompletion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RunAsync has failed for a stateless service instance.  Application Type Name: {0}, Application Name: {1}, Service Type Name: {2}, Service Name: {3}, Partition Id: {4}, Instance Id: {5}, WasCancelled: {6}, Exception: {7}.
        /// </summary>
        internal static string event_StatelessRunAsyncFailure {
            get {
                return ResourceManager.GetString("event_StatelessRunAsyncFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RunAsync has been invoked for a stateless service instance.  Application Type Name: {0}, Application Name: {1}, Service Type Name: {2}, Service Name: {3}, Partition Id: {4}, Instance Id: {5}.
        /// </summary>
        internal static string event_StatelessRunAsyncInvocation {
            get {
                return ResourceManager.GetString("event_StatelessRunAsyncInvocation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to RunAsync was slow to respect the cancellation token and halt execution for a stateless service instance.  Application Type Name: {0}, Application Name: {1}, Service Type Name: {2}, Service Name: {3}, Partition Id: {4}, Instance Id: {5}, Time to Cancel: {6} milliseconds, Slow Cancellation Timeout: {7} milliseconds.
        /// </summary>
        internal static string event_StatelessRunAsyncSlowCancellation {
            get {
                return ResourceManager.GetString("event_StatelessRunAsyncSlowCancellation", resourceCulture);
            }
        }
    }
}
