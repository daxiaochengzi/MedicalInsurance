using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{
   public class MedicalInsuranceParam
    {
        public string 验证码 { get; set; }
        public string 业务ID { get; set; }
        public string 医保卡号 { get; set; }
        public string 医保总费用 { get; set; }
        public string 报账费用 { get; set; }
        public string 自付费用 { get; set; }
        public string 其他信息 { get; set; }

    }
}
