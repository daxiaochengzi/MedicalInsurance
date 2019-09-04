using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{
   public class OutpatientInfoDto
    {
        public string 姓名 { get; set; }
        public string 身份证号码 { get; set; }
        public string 性别 { get; set; }
        public string 业务ID { get; set; }
        public string 门诊号 { get; set; }
        public string 就诊日期 { get; set; }
        public string 科室 { get; set; }
        public string 科室编码 { get; set; }
        public string 诊断医生 { get; set; }
        public string 诊断疾病编码 { get; set; }
        public string 诊断疾病名称 { get; set; }
        public string 主要病情描述 { get; set; }
        public string 经办人 { get; set; }
        public string 就诊总费用 { get; set; }
        public string 备注 { get; set; }
        public string 接诊状态 { get; set; }

    }
}
