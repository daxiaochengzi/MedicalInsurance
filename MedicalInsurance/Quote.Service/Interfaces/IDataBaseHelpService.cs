using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedicalInsurance.Domain.Models.Dto;
using MedicalInsurance.Domain.Models.Enums;
using MedicalInsurance.Domain.Models.Params;
using MedicalInsurance.Domain.Models.Params.UI;

namespace MedicalInsurance.Service.Interfaces
{
    public interface IDataBaseHelpService
    {
        Task ChangeOrg(UserInfoDto userInfo,List<OrgDto> param);
        /// <summary>
        /// 获取三大目录更新时间
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        Task<string> GetTime(int num);
        /// <summary>
        /// 删除三大目录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
         Task<int> DeleteCatalog(UserInfoDto user,int param);
        
        /// <summary>
        /// 医保信息查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
         Task<Int32> QueryMedicalInsurance(string param);

        /// <summary>
        /// 删除医保信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<Int32> DeleteMedicalInsurance(UserInfoDto user,string param);
        /// <summary>
        /// 获取HIS系统中科室、医师、病区、床位的基本信息
        /// </summary>
        /// <param name="param"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        Task<Int32> InformationInfoSave(UserInfoDto user,List<InformationDto> param, InformationParam info);
        /// <summary>
        /// 获取门诊病人信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task GetOutpatientPerson(UserInfoDto user,List<OutpatientInfoDto> param);
        /// <summary>
        /// 获取门诊病人明细
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task GetOutpatientDetailPerson(UserInfoDto user,List<OutpatientDetailDto> param);
        /// <summary>
        /// 添加三大目录
        /// </summary>
        /// <param name="param"></param>
        /// <param name="type"></param>
        /// <returns></returns>

        Task AddCatalog(UserInfoDto user,List<CatalogDto> param, CatalogTypeEnum type);

        /// <summary>
        /// 保存住院病人明细
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task GetInpatientInfoDetailDto(UserInfoDto user,List<InpatientInfoDetailDto> param);

        /// <summary>
        /// ICD10Time 
        /// </summary>
        /// <returns></returns>
        Task<string> GetICD10Time();
        /// <summary>
        /// ICD10Time添加
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task AddICD10(List<ICD10InfoDto> param);
        /// <summary>
        /// 保存住院病人信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task GetInpatientInfo(UserInfoDto user,List<InpatientInfoDto> param);
        /// <summary>
        /// 医保反馈数据保存
        /// </summary>
        /// <param name="user"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task SaveMedicalInsuranceDataAll(MedicalInsuranceDataAllParam param);
        /// <summary>
        /// 住院病人查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>

        Task<QueryInpatientInfoDto> QueryInpatientInfo(QueryInpatientInfoParam param);
        /// <summary>
        /// 医保反馈数据查询保存
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<MedicalInsuranceDataAllDto> SaveMedicalInsuranceDataAllQuery(
            MedicalInsuranceDataAllParamUIQueryParam param);
        /// <summary>
        /// 下载医保项目 DownloadD
        /// </summary>
        /// <param name="user"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<Int32> PairCode(UserInfoDto user, List<PairCodeDto> param);

    }
}
