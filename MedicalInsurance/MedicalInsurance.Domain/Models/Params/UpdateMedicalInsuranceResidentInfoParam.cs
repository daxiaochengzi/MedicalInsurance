using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{
   public class UpdateMedicalInsuranceResidentInfoParam
    {/// <summary>
     /// 数据类型
     /// </summary>
        [Display(Name = "数据类型")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string DataType { get; set; }
        public  string ContentJson { get; set; }
        public  string DataId { get; set; }
        public  string DataAllId { get; set; }

        public  string IdCard { get; set; }
    }
}
