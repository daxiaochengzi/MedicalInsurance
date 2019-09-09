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
                               ('{param.DataAllId}','{param.ContentJson}','{param.DataType}','{param.DataId}',0,
                                 '{param.BusinessId}','{param.IdCard}','{param.OrgCode}','{param.EmpID}',GETDATE())";
                    counts = await _sqlConnection.ExecuteAsync(strSql, null, transaction);
                  
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
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
