using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{
   public class InformationDto
    {
        public string 目录编码 { get; set; }
        public string 目录名称 { get; set; }
        public string 助记码 { get; set; }
        public string 目录类别名称 { get; set; }
        public string 备注 { get; set; }
   
    }
}
