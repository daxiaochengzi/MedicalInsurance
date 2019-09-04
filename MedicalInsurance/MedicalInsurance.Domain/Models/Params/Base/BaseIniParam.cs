using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params.Base
{
   public class BaseIniParam
    {
        /// <summary>
        /// 医保医院编号
        /// </summary>

        public string YbOrgCode { get; set; }
        /// <summary>
        /// 医院ID
        /// </summary>
        [Display(Name = "医院ID")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "医院ID输入过长，不能超过32位")]
        public string OrgID { get; set; }
        /// <summary>
        /// 门诊或住院业务ID
        /// </summary>
        [Display(Name = "门诊或住院业务ID")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "门诊或住院业务ID入过长，不能超过32位")]
        public string BID { get; set; }
        /// <summary>
        /// 操作人员ID
        /// </summary>
        [Display(Name = "操作人员ID")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "操作人员ID入过长，不能超过32位")]
        public string EmpID { get; set; }
        /// <summary>
        /// 医保交易码
        /// </summary>
        public string BsCode { get; set; }
        /// <summary>
        /// HIS调用医保交易动作产生的唯一ID
        /// </summary>
        [Display(Name = "HIS调用医保交易动作产生的唯一ID")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "HIS调用医保交易动作产生的唯一ID入过长，不能超过32位")]
        public string TransKey { get; set; }
    }
}
