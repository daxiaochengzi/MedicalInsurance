using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{
   public class MedicalInsuranceDto
    {
        public string 验证码 { get; set; }
        public string 业务ID { get; set; }
        public string 医保卡号 { get; set; }
        public decimal 医保总费用 { get; set; }
      
        public decimal 报账费用 { get; set; }

        public decimal 自付费用 { get; set; }

        public string 其他信息 { get; set; }
    }
}
