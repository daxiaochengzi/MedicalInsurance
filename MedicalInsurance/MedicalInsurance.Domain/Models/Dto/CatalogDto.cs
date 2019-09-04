using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{/// <summary>
/// 三大目录
/// </summary>
   public class CatalogDto
    {
        public string 目录编码 { get; set; }

        public string 目录名称 { get; set; }
        public string 助记码 { get; set; }
        public string 目录类别名称 { get; set; }
        public string 单位 { get; set; }
        public string 规格 { get; set; }
        public string 剂型 { get; set; }
        public string 生产厂家名称 { get; set; }
        public string 备注 { get; set; }
        public string 创建时间 { get; set; }
      
    }
}
