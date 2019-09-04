using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{
    /// <summary>
    /// 获取门诊病人明细
    /// </summary>
  public  class OutpatientDetailParam
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public string 验证码 { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string 业务ID { get; set; }
        /// <summary>
        /// 目录类型
        /// </summary>
        public string 门诊号 { get; set; }
    }
}
