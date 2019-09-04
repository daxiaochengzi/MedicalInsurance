using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{
   public class OrgDto
    {
        public string Id { get; set; }
        public string 医院名称 { get; set; }
        public string 地址 { get; set; }
        public string 联系电话 { get; set; }
        public string 邮政编码 { get; set; }
        public string 联系人 { get; set; }
    }
}
