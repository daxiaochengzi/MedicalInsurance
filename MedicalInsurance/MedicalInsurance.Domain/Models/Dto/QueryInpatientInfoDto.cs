using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{
  public  class QueryInpatientInfoDto
    {
        public string Id { get; set; }
        public string 医院名称 { get; set; }
        public string 入院日期 { get; set; }
        public string 出院日期 { get; set; }
        public string 住院号 { get; set; }
        public string 业务ID { get; set; }
        public string 姓名 { get; set; }
        public string 身份证号 { get; set; }
        public string 性别 { get; set; }
        public string 出生日期 { get; set; }
        public string 联系人姓名 { get; set; }
        public string 联系电话 { get; set; }
        public string 家庭地址 { get; set; }
        public string 入院科室 { get; set; }
        public string 入院科室编码 { get; set; }
        public string 入院诊断医生 { get; set; }
        public string 入院床位 { get; set; }
        public string 入院主诊断 { get; set; }
        public string 入院主诊断ICD10 { get; set; }
        public string 入院次诊断 { get; set; }
        public string 入院次诊断ICD10 { get; set; }
        public string 入院病区 { get; set; }
        public string 入院经办人 { get; set; }
        public string 入院经办时间 { get; set; }
        public string 住院总费用 { get; set; }
        public string 备注 { get; set; }
        public string 出院科室 { get; set; }
        public string 出院科室编码 { get; set; }
        public string 出院病区 { get; set; }
        public string 出院床位 { get; set; }
        public string 出院主诊断 { get; set; }
        public string 出院主诊断ICD10 { get; set; }
        public string 出院次诊断 { get; set; }
        public string 出院次诊断ICD10 { get; set; }
        /// <summary>
        /// 0在院无床、1在院有床、2出院未结算、3出院已结算、-1撤销入院
        /// </summary>
        public int 在院状态 { get; set; }
        public string 入院诊断医生编码 { get; set; }
        public string 入院床位编码 { get; set; }
        public string 入院病区编码 { get; set; }
        public string 出院床位编码 { get; set; }
        public string 出院病区编码 { get; set; }
    }
}
