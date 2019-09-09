
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MedicalInsurance.Domain.Models.Dto
{
   public class InpatientInfoDetailParam
    {
        public string 验证码 { get; set; }
        public string 住院号 { get; set; }
        public string 业务ID { get; set; }
        public string 开始时间 { get; set; }
        public string 结束时间 { get; set; }
        public string 状态 { get; set; }
    }
}
