using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MedicalInsurance.Domain.Models.Params.Base;

namespace MedicalInsurance.Domain.Models.Params
{
   public class MedicalInsuranceResidentInfoParam: BaseIniParam
    {/// <summary>
     /// id
     /// </summary>
        [Display(Name = "id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "id输入过长，不能超过32位")]
        public string DataAllId { get; set; }
        /// <summary>
        /// 内容json
        /// </summary>
        [Display(Name = "内容json")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
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
        [Display(Name = "身份证")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdCard { get; set; }
        /// <summary>
        /// 组织机构
        /// </summary>
        [Display(Name = "组织机构")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string OrgCode { get; set; }
       
    }
}
