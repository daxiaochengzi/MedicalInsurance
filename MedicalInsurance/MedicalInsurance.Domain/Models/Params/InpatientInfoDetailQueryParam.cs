using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params
{
   public class InpatientInfoDetailQueryParam
    {/// <summary>
    /// 明细id
    /// </summary>
        public List<string> IdList { get; set; } 
        /// <summary>
        /// 住院号
        /// </summary>
        public string HospitalizationNumber { get; set; }
    }
}
