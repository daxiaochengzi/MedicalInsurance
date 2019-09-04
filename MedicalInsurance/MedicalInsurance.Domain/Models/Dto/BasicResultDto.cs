using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalInsurance.Domain.Models.Dto
{
    public class BasicResultDto
    {
        public string Result { get; set; }
        public List<dynamic> Msg { get; set; }

      
    }
}
