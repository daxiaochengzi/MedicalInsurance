using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{
   public class ICD10InfoParam
    {
        public string 验证码 { get; set; }
        public string 病种名称 { get; set; }
        public int 开始行数 { get; set; }
        public int 结束行数 { get; set; }
        public string 开始时间 { get; set; }
        public string 结束时间 { get; set; }
    }
}
