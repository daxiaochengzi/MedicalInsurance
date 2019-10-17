using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params.UI
{/// <summary>
/// 表格查询初始化
/// </summary>
   public class TableIni
    {
        public string Order { get; set; }
        /// <summary>
        /// 页数
        /// </summary>
        public  int Offset { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int Limit { get; set; }
    }
}
