using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedicalInsurance.Domain.Models.Dto;
using MedicalInsurance.Domain.Models.Params;

namespace MedicalInsurance.Service.Interfaces
{
   public interface IWebServiceBasicService
   {/// <summary>
   /// 获取验证码
   /// </summary>
   /// <param name="tradeCode"></param>
   /// <param name="inputParameter"></param>
   /// <returns></returns>
       Task<UserInfoDto> GetVerificationCode(string tradeCode, string inputParameter);
        /// <summary>
        /// 获取住院病人      GetCatalog(UserInfoDto user, CatalogParam param)
        /// </summary>
        /// <param name="infoParam"></param>
        /// <returns></returns>
        Task<List<InpatientInfoDto>> GetInpatientInfo(UserInfoDto user,string infoParam);
        /// <summary>
        /// 获取机构
        /// </summary>
        /// <param name="verCode"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Int32> GetOrg(UserInfoDto userinfo, string name);
        /// <summary>
        /// 获取三大目录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
       Task<string> GetCatalog(UserInfoDto user,CatalogParam param);
        /// <summary>
        /// 删除三大目录
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
       Task<string> DeleteCatalog(UserInfoDto user,int catalog);
        /// <summary>
        /// 获取门诊病人
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
       Task<List<OutpatientInfoDto>> GetOutpatientPerson(UserInfoDto user,OutpatientParam param);
        /// <summary>
        /// 获取门诊病人明细
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
       Task<List<OutpatientDetailDto>> GetOutpatientDetailPerson(UserInfoDto user,OutpatientDetailParam param);
       /// <summary>
       /// 获取住院病人明细
       /// </summary>
       /// <param name="param"></param>
       /// <returns></returns>
        Task<List<InpatientInfoDetailDto>> GetInpatientInfoDetail(UserInfoDto user,InpatientInfoDetailParam param);
       /// <summary>
       /// 医保信息保存
       /// </summary>
       /// <param name="param"></param>
       /// <returns></returns>
       Task MedicalInsuranceSave(UserInfoDto user,MedicalInsuranceParam param);
        /// <summary>
        /// 删除医保保存信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task DeleteMedicalInsurance(UserInfoDto user,DeleteMedicalInsuranceParam param);
        /// <summary>
        ///  获取HIS系统中科室、医师、病区、床位的基本信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<List<InformationDto>> GetInformation(UserInfoDto user,InformationParam param);
        /// <summary>
        /// 获取ICD10
        /// </summary>
        /// <param name="user"></param>
        /// <param name="CatalogParam"></param>
        /// <returns></returns>
       Task<string> GetICD10(UserInfoDto user, CatalogParam param);
       Task GetXmlData(XmlData param);
       Task SaveXmlData(SaveXmlData param);
       Task<QueryInpatientInfoDto> QueryInpatientInfo(QueryInpatientInfoParam param);
       Task<dynamic> TestFun(QueryInpatientInfoParam param);
   }
}
