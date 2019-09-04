//------------------------------------------------------------------------------
// <自动生成>
//     此代码由工具生成。
//     //
//     对此文件的更改可能导致不正确的行为，并在以下条件下丢失:
//     代码重新生成。
// </自动生成>
//------------------------------------------------------------------------------

namespace ServiceReference
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.HospitalServiceSoap")]
    public interface HospitalServiceSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ExecuteSP", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference.ExecuteSPResponse> ExecuteSPAsync(ServiceReference.ExecuteSPRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ExecuteSQL", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference.ExecuteSQLResponse> ExecuteSQLAsync(ServiceReference.ExecuteSQLRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ExecuteSPRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ExecuteSP", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.ExecuteSPRequestBody Body;
        
        public ExecuteSPRequest()
        {
        }
        
        public ExecuteSPRequest(ServiceReference.ExecuteSPRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ExecuteSPRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string param;
        
        public ExecuteSPRequestBody()
        {
        }
        
        public ExecuteSPRequestBody(string param)
        {
            this.param = param;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ExecuteSPResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ExecuteSPResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.ExecuteSPResponseBody Body;
        
        public ExecuteSPResponse()
        {
        }
        
        public ExecuteSPResponse(ServiceReference.ExecuteSPResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ExecuteSPResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ExecuteSPResult;
        
        public ExecuteSPResponseBody()
        {
        }
        
        public ExecuteSPResponseBody(string ExecuteSPResult)
        {
            this.ExecuteSPResult = ExecuteSPResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ExecuteSQLRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ExecuteSQL", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.ExecuteSQLRequestBody Body;
        
        public ExecuteSQLRequest()
        {
        }
        
        public ExecuteSQLRequest(ServiceReference.ExecuteSQLRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ExecuteSQLRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string param;
        
        public ExecuteSQLRequestBody()
        {
        }
        
        public ExecuteSQLRequestBody(string param)
        {
            this.param = param;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ExecuteSQLResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ExecuteSQLResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.ExecuteSQLResponseBody Body;
        
        public ExecuteSQLResponse()
        {
        }
        
        public ExecuteSQLResponse(ServiceReference.ExecuteSQLResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ExecuteSQLResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ExecuteSQLResult;
        
        public ExecuteSQLResponseBody()
        {
        }
        
        public ExecuteSQLResponseBody(string ExecuteSQLResult)
        {
            this.ExecuteSQLResult = ExecuteSQLResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface HospitalServiceSoapChannel : ServiceReference.HospitalServiceSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class HospitalServiceSoapClient : System.ServiceModel.ClientBase<ServiceReference.HospitalServiceSoap>, ServiceReference.HospitalServiceSoap
    {
        
    /// <summary>
    /// 实现此分部方法，配置服务终结点。
    /// </summary>
    /// <param name="serviceEndpoint">要配置的终结点</param>
    /// <param name="clientCredentials">客户端凭据</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public HospitalServiceSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(HospitalServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), HospitalServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public HospitalServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(HospitalServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public HospitalServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(HospitalServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public HospitalServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference.ExecuteSPResponse> ServiceReference.HospitalServiceSoap.ExecuteSPAsync(ServiceReference.ExecuteSPRequest request)
        {
            return base.Channel.ExecuteSPAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.ExecuteSPResponse> ExecuteSPAsync(string param)
        {
            ServiceReference.ExecuteSPRequest inValue = new ServiceReference.ExecuteSPRequest();
            inValue.Body = new ServiceReference.ExecuteSPRequestBody();
            inValue.Body.param = param;
            return ((ServiceReference.HospitalServiceSoap)(this)).ExecuteSPAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference.ExecuteSQLResponse> ServiceReference.HospitalServiceSoap.ExecuteSQLAsync(ServiceReference.ExecuteSQLRequest request)
        {
            return base.Channel.ExecuteSQLAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.ExecuteSQLResponse> ExecuteSQLAsync(string param)
        {
            ServiceReference.ExecuteSQLRequest inValue = new ServiceReference.ExecuteSQLRequest();
            inValue.Body = new ServiceReference.ExecuteSQLRequestBody();
            inValue.Body.param = param;
            return ((ServiceReference.HospitalServiceSoap)(this)).ExecuteSQLAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.HospitalServiceSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.HospitalServiceSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("找不到名称为“{0}”的终结点。", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.HospitalServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:89/HospitalService.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.HospitalServiceSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:89/HospitalService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("找不到名称为“{0}”的终结点。", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            HospitalServiceSoap,
            
            HospitalServiceSoap12,
        }
    }
}
