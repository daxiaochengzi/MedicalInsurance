using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{
   public class DeleteMedicalInsuranceParam
    {
        public string 验证码 { get; set; }
        public string 业务ID { get; set; }
        /// <summary>
        /// 是否检查本地数据库中是否有效
        /// </summary>
        public bool CheckLocal { get; set; }
    }
}
