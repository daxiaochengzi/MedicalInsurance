using MedicalInsurance.Domain.Models.Params.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params.UI
{
  public  class SaveXmlDataUiParam:BaseIniParam
    {/// <summary>
        /// 入参
        /// </summary>
        [Display(Name = "入参")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(8000, ErrorMessage = "入参输入过长，不能超过8000位")]

        public string Participation { get; set; }
        /// <summary>
        /// 返回结果
        /// </summary>
        [Display(Name = "返回结果")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(8000, ErrorMessage = "返回结果输入过长，不能超过8000位")]
        public string ResultData { get; set; }
        /// <summary>
        /// 医保返回的业务号
        /// </summary>
        ///
        [Display(Name = "医保返回的业务号")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        [StringLength(32, ErrorMessage = "医保返回的业务号输入过长，不能超过32位")]
        public string BusinessNumber { get; set; }
    }
}
