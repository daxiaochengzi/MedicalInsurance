using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedicalInsurance.Domain.Models.Dto;
using MedicalInsurance.Domain.Models.Params;


namespace MedicalInsurance.Service.Interfaces
{
    public interface IDataBaseSqlServerService
    {
        /// <summary>
        /// 医保病人信息保存
        /// </summary>
        /// <param name="user"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<Int32> SaveMedicalInsuranceResidentInfo(MedicalInsuranceResidentInfoParam param);

        /// <summary>
        /// 医保病人信息查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<MedicalInsuranceResidentInfoDto> QueryMedicalInsuranceResidentInfo(
            QueryMedicalInsuranceResidentInfoParam param);

        /// <summary>
        ///  更新医保病人信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<int> UpdateMedicalInsuranceResidentInfo(
            UpdateMedicalInsuranceResidentInfoParam param);

        /// <summary>
        /// 住院病人明细查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<List<OutpatientDetailQuery>> InpatientInfoDetailQuery(InpatientInfoDetailQueryParam param);

        /// <summary>
        /// 单病种下载
        /// </summary>
        /// <param name="user"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<Int32> SingleResidentInfoDownload(UserInfoDto user, List<SingleResidentInfoDto> param);

    }
}
