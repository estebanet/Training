﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Leccion4_Utilizando_Bloqueos_WcfClienteSample.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/Leccion4_Utilizando_Bloqueos_WcfSample")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsActiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime SessionDateField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsActive {
            get {
                return this.IsActiveField;
            }
            set {
                if ((this.IsActiveField.Equals(value) != true)) {
                    this.IsActiveField = value;
                    this.RaisePropertyChanged("IsActive");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime SessionDate {
            get {
                return this.SessionDateField;
            }
            set {
                if ((this.SessionDateField.Equals(value) != true)) {
                    this.SessionDateField = value;
                    this.RaisePropertyChanged("SessionDate");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSession", ReplyAction="http://tempuri.org/IService1/GetSessionResponse")]
        Leccion4_Utilizando_Bloqueos_WcfClienteSample.ServiceReference1.CompositeType GetSession(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSession", ReplyAction="http://tempuri.org/IService1/GetSessionResponse")]
        System.Threading.Tasks.Task<Leccion4_Utilizando_Bloqueos_WcfClienteSample.ServiceReference1.CompositeType> GetSessionAsync(int UserId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Leccion4_Utilizando_Bloqueos_WcfClienteSample.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Leccion4_Utilizando_Bloqueos_WcfClienteSample.ServiceReference1.IService1>, Leccion4_Utilizando_Bloqueos_WcfClienteSample.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Leccion4_Utilizando_Bloqueos_WcfClienteSample.ServiceReference1.CompositeType GetSession(int UserId) {
            return base.Channel.GetSession(UserId);
        }
        
        public System.Threading.Tasks.Task<Leccion4_Utilizando_Bloqueos_WcfClienteSample.ServiceReference1.CompositeType> GetSessionAsync(int UserId) {
            return base.Channel.GetSessionAsync(UserId);
        }
    }
}