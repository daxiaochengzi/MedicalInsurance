using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{
   public class InpatientInfoDetailDto
    {
        public string 住院号 { get; set; }
        public string 费用明细ID { get; set; }
        public string 项目名称 { get; set; }
        public string 项目编码 { get; set; }
        public string 项目类别名称 { get; set; }
        public string 项目类别编码 { get; set; }
        public string 单位 { get; set; }
        public string 剂型 { get; set; }
        public string 规格 { get; set; }
        public string 单价 { get; set; }
        public string 数量 { get; set; }
        public string 金额 { get; set; }
        public string 用量 { get; set; }
        public string 用法 { get; set; }
        public string 用药天数 { get; set; }
        public string 医院计价单位 { get; set; }
        public string 是否进口药品 { get; set; }
        public string 药品产地 { get; set; }
        public string 处方号 { get; set; }
        public string 费用单据类型 { get; set; }
        public string 开单科室名称 { get; set; }
        public string 开单科室编码 { get; set; }
        public string 开单医生姓名 { get; set; }
        public string 开单医生编码 { get; set; }
        public string 开单时间 { get; set; }
        public string 执行科室名称 { get; set; }
        public string 执行科室编码 { get; set; }
        public string 执行医生姓名 { get; set; }
        public string 执行医生编码 { get; set; }
        public string 执行时间 { get; set; }
        public string 处方医师 { get; set; }
        public string 经办人 { get; set; }
        public string 执业医师证号 { get; set; }
        public string 费用冲销ID { get; set; }
        public string 机构编码 { get; set; }
        public string 机构名称 { get; set; }

    }
}
