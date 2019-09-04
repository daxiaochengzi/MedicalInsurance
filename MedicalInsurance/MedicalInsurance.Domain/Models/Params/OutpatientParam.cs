using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{/// <summary>
/// 获取门诊病人信息
/// </summary>
  public  class OutpatientParam
    {
        public string 验证码 { get; set; }
        public string 身份证号码 { get; set; }
        public string 机构编码 { get; set; }
        public string 开始时间 { get; set; }
        public string 结束时间 { get; set; }
    }
}
