using MedicalInsurance.Domain.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params.UI
{
   public class SingleResidentInfoDownloadUIParam
    {
        public string EmpID { get; set; }
        public List<SingleResidentInfoDto> DownloadData { get; set; }
    }
}
