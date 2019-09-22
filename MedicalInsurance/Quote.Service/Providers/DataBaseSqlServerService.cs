using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MedicalInsurance.Domain.Models.Dto;
using MedicalInsurance.Domain.Models.Params;
using MedicalInsurance.Service.Interfaces;

namespace MedicalInsurance.Service.Providers
{
  public  class DataBaseSqlServerService: IDataBaseSqlServerService
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="conStr"></param> 
        public DataBaseSqlServerService(string conStr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(conStr) ? conStr : throw new ArgumentNullException(nameof(conStr));

        }
        /// <summary>
        /// 医保病人信息保存
        /// </summary>
        /// <param name="user"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<Int32> SaveMedicalInsuranceResidentInfo(
            MedicalInsuranceResidentInfoParam param)
        {
            Int32 counts = 0;
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                IDbTransaction transaction = _sqlConnection.BeginTransaction();
                try
                {
                    string insertSql =
                        $@"update [dbo].[MedicalInsuranceResidentInfo] set  [IsDelete] =1 ,DeleteTime=GETDATE(),DeleteUserId='{param.EmpID}' where [IsDelete]=0 
                                and BusinessId='{param.BusinessId}' and OrgCode='{param.OrgCode}' and DataId='{param.DataId}'";
                    await _sqlConnection.ExecuteAsync(insertSql, null, transaction);
                    string strSql = $@"
                    INSERT INTO [dbo].[MedicalInsuranceResidentInfo]
                               ([DataAllId]
                               ,[ContentJson]
                               ,[ResultData]
                               ,[DataType]
                               ,[DataId]
                               ,IsDelete
                               ,[BusinessId]
                               ,[IdCard]
                               ,[OrgCode]
                               ,[CreateUserId]
                               ,[CreateTime]
                             )
                         VALUES
                               ('{param.DataAllId}','{param.ContentJson}',,'{param.ResultDatajson}','{param.DataType}','{param.DataId}',0,
                                 '{param.BusinessId}','{param.IdCard}','{param.OrgCode}','{param.EmpID}',GETDATE())";
                    counts = await _sqlConnection.ExecuteAsync(strSql, null, transaction);
                  
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new Exception(e.Message) ;
                }

                _sqlConnection.Close();
            }

            return counts;
        }
        /// <summary>
        /// 医保病人信息查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<MedicalInsuranceResidentInfoDto> QueryMedicalInsuranceResidentInfo(
            QueryMedicalInsuranceResidentInfoParam param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                var resultData = new MedicalInsuranceResidentInfoDto();
                _sqlConnection.Open();
                string strSql = @" select   [DataAllId]
                      ,[ContentJson]
                      ,[DataType]
                      ,[DataId]
                      ,[BusinessId]
                      ,[IdCard]
                      ,[OrgCode]
                      ,[CreateUserId]
                      ,[CreateTime]
                      ,[DeleteTime]
                      ,[DeleteUserId] from [dbo].[MedicalInsuranceResidentInfo] where";

                strSql += $" IsDelete={param.IsDelete}";
                if (!string.IsNullOrWhiteSpace(param.DataId))
                    strSql += $" and DataId='{param.DataId}'";
                if (!string.IsNullOrWhiteSpace(param.BusinessId))
                    strSql += $" and BusinessId='{param.BusinessId}'";
                if (!string.IsNullOrWhiteSpace(param.OrgCode))
                    strSql += $" and OrgCode='{param.OrgCode}'";
                if (!string.IsNullOrWhiteSpace(param.IdCard))
                    strSql += $" and IdCard='{param.IdCard}'";
                var data = await _sqlConnection.QueryFirstOrDefaultAsync<MedicalInsuranceResidentInfoDto>(strSql);
                _sqlConnection.Close();
                return data != null ? data : resultData;
            }
        }
        /// <summary>
        ///  更新医保病人信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<int> UpdateMedicalInsuranceResidentInfo(
            UpdateMedicalInsuranceResidentInfoParam param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                var resultData = new MedicalInsuranceResidentInfoDto();
                _sqlConnection.Open();
                string strSql = @" update MedicalInsuranceResidentInfo set  ";
                  
                if (!string.IsNullOrWhiteSpace(param.DataType))
                    strSql += $" DataType='{param.DataType}'";
                if (!string.IsNullOrWhiteSpace(param.ContentJson))
                    strSql += $" ,ContentJson='{param.ContentJson}'";
                if (!string.IsNullOrWhiteSpace(param.ResultDatajson))
                    strSql += $" ,ResultDatajson='{param.ResultDatajson}'";
                if (!string.IsNullOrWhiteSpace(param.DataId))
                    strSql += $" ,DataId='{param.DataId}'";
                if (!string.IsNullOrWhiteSpace(param.IdCard))
                    strSql += $" ,DataId='{param.IdCard}'";
                strSql += $" where IsDelete=0 and DataAllId='{param.DataAllId}'"; 
                var data = await _sqlConnection.ExecuteAsync(strSql);
                _sqlConnection.Close();
                return data;
            }
        }
        /// <summary>
        /// 住院明细查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<List<OutpatientDetailQuery>> InpatientInfoDetailQuery(InpatientInfoDetailQueryParam param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                var resultData = new List<OutpatientDetailQuery>();
                _sqlConnection.Open();
                
                string strSql = @"SELECT [Id]
                                      ,[住院号]
                                      ,[费用明细ID]
                                      ,[项目名称]
                                      ,[项目编码]
                                      ,[项目类别名称]
                                      ,[项目类别编码]
                                      ,[单位]
                                      ,[剂型]
                                      ,[规格]
                                      ,[单价]
                                      ,[数量]
                                      ,[金额]
                                      ,[用量]
                                      ,[用法]
                                      ,[用药天数]
                                      ,[医院计价单位]
                                      ,[是否进口药品]
                                      ,[药品产地]
                                      ,[处方号]
                                      ,[费用单据类型]
                                      ,[开单科室名称]
                                      ,[开单科室编码]
                                      ,[开单医生姓名]
                                      ,[开单医生编码]
                                      ,[开单时间]
                                      ,[执行科室名称]
                                      ,[执行科室编码]
                                      ,[执行医生姓名]
                                      ,[执行医生编码]
                                      ,[执行时间]
                                      ,[处方医师]
                                      ,[经办人]
                                      ,[执业医师证号]
                                      ,[费用冲销ID]
                                      ,[机构编码]
                                      ,[机构名称]
                                      ,[费用时间]
                                      ,[CreateTime]
                                      ,[CreateUserId]
                              FROM [dbo].[住院费用] where ";
                if (param.IdList != null && param.IdList.Any())
                {
                    var idlist = ListToStr(param.IdList);
                       strSql += $@" 费用明细ID in('{idlist}')";
                }
                else
                {
                    strSql += $@" 住院号 ='{param.HospitalizationNumber}'";
                }
                var data = await _sqlConnection.QueryAsync<OutpatientDetailQuery>(strSql);
                _sqlConnection.Close();
                return data.Count() > 0 ? data.ToList() : resultData;
            }
        }
        /// <summary>
        /// 单病种下载
        /// </summary>
        /// <param name="user"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<Int32> SingleResidentInfoDownload(UserInfoDto user, List<SingleResidentInfoDto> param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                int result = 0;

                _sqlConnection.Open();
                if (param.Any())
                {
                    string insertSql = null;
                    foreach (var item in param)
                    {
                        insertSql += $@"
                                INSERT INTO [dbo].[SingleResidentInfo]
                                ([Id],[SpecialDiseasesCode],[Name],[ProjectCode] ,[CreateTime],[CreateUserId])
                                VALUES( '{item.Id}','{item.SpecialDiseasesCode}','{item.Name}','{item.ProjectCode}',GETDATE())";
                    }
                    result = await _sqlConnection.ExecuteAsync(insertSql);
                }
                return result;
            }
        }

       public async Task<SingleResidentInfoDto> SingleResidentInfoQuery(SingleResidentInfQueryUiParam param)
        {
        using (var _sqlConnection = new SqlConnection(_connectionString))

        {
            var resultData = new SingleResidentInfoDto();
            _sqlConnection.Open();
            string strSql = $@" select top 1
                       [Id],[SpecialDiseasesCode],[Name],[ProjectCode]
                       from [dbo].[SingleResidentInfo]
                       where IsDelete=0 and SpecialDiseasesCode='{param.SpecialDiseasesCode}'";
            var data = await _sqlConnection.QueryFirstOrDefaultAsync<SingleResidentInfoDto>(strSql);
            _sqlConnection.Close();
            return data != null ? data : resultData;
        }
}

private string ListToStr(List<string> param)
        {
            string result = null;
            if (param.Any())
            {
                foreach (var item in param)
                {
                    result = "'" + item + "'" + ",";
                }

            }
            return result?.Substring(0, result.Length - 1);
        }
    }
}
