using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MedicalInsurance.Domain.Models.Params.Base;

namespace MedicalInsurance.Domain.Models.Params.UI
{
  public  class MedicalInsuranceDataAllParamUIQueryParam: BaseIniParam
    {/// <summary>
     /// 机构编号
     /// </summary>
        [Display(Name = "机构编号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "医院ID输入过长，不能超过32位")]
        public  string OrgCode { get; set; }
        /// <summary>
        /// 数据id
        /// </summary>
        [Display(Name = "数据id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "数据id输入过长，不能超过32位")]
        public string DataId { get; set; }
        /// <summary>
        /// 业务id
        /// </summary>
         [Display(Name = "业务id")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "业务id输入过长，不能超过32位")]
      
        public string BusinessId { get; set; }
        /// <summary>
        /// 医保交易码
        /// </summary>
        [Display(Name = "医保交易码")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "医保交易码输入过长，不能超过32位")]
        public string DataType { get; set; }
    }
}
