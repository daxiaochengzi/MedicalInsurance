using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{
   public class UpdateInpatientInfoDetail
    {/// <summary>
    /// 业务明细Id
    /// </summary>
        public List<string> BusinessIdDetailList { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string OperationId { get; set; }
    }
}
