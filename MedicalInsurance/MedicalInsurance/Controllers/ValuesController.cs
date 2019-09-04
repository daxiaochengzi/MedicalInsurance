using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalInsurance.Helper;
using Microsoft.AspNetCore.Mvc;
using Quote.AspNetCore;

namespace MedicalInsurance.Controllers
{   /// <summary>
/// 
/// </summary>
    [Route("[controller]/[action]")]
  
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData GetJWTStr()
        {
            return new ApiJsonResultData().RunWithTry(y =>
            {
                var data = new TokenModel
                {
                    Uid = "260C8ACC-ECA6-44E7-9C02-32A6A35A7CFA", Project = "MedicalInsurance", Role = "User", TokenType = "web"
                };
                y.Data = JwtHelperb.IssueJWT(data);
            });
        }


        //// GET api/values
            //[HttpGet]
            //public ActionResult<IEnumerable<string>> Get()
            //{
            //    return new string[] { "value1", "value2" };
            //}

            //// GET api/values/5
            //[HttpGet("{id}")]
            //public ActionResult<string> Get(int id)
            //{
            //    return "value";
            //}

            //// POST api/values
            //[HttpPost]
            //public void Post([FromBody] string value)
            //{
            //}

            //// PUT api/values/5
            //[HttpPut("{id}")]
            //public void Put(int id, [FromBody] string value)
            //{
            //}

            //// DELETE api/values/5
            //[HttpDelete("{id}")]
            //public void Delete(int id)
            //{
            //}
        }



    //}

}
