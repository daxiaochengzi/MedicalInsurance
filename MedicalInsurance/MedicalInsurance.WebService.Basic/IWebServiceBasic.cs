using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedicalInsurance.Domain.Models.Dto;

namespace MedicalInsurance.WebService.Basic
{/// <summary>
/// 
/// </summary>
   public interface IWebServiceBasic
    {
        //Task <ResultDataDto> HIS_InterfaceAsync(string tradeCode, string inputParameter);
        Task<BasicResultDto> HIS_InterfaceListAsync(string tradeCode, string inputParameter, string operatorId);
    }
}
