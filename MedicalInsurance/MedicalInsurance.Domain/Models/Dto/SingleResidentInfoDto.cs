using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Dto
{
   public class SingleResidentInfoDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 特殊疾病编号
        /// </summary>
        public string SpecialDiseasesCode { get; set; }
        /// <summary>
        /// 收费项目编号
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// 收费项目名称
        /// </summary>
        public string Name { get; set; }


    }
}
