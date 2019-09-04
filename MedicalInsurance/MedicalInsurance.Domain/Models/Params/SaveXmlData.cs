using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{
  public  class SaveXmlData
    {
        public string 验证码 { get; set; }
        public string 机构ID { get; set; }
        public string 业务ID { get; set; }
        public string 操作人员ID { get; set; }

        public string 发起交易的动作ID { get; set; }
        public string 入参 { get; set; }
        public string 出参 { get; set; }
        public string 医保返回业务号 { get; set; }
        public string 医保交易码 { get; set; }
        [JsonIgnore]
        public string DataId { get; set; }
    }
}
