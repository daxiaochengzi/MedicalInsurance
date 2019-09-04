using System.ServiceModel;
using System.Threading.Tasks;
using ServiceReference;
namespace WebService
{
   public class MyWebService
    {
        public async Task<string> ExecuteSp(string param)
        {
            return await Task.Run(async () =>
            {


                // 创建 HTTP 绑定对象与设置最大传输接受数量
                var binding = new BasicHttpBinding {MaxReceivedMessageSize = 2147483647};
                // 根据 WebService 的 URL 构建终端点对象
                var endpoint = new EndpointAddress("http://localhost:845/HospitalService.asmx");
                // 创建调用接口的工厂，注意这里泛型只能传入接口 添加服务引用时生成的 webservice的接口 一般是 (XXXSoap)
                var factory = new ChannelFactory<HospitalServiceSoap>(binding, endpoint);
                // 从工厂获取具体的调用实例 
                var callClient = factory.CreateChannel();
                var paramIni = new ExecuteSPRequest(new ExecuteSPRequestBody(){param = param });
                var resultData =await callClient.ExecuteSPAsync(paramIni);
               
                                         //异步执行一些任务
                return resultData.Body.ExecuteSPResult;                          
            });


            //Task.Run(async (context) =>
            //{
            //    var client = new SayHelloClient();
            //    var response = await client.HelloAsync();
            //    await context.Response.WriteAsync(response);
            //});
        }
    }
}
