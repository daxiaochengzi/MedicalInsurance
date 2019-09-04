using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{
   public class InformationParam
    {
        public  string 验证码 { get; set; }
        public  string 目录类型 { get; set; }
        public  string 目录名称 { get; set; }

        public  string 机构编码 { get; set; }
    }
}
