﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseConsoleClient.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Course", Namespace="http://schemas.datacontract.org/2004/07/CourseServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class Course : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CourseIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CourseNameField;
        
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
        public int CourseId {
            get {
                return this.CourseIdField;
            }
            set {
                if ((this.CourseIdField.Equals(value) != true)) {
                    this.CourseIdField = value;
                    this.RaisePropertyChanged("CourseId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CourseName {
            get {
                return this.CourseNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CourseNameField, value) != true)) {
                    this.CourseNameField = value;
                    this.RaisePropertyChanged("CourseName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICourses")]
    public interface ICourses {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourses/AddToCourse", ReplyAction="http://tempuri.org/ICourses/AddToCourseResponse")]
        void AddToCourse(CourseConsoleClient.ServiceReference1.Course course);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourses/AddToCourse", ReplyAction="http://tempuri.org/ICourses/AddToCourseResponse")]
        System.Threading.Tasks.Task AddToCourseAsync(CourseConsoleClient.ServiceReference1.Course course);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourses/ListCourse", ReplyAction="http://tempuri.org/ICourses/ListCourseResponse")]
        CourseConsoleClient.ServiceReference1.Course[] ListCourse();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICourses/ListCourse", ReplyAction="http://tempuri.org/ICourses/ListCourseResponse")]
        System.Threading.Tasks.Task<CourseConsoleClient.ServiceReference1.Course[]> ListCourseAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICoursesChannel : CourseConsoleClient.ServiceReference1.ICourses, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CoursesClient : System.ServiceModel.ClientBase<CourseConsoleClient.ServiceReference1.ICourses>, CourseConsoleClient.ServiceReference1.ICourses {
        
        public CoursesClient() {
        }
        
        public CoursesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CoursesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CoursesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CoursesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddToCourse(CourseConsoleClient.ServiceReference1.Course course) {
            base.Channel.AddToCourse(course);
        }
        
        public System.Threading.Tasks.Task AddToCourseAsync(CourseConsoleClient.ServiceReference1.Course course) {
            return base.Channel.AddToCourseAsync(course);
        }
        
        public CourseConsoleClient.ServiceReference1.Course[] ListCourse() {
            return base.Channel.ListCourse();
        }
        
        public System.Threading.Tasks.Task<CourseConsoleClient.ServiceReference1.Course[]> ListCourseAsync() {
            return base.Channel.ListCourseAsync();
        }
    }
}