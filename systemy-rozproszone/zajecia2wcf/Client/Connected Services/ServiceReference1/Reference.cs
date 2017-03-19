﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IExampleService")]
    public interface IExampleService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExampleService/GetValue", ReplyAction="http://tempuri.org/IExampleService/GetValueResponse")]
        double GetValue(int index);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExampleService/GetValue", ReplyAction="http://tempuri.org/IExampleService/GetValueResponse")]
        System.Threading.Tasks.Task<double> GetValueAsync(int index);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExampleService/GetPartialSum", ReplyAction="http://tempuri.org/IExampleService/GetPartialSumResponse")]
        double GetPartialSum(int start, int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExampleService/GetPartialSum", ReplyAction="http://tempuri.org/IExampleService/GetPartialSumResponse")]
        System.Threading.Tasks.Task<double> GetPartialSumAsync(int start, int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExampleService/InsertElement", ReplyAction="http://tempuri.org/IExampleService/InsertElementResponse")]
        void InsertElement(int index, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExampleService/InsertElement", ReplyAction="http://tempuri.org/IExampleService/InsertElementResponse")]
        System.Threading.Tasks.Task InsertElementAsync(int index, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExampleService/GetStats", ReplyAction="http://tempuri.org/IExampleService/GetStatsResponse")]
        zajecia2wcf.Statistics GetStats();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExampleService/GetStats", ReplyAction="http://tempuri.org/IExampleService/GetStatsResponse")]
        System.Threading.Tasks.Task<zajecia2wcf.Statistics> GetStatsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IExampleServiceChannel : Client.ServiceReference1.IExampleService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExampleServiceClient : System.ServiceModel.ClientBase<Client.ServiceReference1.IExampleService>, Client.ServiceReference1.IExampleService {
        
        public ExampleServiceClient() {
        }
        
        public ExampleServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ExampleServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExampleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExampleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double GetValue(int index) {
            return base.Channel.GetValue(index);
        }
        
        public System.Threading.Tasks.Task<double> GetValueAsync(int index) {
            return base.Channel.GetValueAsync(index);
        }
        
        public double GetPartialSum(int start, int count) {
            return base.Channel.GetPartialSum(start, count);
        }
        
        public System.Threading.Tasks.Task<double> GetPartialSumAsync(int start, int count) {
            return base.Channel.GetPartialSumAsync(start, count);
        }
        
        public void InsertElement(int index, double value) {
            base.Channel.InsertElement(index, value);
        }
        
        public System.Threading.Tasks.Task InsertElementAsync(int index, double value) {
            return base.Channel.InsertElementAsync(index, value);
        }
        
        public zajecia2wcf.Statistics GetStats() {
            return base.Channel.GetStats();
        }
        
        public System.Threading.Tasks.Task<zajecia2wcf.Statistics> GetStatsAsync() {
            return base.Channel.GetStatsAsync();
        }
    }
}
