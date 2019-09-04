using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{
   public class MedicalInsuranceDataAllParam
    {/// <summary>
        /// ID
        /// </summary>
        public string DataAllId { get; set; }
        /// <summary>
        /// 输入
        /// </summary>
        public string ParticipationJson { get; set; }
        /// <summary>
        /// 返回结果值
        /// </summary>
        public string ResultDataJson { get; set; }
        /// <summary>
        /// 数据类型交易码
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 数据id
        /// </summary>
        public string DataId { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// (HIS调用医保交易动作产生的唯一ID)
        /// </summary>
        public string HisMedicalInsuranceId { get; set; }
        /// <summary>
        /// 创建人员编号
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
      
        public string IDCard { get; set; }

    }
}
