using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{
 public   class MedicalInsuranceResidentInfoDto
    {
        /// <summary>
        /// id
        /// </summary>
        public string DataAllId { get; set; }
        /// <summary>
        /// 内容json
        /// </summary>
        public string ContentJson { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// 数据id
        /// </summary>
        public string DataId { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
        public string BusinessId { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 创建人员
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public string DeleteTime { get; set; }
        /// <summary>
        /// 删除人员Id
        /// </summary>
        public string DeleteUserId { get; set; }
    }
}
