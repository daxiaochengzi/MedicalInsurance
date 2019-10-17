using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalInsurance.Domain.Models.Dto;
using MedicalInsurance.Domain.Models.Params.UI;
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiJsonResultData GetDataQuery([FromQuery] TableIni param)
        {
            return new ApiJsonResultData().RunWithTry(y =>
            {
                
              var data=new List<SaleOrderDto>();
                data.Add(new SaleOrderDto()
                {   Id = 1,
                    OrderNo=1,
                    ProductNo = "1",
                    CreateDateTime = "2016-01-19 10:47:00.000",
                    CustAddress = "成都",
                    CustCompany = "成都有限公司",
                    CustName = "橙子",
                    CustPhone = "123343434",
                    UpdateDateTime = "2016-01-19 10:47:00.000"

                });
                data.Add(new SaleOrderDto()
                {
                    Id = 2,
                    OrderNo = 2,
                    ProductNo = "2",
                    CreateDateTime = "2016-01-19 10:47:00.000",
                    CustAddress = "成都",
                    CustCompany = "成都有限公司",
                    CustName = "橙子",
                    CustPhone = "123343434",
                    UpdateDateTime = "2016-01-19 10:47:00.000"

                });
                data.Add(new SaleOrderDto()
                {
                    Id = 3,
                    OrderNo = 3,
                    ProductNo = "3",
                    CreateDateTime = "2016-01-19 10:47:00.000",
                    CustAddress = "成都",
                    CustCompany = "成都有限公司",
                    CustName = "橙子",
                    CustPhone = "123343434",
                    UpdateDateTime = "2016-01-19 10:47:00.000"

                });
                data.Add(new SaleOrderDto()
                {
                    Id = 4,
                    OrderNo = 4,
                    ProductNo = "4",
                    CreateDateTime = "2016-01-19 10:47:00.000",
                    CustAddress = "成都",
                    CustCompany = "成都有限公司",
                    CustName = "橙子",
                    CustPhone = "123343434",
                    UpdateDateTime = "2016-01-19 10:47:00.000"

                });
                data.Add(new SaleOrderDto()
                {
                    Id = 5,
                    OrderNo = 5,
                    ProductNo = "5",
                    CreateDateTime = "2016-01-19 10:47:00.000",
                    CustAddress = "成都",
                    CustCompany = "成都有限公司",
                    CustName = "橙子",
                    CustPhone = "123343434",
                    UpdateDateTime = "2016-01-19 10:47:00.000"

                });
                //list = list.Skip(pageNum * pageSize).Take(pageSize).ToList();
                y.Rows = data.Skip(param.Offset>0? param.Offset-1:0 * param.Limit).Take(param.Limit).ToList();
                y.Total = data.Count;
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
