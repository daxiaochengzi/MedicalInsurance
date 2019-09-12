using BasicServiceReference;
using MedicalInsurance.Domain.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInsurance.WebService.Basic
{
    public class WebServiceBasic: IWebServiceBasic
    {
        /// <summary>
        /// 通用接口
        /// </summary>
        /// <param name="tradeCode"></param>
        /// <param name="inputParameter"></param>
        /// <param name=" operatorId"></param>
        /// <returns></returns>
        public async Task<BasicResultDto> HIS_InterfaceListAsync(string tradeCode, string inputParameter, string operatorId)

        {
            return await Task.Run(async () =>
            {
                //11008
                var result = new BasicResultDto();
                // 创建 HTTP 绑定对象与设置最大传输接受数量
                var binding = new BasicHttpBinding { MaxReceivedMessageSize = 2147483647 };
                // 根据 WebService 的 URL 构建终端点对象
                var endpoint = new EndpointAddress("http://47.111.29.88:11013/WebService.asmx");
                // 创建调用接口的工厂，注意这里泛型只能传入接口 添加服务引用时生成的 webservice的接口 一般是 (XXXSoap)
                var factory = new ChannelFactory<WebServiceSoap>(binding, endpoint);
                // 从工厂获取具体的调用实例 
                var callClient = factory.CreateChannel();
                //var paramIni = new ExecuteSPRequest(new ExecuteSPRequestBody() {param = param});
                string resultData = await callClient.HIS_InterfaceAsync(tradeCode, inputParameter);
                if (resultData != "" && resultData != null)
                {
                    var resultDto = JsonConvert.DeserializeObject<ResultDataDto>(resultData);
                 
                    if (resultDto.Result == "0")
                    {
                        throw new Exception("[" + operatorId + "]" + resultDto.Msg);
                    }
                    var basicResultDto = JsonConvert.DeserializeObject<BasicResultDto>(resultData);
                    result = basicResultDto;
                    return result;
                }

                //异步执行一些任务
                //return resultData.Body.ExecuteSPResult;
                //var account = JsonConvert.DeserializeObject<Account>(json);
                return result;
            });
        }
    }
}
