using MedicalInsurance.Domain.Models.Params.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalInsurance.Domain.Models.Params.UI
{
  public  class GetInpatientInfoDetailUIParam: BaseIniParam
    {
        public  List<string> IdCardList { get; set; }

    }
}
