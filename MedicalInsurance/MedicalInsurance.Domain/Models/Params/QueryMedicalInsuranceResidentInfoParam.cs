using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{
  public  class QueryMedicalInsuranceResidentInfoParam
    {
        
        /// <summary>
        /// 数据id
        /// </summary>
        public string DataId { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public  string IdCard { get; set; }
    }
}
