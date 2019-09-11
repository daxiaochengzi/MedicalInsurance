using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalInsurance.Domain.Models.Dto;
using MedicalInsurance.Domain.Models.Enums;
using MedicalInsurance.Domain.Models.Params;
using MedicalInsurance.Service.Interfaces;
using MedicalInsurance.WebService.Basic;
using Newtonsoft.Json;

namespace MedicalInsurance.Service.Providers
{
    public class WebServiceBasicService : IWebServiceBasicService
    {
        private IDataBaseHelpService _dataBaseHelpService;
        private IWebServiceBasic _webServiceBasic;
        public WebServiceBasicService(IWebServiceBasic iWebServiceBasic, IDataBaseHelpService dataBase)
        {
            _webServiceBasic = iWebServiceBasic;
            _dataBaseHelpService = dataBase;
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="tradeCode"></param>
        /// <param name="inputParameter"></param>
        /// <returns></returns>
        public async Task<UserInfoDto> GetVerificationCode(string tradeCode, string inputParameter)
        {
          
            var ini =new UserInfoDto();
            List<UserInfoDto> resultList;
            var data = await _webServiceBasic.HIS_InterfaceListAsync(tradeCode, inputParameter,"");
            resultList = GetResultData(ini, data);
            return resultList.FirstOrDefault();
        }
        /// <summary>
        /// 获取医疗机构
        /// </summary>
        /// <param name="verCode">验证码</param>
        /// <param name="name">医院名称</param>
        /// <returns></returns>
        public async Task<Int32> GetOrg(UserInfoDto userInfo, string name)
        {
            Int32 resultData = 0;
            List<OrgDto> result;
            var init = new OrgDto();
            var info = new { 验证码 = userInfo.验证码, 医院名称 = name };
            var data =await _webServiceBasic.HIS_InterfaceListAsync("30", JsonConvert.SerializeObject(info), userInfo.职员ID);
            result = GetResultData(init, data);
            if (result.Any())
            {
                await _dataBaseHelpService.ChangeOrg(userInfo,result);
                resultData = result.Count;
            }
            return resultData;
        }
        /// <summary>
        /// 3.4 获取三大目录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<string> GetCatalog(UserInfoDto user, CatalogParam param)
        {
           
            var time = await _dataBaseHelpService.GetTime(Convert.ToInt16(param.CatalogType));
            var timeNew=Convert.ToDateTime(time).ToString("yyyy-MM-dd HH:ss:mm") ?? DateTime.Now.AddYears(-40).ToString("yyyy-MM-dd HH:ss:mm");
            var oCatalogInfo = new CatalogInfoDto
            {
                目录类型 = Convert.ToInt16(param.CatalogType).ToString(),
                目录名称 = "",
                开始时间 = timeNew,
                结束时间 = DateTime.Now.ToString("yyyy-MM-dd HH:ss:mm"),
                验证码 = param.验证码,
                机构编码= param.机构编码,
            };
            var data = await _webServiceBasic.HIS_InterfaceListAsync("06", JsonConvert.SerializeObject(oCatalogInfo), user.职员ID);
            List<ListCount> nums;
            var init = new ListCount();
            nums = GetResultData(init, data);
            var cnt = Convert.ToInt32(nums?.FirstOrDefault()?.行数);
           var resultCatalogDtoList=new List<CatalogDto>();
            var i = 0;
            while (i < cnt)
            {
                oCatalogInfo.开始行数 = i;
                oCatalogInfo.结束行数 = i + param.条数;
                var catalogDtoData =await _webServiceBasic.HIS_InterfaceListAsync("05", JsonConvert.SerializeObject(oCatalogInfo), user.职员ID);
                List<CatalogDto> resultCatalogDto;
                var initCatalogDto = new CatalogDto();
                resultCatalogDto = GetResultData(initCatalogDto, catalogDtoData);
                if (resultCatalogDto.Any())
                {
                    resultCatalogDtoList.AddRange(resultCatalogDto);
                }
                await _dataBaseHelpService.AddCatalog(user,resultCatalogDto, param.CatalogType);
                i = i + param.条数;
            }
            return "下载【" + param.CatalogType + "】成功 共" + resultCatalogDtoList.Count() + "条记录";
        }
        /// <summary>
        /// 删除下载的三大目录
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        public async Task<string> DeleteCatalog(UserInfoDto user, int catalog)   
        {
          var num=  await  _dataBaseHelpService.DeleteCatalog(user,catalog);
            return "删除【" + (CatalogTypeEnum)catalog + "】 成功 " + num + "条";
        }
        /// <summary>
        /// 获取ICD-10
        /// </summary>
        /// <param name="verCode"></param>
        /// <param name="code"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public async Task<string> GetICD10(UserInfoDto user, CatalogParam param)
        {
            var time = await _dataBaseHelpService.GetICD10Time();
            var timeNew =Convert.ToDateTime(time).ToString("yyyy-MM-dd HH:ss:mm")  ?? DateTime.Now.AddYears(-40).ToString("yyyy-MM-dd HH:ss:mm");
            var oICD10Info = new ICD10InfoParam
            {
                开始时间 = timeNew,
                结束时间 = DateTime.Now.ToString("yyyy-MM-dd HH:ss:mm"),
                验证码 = param.验证码,
                病种名称 = ""
            };
            var data =await _webServiceBasic.HIS_InterfaceListAsync("08", Newtonsoft.Json.JsonConvert.SerializeObject(oICD10Info), user.职员ID);
            List<ListCount> nums;
            var init = new ListCount();
            nums = GetResultData(init, data);
            var cnt = Convert.ToInt32(nums?.FirstOrDefault()?.行数);
            var resultCatalogDtoList = new List<ICD10InfoDto>();
            var i = 0;
            while (i < cnt)
            {
                oICD10Info.开始行数 = i;
                oICD10Info.结束行数 = i + param.条数;
                var catalogDtoData = await _webServiceBasic.HIS_InterfaceListAsync("07", JsonConvert.SerializeObject(oICD10Info), user.职员ID);
                List<ICD10InfoDto> resultCatalogDto;
                var initCatalogDto = new ICD10InfoDto();
                resultCatalogDto = GetResultData(initCatalogDto, catalogDtoData);
                if (resultCatalogDto.Any())
                {
                    resultCatalogDtoList.AddRange(resultCatalogDto);
                    await _dataBaseHelpService.AddICD10(resultCatalogDto);
                    i = i + param.条数;
                }
            }
            return "下载【ICD10】成功 共" + resultCatalogDtoList.Count() + "条记录";
        }
        /// <summary>
        /// 获取门诊病人
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<OutpatientInfoDto>> GetOutpatientPerson(UserInfoDto user,OutpatientParam param)
        {
            List<OutpatientInfoDto> result;
            var init = new OutpatientInfoDto();
            var data = await _webServiceBasic.HIS_InterfaceListAsync("12", JsonConvert.SerializeObject(param), user.职员ID);
            result = GetResultData(init, data);
            if (result.Any())
            {
                await _dataBaseHelpService.GetOutpatientPerson(user,result);
            }

            return result;
        }
        /// <summary>
        /// 获取门诊病人费用明细
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<OutpatientDetailDto>> GetOutpatientDetailPerson(UserInfoDto user,OutpatientDetailParam param)
        {
            List<OutpatientDetailDto> result;
            var init = new OutpatientDetailDto();
            var data = await _webServiceBasic.HIS_InterfaceListAsync("16", JsonConvert.SerializeObject(param), user.职员ID);

            result = GetResultData(init, data);
        
            if (result.Any())
            {
                await _dataBaseHelpService.GetOutpatientDetailPerson(user,result);
            }
            return result;
        }
        /// <summary>
        /// 获取住院病人信息
        /// </summary>
        /// <param name="infoParam"></param>
        /// <returns></returns>
        public async Task<List<InpatientInfoDto>> GetInpatientInfo(UserInfoDto user,string infoParam)
        {
            List<InpatientInfoDto> result;
            var init = new InpatientInfoDto();
            var data = await _webServiceBasic.HIS_InterfaceListAsync("10", infoParam, user.职员ID);
            result = GetResultData(init, data);
            if (result.Any())
            {
               await _dataBaseHelpService.GetInpatientInfo(user,result);
            }

            return result;
        }
        public async Task<QueryInpatientInfoDto> QueryInpatientInfo(QueryInpatientInfoParam param)
        {
            var data = await _dataBaseHelpService.QueryInpatientInfo(param);
            return data;
        }
        /// <summary>
        /// 获取住院明细
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<InpatientInfoDetailDto>> GetInpatientInfoDetail(UserInfoDto user,InpatientInfoDetailParam param)
        {
            List<InpatientInfoDetailDto> result=null;
            var paranm =new paranmsss(){身份证ID = "511523198701122345",机构编码 = user.机构编码, 验证码 = user .验证码};
            var data = await _webServiceBasic.HIS_InterfaceListAsync("30-10", JsonConvert.SerializeObject(paranm), user.职员ID);

            //var init = new InpatientInfoDetailDto();
            //var data = await _webServiceBasic.HIS_InterfaceListAsync("14", JsonConvert.SerializeObject(param), user.职员ID);
            //result = GetResultData(init, data);

            //if (result.Any())
            //{
            //    await _dataBaseHelpService.GetInpatientInfoDetailDto(user,result);
            //    //var msg = "获取住院号【" + resultFirst.住院号 + "】，业务ID【" + param.业务ID + "】的时间段内的住院费用成功，共" + result.Count +
            //    //          "条记录";
            //}

            return result;
        }

        /// <summary>
        /// 医保信息保存
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task MedicalInsuranceSave(UserInfoDto user,MedicalInsuranceParam param)
        {
            var num = await _dataBaseHelpService.QueryMedicalInsurance(param.业务ID);
            if (num == 0)
            {
                throw new Exception("数据库中未找到相应的住院业务ID的医保信息！");
            }
            else
            {
                var oResult = await _webServiceBasic.HIS_InterfaceListAsync("37", "{'验证码':'" + param.验证码 + "','业务ID':'" + param.业务ID + "'}", user.职员ID);
                if (oResult.Result == "1")
                {
                   throw new  Exception("此业务ID已经报销过，在试图调用接口删除中心住院医保信息时异常。中心返回删除失败消息：" + oResult.Msg.FirstOrDefault()?.ToString() + "！");
                }
               var  count= await _dataBaseHelpService.DeleteMedicalInsurance(user,param.业务ID);
            }

            List<MedicalInsuranceDto> result;
            var init = new MedicalInsuranceDto();
            var data = await _webServiceBasic.HIS_InterfaceListAsync("36", JsonConvert.SerializeObject(param), user.职员ID);
            result = GetResultData(init, data);
            var resultFirst = result.FirstOrDefault();
            if (resultFirst != null)
            {
                //var msg = "获取住院号【" + resultFirst.住院号 + "】，业务ID【" + param.业务ID + "】的时间段内的住院费用成功，共" + result.Count +
                //          "条记录";
            }
        }
        /// <summary>
        /// 医保信息删除
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task DeleteMedicalInsurance(UserInfoDto user,DeleteMedicalInsuranceParam param)
        {
            if (param.CheckLocal)
            {

                var num = await _dataBaseHelpService.QueryMedicalInsurance(param.业务ID);
                if (num == 0)
                {
                    var msg = "数据库中未找到相应的住院业务ID的医保信息！";
                }
            }
            var resultData = await _webServiceBasic.HIS_InterfaceListAsync("37", "{'验证码':'" + param.验证码 + "','业务ID':'" + param.业务ID + "'}", user.职员ID);
            if (resultData.Result == "1")
            {
                var count = await _dataBaseHelpService.DeleteMedicalInsurance(user,param.业务ID);
            }
        }
        /// <summary>
        /// 获取HIS系统中科室、医师、病区、床位的基本信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<InformationDto>> GetInformation(UserInfoDto user,InformationParam param)
        {
            var resultData = await _webServiceBasic.HIS_InterfaceListAsync("03", JsonConvert.SerializeObject(param), user.职员ID);
           var result=new List<InformationDto>();
            var init = new InformationDto();
            if (resultData.Result == "1")
            {
                result = GetResultData(init, resultData);
                //保存基础信息
                await _dataBaseHelpService.InformationInfoSave(user,result, param);
            }

            return result;
        }
        /// <summary>
        /// 获取医保构建参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task GetXmlData(XmlData param)
        {

            var data = await _webServiceBasic.HIS_InterfaceListAsync("39", JsonConvert.SerializeObject(param), param.操作人员ID);

        }
        /// <summary>
        /// 获取医保构建参数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task SaveXmlData(SaveXmlData param)
        {

            var data = await _webServiceBasic.HIS_InterfaceListAsync("38", JsonConvert.SerializeObject(param), param.操作人员ID);
            if (data.Result == "1")
            {
                var saveParam = new MedicalInsuranceDataAllParam()
                {
                    DataAllId=Guid.NewGuid().ToString("N"),
                    BusinessId = param.业务ID,
                    CreateUserId = param.操作人员ID,
                    DataId = param.发起交易的动作ID,
                    DataType = param.医保交易码,
                    OrgCode = param.机构ID,
                    ParticipationJson = param.入参,
                    ResultDataJson = param.出参,
                    HisMedicalInsuranceId = param.发起交易的动作ID,
                    Remark= param.Remark,
                    IDCard= param.IDCard,

                };
                await _dataBaseHelpService.SaveMedicalInsuranceDataAll(saveParam);
            }

        
        }
        /// <summary>
        /// 测试函数
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<dynamic> TestFun(QueryInpatientInfoParam param)
        {
            var data = await _dataBaseHelpService.QueryInpatientInfo(param);
            return data;
        }

        /// <summary>
        /// 返回结果解析
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
        private List<T> GetResultData<T>(T t, BasicResultDto resultList)
        {   var result=new List<T>();
            if (resultList != null && resultList.Msg.Any())
            {
                foreach (var item in resultList.Msg)
                {
                    string strData = item.ToString();
                    var itemData = JsonConvert.DeserializeObject<T>(strData);
                    if (itemData != null)
                    {
                        result.Add(itemData);
                    }


                }
            }
            return result;
        }
    }
}
