using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{
  public  class ICD10InfoDto
    {
        public string 疾病编码 { get; set; }
        public string 病种名称 { get; set; }
        public string 助记码 { get; set; }
        public string 备注 { get; set; }
        public string 创建时间 { get; set; }
        public string 疾病ID { get; set; }
    }
}
