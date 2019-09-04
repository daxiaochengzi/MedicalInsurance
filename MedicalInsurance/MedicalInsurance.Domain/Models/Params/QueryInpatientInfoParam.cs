using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{
  public  class QueryInpatientInfoParam
    {
        ////// <summary>
        // /// 住院号
        // /// </summary>
        //    /// </summary>
        //    [Display(Name = "住院号")]
        //    [Required(ErrorMessage = "{0}不能为空!!!")]
        //    [StringLength(32, ErrorMessage = "住院号输入过长，不能超过32位")]
        //    public string HospitalizationNumber { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>

        [Display(Name = "身份证")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(18, ErrorMessage = "身份证输入过长，不能超过18位")]
        public  string IdCard { get; set; }
        /// <summary>
        /// 机构编号
        /// </summary>
        [Display(Name = "机构编号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "机构编号输入过长，不能超过32位")]

        public  string InstitutionalNumber { get; set; }
        
    }
}
