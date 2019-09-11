   using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalInsurance.Domain.Models.Dto;
using MedicalInsurance.Domain.Models.Enums;
using MedicalInsurance.Domain.Models.Params;
using MedicalInsurance.Domain.Models.Params.UI;
using MedicalInsurance.Helper;
using MedicalInsurance.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Quote.AspNetCore;
using WebService;

namespace MedicalInsurance.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    [Route("[controller]/[action]")]

    public class TestController : ControllerBase
    {
        /// <summary>
        /// 基层系统接口
        /// </summary>
        private IWebServiceBasicService _webServiceBasicService;
        private IDataBaseHelpService _dataBaseHelpService;
        private IDataBaseSqlServerService _dataBaseSqlServerService;
        /// <summary>
        ///  
        /// </summary>
        public TestController(IWebServiceBasicService webServiceBasicService, 
            IDataBaseHelpService idDataBaseHelpService, IDataBaseSqlServerService idDataBaseSqlServerService)
        {
            _webServiceBasicService = webServiceBasicService;
            _dataBaseHelpService = idDataBaseHelpService;
            _dataBaseSqlServerService = idDataBaseSqlServerService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData PageList()
        {
            return new ApiJsonResultData().RunWithTry(y =>
            {
                var tokenHeader = HttpContext.Request.Headers["Authorization"];
                tokenHeader = tokenHeader.ToString().Substring("Bearer ".Length).Trim();
                TokenModel tm = JwtHelperb.SerializeJWT(tokenHeader);
                y.Data = tm;
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> ExecuteSp([FromQuery] ExecuteSpParam param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                //MyWebService webService = new MyWebService();
                //var data = await webService.ExecuteSp(param.Params);
               
            });
        }
        /// <summary>
        /// 获取住院病人
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> GetInpatientInfo()
        {
            return await new ApiJsonResultData().RunWithTryAsync(async y =>
            {
                var verificationCode = await GetUserBaseInfo();
                if (verificationCode != null)
                {
                    var inputInpatientInfo = new InpatientInfoParam()
                    {
                        验证码 = verificationCode.验证码,
                        机构编码 = verificationCode.机构编码,
                        身份证号码 = "511523198701122345",
                        开始时间 = "2018-04-27 11:09:00",
                        结束时间 = "2020-04-27 11:09:00",
                        状态 = "0"
                    };
                    string inputInpatientInfoJson =
                        JsonConvert.SerializeObject(inputInpatientInfo, Formatting.Indented);

                    var inputInpatientInfoData = await _webServiceBasicService
                            .GetInpatientInfo(verificationCode, inputInpatientInfoJson);
                    if (inputInpatientInfoData.Any())
                    {
                        y.Data = inputInpatientInfoData;
                    }
                }



            });
        }
        /// <summary>
        /// 获取住院病人明细费用
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> GetInpatientInfoDetail()
        {
            return await new ApiJsonResultData().RunWithTryAsync(async y =>
            {
                var inpatientInList = new List<InpatientInfoDto>();
                var verificationCode = await GetUserBaseInfo();
                if (verificationCode != null)
                {
                    var inputInpatientInfo = new InpatientInfoParam()
                    {
                        验证码 = verificationCode.验证码,
                        机构编码 = verificationCode.机构编码,
                        身份证号码 = "511523198701122345",
                        开始时间 = "2019-04-27 11:09:00",
                        结束时间 = "2020-04-27 11:09:00",
                        状态 = "0"
                    };
                    string inputInpatientInfoJson =
                        JsonConvert.SerializeObject(inputInpatientInfo, Formatting.Indented);
                    inpatientInList = await _webServiceBasicService.GetInpatientInfo(verificationCode, inputInpatientInfoJson);
                }
                if (inpatientInList.Any())
                {
                    var inpatientIni = inpatientInList.FirstOrDefault();
                    var InpatientInfoDetail = new InpatientInfoDetailParam()
                    {
                        验证码 = verificationCode.验证码,
                        住院号 = inpatientIni.住院号,
                        业务ID = inpatientIni.业务ID,
                        开始时间 = inpatientIni.入院日期,
                        结束时间 = "2020-04-27 11:09:00",
                        状态 = "0"
                    };
                    var data = await _webServiceBasicService.GetInpatientInfoDetail(verificationCode, InpatientInfoDetail);
                    y.Data = data;

                }



                //if (inputInpatientInfoData.Any())
                //{
                //    y.Data = inputInpatientInfoData;
                //}




            });

        }
        /// <summary>
        /// 获取门诊病人
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> GetOutpatientPerson()
        {
            return await new ApiJsonResultData().RunWithTryAsync(async y =>
            {
                var verificationCode = await GetUserBaseInfo();
                if (verificationCode != null)
                {
                    var outPatient = new OutpatientParam()
                    {
                        验证码 = verificationCode.验证码,
                        机构编码 = verificationCode.机构编码,
                        身份证号码 = "511526199610225518",
                        开始时间 = "2019-04-27 11:09:00",
                        结束时间 = "2020-04-27 11:09:00",

                    };
                    var inputInpatientInfoData = await _webServiceBasicService.GetOutpatientPerson(verificationCode, outPatient);
                    if (inputInpatientInfoData.Any())
                    {
                        y.Data = inputInpatientInfoData;
                    }
                }

                //var data = await webService.ExecuteSp(param.Params);

            });
        }
        /// <summary>
        /// 获取门诊病人明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> GetOutpatientDetailPerson()
        {
            return await new ApiJsonResultData().RunWithTryAsync(async y =>
            {
                var verificationCode = await GetUserBaseInfo();
                if (verificationCode != null)
                {
                    var outPatient = new OutpatientParam()
                    {
                        验证码 = verificationCode.验证码,
                        机构编码 = verificationCode.机构编码,
                        身份证号码 = "511526199610225518",
                        开始时间 = "2019-04-27 11:09:00",
                        结束时间 = "2020-04-27 11:09:00",

                    };
                    var inputInpatientInfoData = await _webServiceBasicService.GetOutpatientPerson(verificationCode, outPatient);
                    if (inputInpatientInfoData.Any())
                    {
                        var inputInpatientInfoFirst = inputInpatientInfoData.FirstOrDefault();
                        var outpatientDetailParam = new OutpatientDetailParam()
                        {
                            验证码 = verificationCode.验证码,
                            门诊号 = inputInpatientInfoFirst.门诊号,
                            业务ID = inputInpatientInfoFirst.业务ID

                        };
                        var inputInpatientInfoDatas = await _webServiceBasicService.
                                GetOutpatientDetailPerson(verificationCode, outpatientDetailParam);
                        y.Data = inputInpatientInfoDatas;
                    }
                }

                //var data = await webService.ExecuteSp(param.Params);

            });
        }
        /// <summary>
        /// 获取HIS系统中科室、医师、病区、床位的基本信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> GetInformation()
        {
            return await new ApiJsonResultData().RunWithTryAsync(async y =>
            {
                var userBase = await GetUserBaseInfo();
                if (userBase != null)
                {
                    var inputInpatientInfo = new InformationParam()
                    {
                        验证码 = userBase.验证码,
                        机构编码 = userBase.机构编码,
                        目录类型 = "1"
                    };
                    //string inputInpatientInfoJson = JsonConvert.SerializeObject(inputInpatientInfo, Formatting.Indented);

                    var inputInpatientInfoData = await _webServiceBasicService.GetInformation(userBase, inputInpatientInfo);
                    if (inputInpatientInfoData.Any())
                    {
                        y.Data = inputInpatientInfoData;
                    }
                }

                //var data = await webService.ExecuteSp(param.Params);

            });
        }
        /// <summary>
        /// 获取三大目录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> GetCatalog([FromQuery] UiCatalogParam param)
        {
            return await new ApiJsonResultData().RunWithTryAsync(async y =>
            {
                var userBase = await GetUserBaseInfo();
                if (userBase != null)
                {
                    var inputInpatientInfo = new CatalogParam()
                    {
                        验证码 = userBase.验证码,
                        CatalogType = param.CatalogType,
                        机构编码 = userBase.机构编码,
                        条数 = 500,
                    };


                    var inputInpatientInfoData = await _webServiceBasicService.GetCatalog(userBase, inputInpatientInfo);
                    if (inputInpatientInfoData.Any())
                    {
                        y.Data = inputInpatientInfoData;
                    }
                }

                //var data = await webService.ExecuteSp(param.Params);

            });
        }
        /// <summary>
        /// 删除三大目录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> DeleteCatalog([FromQuery] UiCatalogParam param)
        {
            return await new ApiJsonResultData().RunWithTryAsync(async y =>
            {
                var userBase = await GetUserBaseInfo();
                var data = await _webServiceBasicService.DeleteCatalog(userBase, Convert.ToInt16(param.CatalogType));
                y.Data = data;


            });
        }
        /// <summary>
        /// 获取ICD10
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> GetIcd10()
        {
            return await new ApiJsonResultData().RunWithTryAsync(async y =>
            {
                var userBase = await GetUserBaseInfo();
                var data = await _webServiceBasicService.GetICD10(userBase, new CatalogParam()
                {
                    机构编码 = userBase.机构编码,
                    验证码 = userBase.验证码,
                    条数 = 500,
                    CatalogType = CatalogTypeEnum.中药
                });
                y.Data = data;


            });
        }
        /// <summary>
        /// 更新机构
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> GetOrg([FromQuery] OrgParam param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                var userBase = await GetUserBaseInfo();
                var data = await _webServiceBasicService.GetOrg(userBase, param.Name);
                y.Data = "更新机构" + data + "条";
            });
        }
        /// <summary>
        /// 构建医保xml数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> GetXmlData()
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                var userBase = await GetUserBaseInfo();
                var xmlData = new XmlData()
                {
                    验证码 = userBase.验证码,
                    机构ID = userBase.机构编码,
                    操作人员ID = "E075AC49FCE443778F897CF839F3B924",
                    医保交易码 = "21",
                    发起交易的动作ID = "",
                    业务ID = "C8102B5DD65B4AE6B1EDAED12E4E0D80"
                };
                await _webServiceBasicService.GetXmlData(xmlData);
                //y.Data = "更新机构" + data + "条";
            });
        }
        /// <summary>
        ///医保信息回写至基层系统
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> SaveXmlData([FromBody] SaveXmlDataUiParam param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                var userBase = await GetUserBaseInfo();
                var xmlData = new SaveXmlData()
                {
                    验证码 = userBase.验证码,
                    机构ID = param.OrgID,
                    医保交易码 = param.BsCode,
                    发起交易的动作ID = param.TransKey,
                    业务ID = param.BID,
                    医保返回业务号 = param.BusinessNumber,
                    入参 = param.Participation,
                    出参 = param.ResultData,
                    IDCard= param.IDCard,
                    Remark = param.Remark
                };
                await _webServiceBasicService.SaveXmlData(xmlData);
                y.Message = "医保信息回写成功";
            });
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserInfoDto> GetUserBaseInfos()
        {
            var userBase = await GetUserBaseInfo();
            return userBase;
        }
        /// <summary>
        /// 医保交易数据储存
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> SaveMedicalInsuranceDataAll([FromBody] MedicalInsuranceDataAllParam param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                var userBase = await GetUserBaseInfo();
                //var paramData=new MedicalInsuranceDataAllParam()
                //{ DataAllId = Guid.NewGuid().ToString("N").ToUpper(),
                //  ParticipationJson  = "123",
                //  ResultDataJson = "123",
                //  CreateCode = userBase.职员ID,
                //  DataType = 1,

                //};
                await _dataBaseHelpService.SaveMedicalInsuranceDataAll(param);
                //y.Data = "更新机构" + data + "条";
            });
        }
        /// <summary>
        /// 住院病人信息查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> QueryInpatientInfo([FromBody]QueryInpatientInfoParam param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                var data = await _webServiceBasicService.QueryInpatientInfo(param);

                if (string.IsNullOrWhiteSpace(data.Id))//如果当前无数据
                {
                    var verificationCode = await GetUserBaseInfo();
                    if (verificationCode != null)
                    {
                        var inputInpatientInfo = new InpatientInfoParam()
                        {
                            验证码 = verificationCode.验证码,
                            机构编码 = verificationCode.机构编码,
                            身份证号码 = param.IdCard,
                            开始时间 = DateTime.Now.AddYears(-4).ToString("yyyy-MM-dd HH:mm:ss"),
                            结束时间 = "2020-04-27 11:09:00",
                            状态 = "0"
                        };
                        string inputInpatientInfoJson =
                            JsonConvert.SerializeObject(inputInpatientInfo, Formatting.Indented);

                        var inputInpatientInfoData = await _webServiceBasicService
                            .GetInpatientInfo(verificationCode, inputInpatientInfoJson);

                    }
                    var dataNew = await _webServiceBasicService.QueryInpatientInfo(param);
                    y.Data = dataNew;
                }
                else
                {
                    y.Data = data;
                }
            });
        }
        /// <summary>
        /// 医保反馈数据查询保存
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> MedicalInsuranceDataAllQuery([FromBody] MedicalInsuranceDataAllParamUIQueryParam param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                //[FromBody] MedicalInsuranceDataAllParamUIQueryParam param
               var data = await _dataBaseHelpService.SaveMedicalInsuranceDataAllQuery(param);
                y.Data = data;

            });
        }
        /// <summary>
        /// 医保病人信息保存
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> SaveMedicalInsuranceResidentInfo([FromBody] MedicalInsuranceResidentInfoParam param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {

                var data = await _dataBaseSqlServerService.SaveMedicalInsuranceResidentInfo(param);
                y.Data = data;

            });
        }
        /// <summary>
        /// 医保病人信息查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> QueryMedicalInsuranceResidentInfo([FromBody] QueryMedicalInsuranceResidentInfoParam param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                var data = await _dataBaseSqlServerService.QueryMedicalInsuranceResidentInfo(param);
                y.Data = data;

            });
        }
        /// <summary>
        /// 更新医保病人信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> UpdateMedicalInsuranceResidentInfo([FromBody] UpdateMedicalInsuranceResidentInfoParam param)
        {
            return await new ApiJsonResultData(ModelState).RunWithTryAsync(async y =>
            {
                var data = await _dataBaseSqlServerService.UpdateMedicalInsuranceResidentInfo(param);
                y.Data = data;

            });
        }
        
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiJsonResultData> GetServiceTime()
        {
            return await new ApiJsonResultData().RunWithTryAsync(async y =>
            {// yyyyMMddHHmmss
                y.Data =new ServiceTimeDto(){DataTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss") };
                //var data = await webService.ExecuteSp(param.Params);

            });
        }
        /// <summary>
        /// 住院病人明细查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> InpatientInfoDetailQuery([FromBody] InpatientInfoDetailQueryParam param)
        {
            return await new ApiJsonResultData().RunWithTryAsync(async y =>
            {
                var data = await _dataBaseSqlServerService.InpatientInfoDetailQuery(param);
                y.Data = data;

            });
        }
        /// <summary>
        /// 医保项目下载
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiJsonResultData> PairCodeDownload([FromBody] PairCodeDownloadUiParam param)
        {
            return await new ApiJsonResultData().RunWithTryAsync(async y =>
            {
                if (param.DownloadData!=null && param.DownloadData.Any())
                {
                    var data = await _dataBaseHelpService.PairCode(new UserInfoDto() { 职员ID = param.EmpID }, param.DownloadData);
                    y.Data = data;
                }
            });
        }
        
        [NonAction]
        private async Task<UserInfoDto> GetUserBaseInfo()
        {
            var inputParam = new UserInfoParam()
            {
                用户名 = "liqian",
                密码 = "123",
                厂商编号 = "510303001",
            };
            string inputParamJson = JsonConvert.SerializeObject(inputParam, Formatting.Indented);
            var verificationCode = await _webServiceBasicService.GetVerificationCode("01", inputParamJson);
            return verificationCode;
        }
    }
}