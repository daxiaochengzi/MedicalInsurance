using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dapper;
using MedicalInsurance.Domain.Models.Dto;
using MedicalInsurance.Domain.Models.Enums;
using MedicalInsurance.Domain.Models.Params;
using MedicalInsurance.Domain.Models.Params.UI;
using MedicalInsurance.Service.Interfaces;
using Newtonsoft.Json;

namespace MedicalInsurance.Service.Providers
{
    public class DataBaseHelpService : IDataBaseHelpService
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="conStr"></param> 
        public DataBaseHelpService(string conStr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(conStr) ? conStr : throw new ArgumentNullException(nameof(conStr));
            //_sqlConnection = new SqlConnection(_connectionString);
            //_sqlConnection.Open();
        }
        /// <summary>
        /// 更新医疗机构
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task ChangeOrg(UserInfoDto userInfo,List<OrgDto> param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {

                _sqlConnection.Open();
                if (param.Any())
                {
                    IDbTransaction transaction = _sqlConnection.BeginTransaction();
                    try
                    {
                        
                        string strSql = $"update [dbo].[医疗机构] set DeleteTime=GETDATE(),IsDelete=1,DeleteUserId='{userInfo.职员ID}'";
                    
                        if (param.Any())
                        {

                            await _sqlConnection.ExecuteAsync(strSql, null, transaction);
                         
                            string insterCount = null;
                            foreach (var itmes in param)
                            {
                                string insterSql = $@"
                                insert into [dbo].[医疗机构](id,医院名称,地址,联系电话,邮政编码,联系人,CreateTime,UpdateTime,IsDelete,DeleteTime,CreateUserId)
                                values('{itmes.Id}','{itmes.医院名称}','{itmes.地址}','{itmes.联系电话}','{itmes.邮政编码}','{itmes.联系人}',
                                    GETDATE(),GETDATE(),0,null,'{userInfo.职员ID}');";
                                insterCount += insterSql;
                            }
                            await _sqlConnection.ExecuteAsync(insterCount, null, transaction);
                            transaction.Commit();

                        }
                       
                    }
                    catch (Exception exception)
                    {

                        transaction.Rollback();
                        throw new Exception(exception.Message);

                    }
                }
                //var sqlData = await _sqlConnection.QueryAsync<string>("usp_webHealth_NJ_all", new { SPName = name, Params = strParams },
                //    commandType: CommandType.StoredProcedure);
                //string strSqlData = sqlData.FirstOrDefault();
                _sqlConnection.Close();


            }


        }
        /// <summary>
        /// 添加三大目录
        /// </summary>
        /// <param name="param"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task AddCatalog(UserInfoDto userInfo,List<CatalogDto> param, CatalogTypeEnum type)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                //排除已有项目

                _sqlConnection.Open();
                if (param.Any())
                {
                        var paramNew = new List<CatalogDto>();
                       //获取唯一编码
                        var catalogDtoIdList = param.Select(c => c.目录编码).ToList();
                        var ids = ListToStr(catalogDtoIdList);
                        string sqlstr = $"select 目录编码  from [dbo].[三大目录]  where 目录编码 in({ids})";
                        var idListNew = await _sqlConnection.QueryAsync<string>(sqlstr);
                    //排除已有项目
                         paramNew = idListNew.Any() == true ? param.Where(c => !idListNew.Contains(c.目录编码)).ToList() 
                                    : param;
                        string insterCount = null;
                        if (paramNew.Any())
                        {
                            foreach (var itmes in paramNew)
                            {
                                string insterSql = $@"
                                        insert into [dbo].[三大目录]([目录编码],[目录名称],[助记码],[目录类别编码],[目录类别名称],[单位],[规格],[剂型],
                                        [生产厂家名称],[备注],[创建时间],CreateTime,UpdateTime,IsDelete,DeleteTime,CreateUserId)
                                        values('{itmes.目录编码}','{itmes.目录名称}','{itmes.助记码}',{Convert.ToInt16(type)},'{itmes.目录类别名称}','{itmes.单位}','{itmes.规格}',
                                        '{itmes.剂型}', '{itmes.生产厂家名称}','{itmes.备注}', '{itmes.创建时间}',GETDATE(),GETDATE(),0,null,'{userInfo.职员ID}');";
                                        insterCount += insterSql;

                            }
                            await _sqlConnection.ExecuteAsync(insterCount);
                        }

                    

                }


                _sqlConnection.Close();


            }


        }
        /// <summary>
        /// 删除三大目录
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<int> DeleteCatalog(UserInfoDto user,
            int param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                string strSql = $"delete [dbo].[三大目录] where [目录类别编码]= {param}";
                var num = await _sqlConnection.ExecuteAsync(strSql);
                _sqlConnection.Close();
                return num;
            }
        }
        /// <summary>
        /// 获取三大项目最新时间
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public async Task<string> GetTime(int num)
        {
            string result = null;
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                string strSql = $"select MAX(创建时间) from [dbo].[三大目录] where IsDelete=0 and 目录类别编码={num} ";
                var timeMax = await _sqlConnection.QueryFirstAsync<string>(strSql);

                result = timeMax;
                _sqlConnection.Close();
            }

            return result;

        }
        /// <summary>
        /// ICD10获取最新时间
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetICD10Time()
        {
            string result = null;
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                string strSql = $"select MAX(创建时间) from [dbo].[RHisICD10] where IsDelete=0 ";
                var timeMax = await _sqlConnection.QueryFirstAsync<string>(strSql);

                result = timeMax;
                _sqlConnection.Close();
            }

            return result;

        }
        /// <summary>
        /// 添加ICD10
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task AddICD10(List<ICD10InfoDto> param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                //排除已有项目

                _sqlConnection.Open();
                if (param.Any())
                {
                    var paramNew = new List<ICD10InfoDto>();
                    //获取唯一编码
                    var catalogDtoIdList = param.Select(c => c.疾病ID).ToList();
                    var ids = ListToStr(catalogDtoIdList);
                    string sqlstr = $"select 目录编码  from [dbo].[三大目录]  where 目录编码 in({ids})";
                    var idListNew = await _sqlConnection.QueryAsync<string>(sqlstr);
                    //排除已有项目
                    paramNew = idListNew.Any() == true ? param.Where(c => !idListNew.Contains(c.疾病ID)).ToList()
                        : param;
                    string insterCount = null;
               
                    if (paramNew.Any())
                    {
                        foreach (var itmes in paramNew)
                        {
                        
                            string insterSql = $@"
                                        insert into [dbo].[RHisICD10]([疾病编码],[病种名称],[助记码],[备注],[创建时间],[疾病ID],
                                           CreateTime,UpdateTime,IsDelete,DeleteTime)
                                        values('{itmes.疾病编码}','{itmes.病种名称}','{itmes.助记码}','{itmes.备注}','{itmes.创建时间}','{itmes.疾病ID}',
                                          GETDATE(),GETDATE(),0,null);";
                          
                                insterCount += insterSql;
                        }
                        await _sqlConnection.ExecuteAsync(insterCount);
                    }



                }


                _sqlConnection.Close();


            }
        }
        /// <summary>
        /// 获取门诊病人信息
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task GetOutpatientPerson(UserInfoDto user,List<OutpatientInfoDto> param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {

                _sqlConnection.Open();
                if (param.Any())
                {
                    IDbTransaction transaction = _sqlConnection.BeginTransaction();
                    try
                    {
                        var ywId = ListToStr(param.Select(c => c.业务ID).ToList());
                        var outpatientNum = ListToStr(param.Select(c => c.门诊号).ToList());
                        string strSql =
                            $@"update [dbo].[门诊病人] set  [IsDelete] =1 ,DeleteTime=GETDATE(),DeleteUserId='{user.职员ID}' where [IsDelete]=0 and [业务ID] in(" +
                            ywId + ") and [门诊号] in(" + outpatientNum + ")";
                        var num = await _sqlConnection.ExecuteAsync(strSql, null, transaction);
                        string insertSql = "";
                        foreach (var item in param)
                        {
                            string str = $@"INSERT INTO [dbo].[门诊病人](
                                [姓名],[身份证号码],[性别],[业务ID],[门诊号],[就诊日期]
                               ,[科室],[科室编码],[诊断医生],[诊断疾病编码],[诊断疾病名称]
                               ,[主要病情描述],[经办人] ,[就诊总费用],[备注],[接诊状态]
                               ,[CreateTime],[UpdateTime],[IsDelete],[DeleteTime],OrgCode,CreateUserId)
                               VALUES('{item.姓名}','{item.身份证号码}','{item.性别}','{item.业务ID}','{item.门诊号}','{item.就诊日期}'
                                     ,'{item.科室}','{item.科室编码}','{item.诊断医生}','{item.诊断疾病编码}','{item.诊断疾病名称}'
                                     ,'{item.主要病情描述}','{item.经办人}','{item.就诊总费用}','{item.备注}','{item.接诊状态}'
                                     ,GETDATE(),GETDATE(),0,null,'{user.机构编码}','{user.职员ID}'
                                );";
                            insertSql += str;

                        }
                     
                        var nums = await _sqlConnection.ExecuteAsync(insertSql, null, transaction);
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {

                        transaction.Rollback();
                        throw new Exception(exception.Message);
                    }
                }

            }


        }
        /// <summary>
        /// 获取门诊病人明细
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task GetOutpatientDetailPerson(UserInfoDto user,List<OutpatientDetailDto> param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {

                _sqlConnection.Open();
                if (param.Any())
                {
                    IDbTransaction transaction = _sqlConnection.BeginTransaction();
                    try
                    {

                        var outpatientNum = ListToStr(param.Select(c => c.门诊号).ToList());
                        string strSql =
                            $@"update [dbo].[门诊费用] set  [IsDelete] =1 ,DeleteTime=GETDATE(),DeleteUserId='{user.职员ID}' where [IsDelete]=0 
                                and [门诊号] in(" + outpatientNum + ")";
                        var num = await _sqlConnection.ExecuteAsync(strSql, null, transaction);
                        string insertSql = "";
                        foreach (var item in param)
                        {
                            string str = $@"INSERT INTO [dbo].[门诊费用](
                               [门诊号] ,[费用明细ID] ,[项目名称],[项目编码] ,[项目类别名称] ,[项目类别编码]
                               ,[单位] ,[剂型] ,[规格] ,[单价],[数量],[金额] ,[用量] ,[用法] ,[用药天数]
		                       ,[医院计价单位] ,[是否进口药品] ,[药品产地] ,[处方号]  ,[费用单据类型] ,[开单科室名称]
			                   ,[开单科室编码] ,[开单医生姓名],[开单医生编码] ,[开单时间] ,[执行科室名称],[执行科室编码]
                               ,[执行医生姓名] ,[执行医生编码],[执行时间] ,[处方医师] ,[经办人],[执业医师证号]
                               ,[费用冲销ID],[机构编码],[机构名称] ,[CreateTime] ,[UpdateTime],[IsDelete],[DeleteTime],CreateUserId)
                           VALUES('{item.门诊号}','{item.费用明细ID}','{item.项目名称}','{item.项目编码}','{item.项目类别名称}','{item.项目类别编码}'
                                 ,'{item.单位}','{item.剂型}','{item.规格}',{item.单价},{item.数量},{item.金额},'{item.用量}','{item.用法}','{item.用药天数}',
                                 '{item.医院计价单位}','{item.是否进口药品}','{item.药品产地}','{item.处方号}','{item.费用单据类型}','{item.开单科室名称}'
                                 ,'{item.开单科室编码}','{item.开单医生姓名}','{item.开单医生编码}','{item.开单时间}','{item.执行科室名称}','{item.执行科室编码}'
                                 ,'{item.执行医生姓名}','{item.执行医生编码}','{item.执行时间}','{item.处方医师}','{item.经办人}','{item.执业医师证号}'
                                 ,'{item.费用冲销ID}','{item.机构编码}','{item.机构名称}',GETDATE(),GETDATE(),0,null,'{user.职员ID}'
                                 );";
                            insertSql += str;
                          


                        }
                        var nums = await _sqlConnection.ExecuteAsync(insertSql, null, transaction);
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        throw new Exception(exception.Message);
                    }
                }

            }
        }
        /// <summary>
        /// 保存住院病人明细
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task GetInpatientInfoDetailDto(UserInfoDto user, List<InpatientInfoDetailDto> param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {

                _sqlConnection.Open();
                if (param.Any())       
                {
                    IDbTransaction transaction = _sqlConnection.BeginTransaction();
                    try
                    {

                        var outpatientNum = ListToStr(param.Select(c => c.费用明细ID).ToList());
                        var paramFirst = param.FirstOrDefault();
                        string strSql =
                            $@"update  [dbo].[住院费用] set  [IsDelete] =1 ,DeleteTime=GETDATE(),DeleteUserId='{user.职员ID}' where [IsDelete]=0  and [住院号]={paramFirst.住院号}
                                 and [费用明细ID] in({outpatientNum})";
                        var num = await _sqlConnection.ExecuteAsync(strSql, null, transaction);
                        string insertSql = "";
                        int sort = 0;
                        foreach (var item in param)
                        {
                            sort++;
                            string str = $@"INSERT INTO [dbo].[住院费用](
                               [住院号] ,[费用明细ID] ,[项目名称],[项目编码] ,[项目类别名称] ,[项目类别编码]
                               ,[单位] ,[剂型] ,[规格] ,[单价],[数量],[金额] ,[用量] ,[用法] ,[用药天数]
		                       ,[医院计价单位] ,[是否进口药品] ,[药品产地] ,[处方号]  ,[费用单据类型] ,[开单科室名称]
			                   ,[开单科室编码] ,[开单医生姓名],[开单医生编码] ,[开单时间] ,[执行科室名称],[执行科室编码]
                               ,[执行医生姓名] ,[执行医生编码],[执行时间] ,[处方医师] ,[经办人],[执业医师证号]
                               ,[费用冲销ID],[机构编码],[机构名称] ,[CreateTime] ,[UpdateTime],[IsDelete],[DeleteTime],CreateUserId,Sort)
                           VALUES('{item.住院号}','{item.费用明细ID}','{item.项目名称}','{item.项目编码}','{item.项目类别名称}','{item.项目类别编码}'
                                 ,'{item.单位}','{item.剂型}','{item.规格}',{item.单价},{item.数量},{item.金额},'{item.用量}','{item.用法}','{item.用药天数}',
                                 '{item.医院计价单位}','{item.是否进口药品}','{item.药品产地}','{item.处方号}','{item.费用单据类型}','{item.开单科室名称}'
                                 ,'{item.开单科室编码}','{item.开单医生姓名}','{item.开单医生编码}','{item.开单时间}','{item.执行科室名称}','{item.执行科室编码}'
                                 ,'{item.执行医生姓名}','{item.执行医生编码}','{item.执行时间}','{item.处方医师}','{item.经办人}','{item.执业医师证号}'
                                 ,'{item.费用冲销ID}','{item.机构编码}','{item.机构名称}',GETDATE(),GETDATE(),0,null,'{user.职员ID}',{sort}
                                 );";
                            insertSql += str;
                        }
                        var nums = await _sqlConnection.ExecuteAsync(insertSql, null, transaction);
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {

                        transaction.Rollback();
                        throw new Exception(exception.Message);
                    }
                }

            }
        }

        public async Task<int> UpdateInpatientInfoDetail(UpdateInpatientInfoDetail param)
        {
            int count = 0;
                using (var _sqlConnection = new SqlConnection(_connectionString))
                {
                //update [dbo].[住院费用] set [DataState]=1,UpdateTime=GETDATE(),[UpdateUserId]= where [费用明细ID]='' and [机构编码]=''
                _sqlConnection.Open();
                    count= await _sqlConnection.ExecuteAsync("");
                    _sqlConnection.Close();
                }

            return count;
        }

        /// <summary>
        /// 获取住院病人
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task GetInpatientInfo(UserInfoDto user,List<InpatientInfoDto> param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {

                _sqlConnection.Open();
                if (param.Any())
                {
                    IDbTransaction transaction = _sqlConnection.BeginTransaction();
                    try
                    {

                        var outpatientNum = ListToStr(param.Select(c => c.住院号).ToList());
                        var businessId = ListToStr(param.Select(c => c.业务ID).ToList());
                        string strSql =
                            $@"update  [dbo].[住院病人] set  [IsDelete] =1 ,DeleteTime=GETDATE(),DeleteUserId='{user.职员ID}' where [IsDelete]=0  and [住院号] in ({outpatientNum})
                                 and [业务ID] in({businessId})";
                        var num = await _sqlConnection.ExecuteAsync(strSql, null, transaction);
                        string insertSql = "";
                        foreach (var item in param)
                        {
                            string str = $@"
                                INSERT INTO [dbo].[住院病人]
                                           ([医院名称] ,[入院日期]  ,[出院日期] ,[住院号] ,[业务ID] ,[姓名] ,[身份证号]
                                           ,[性别],[出生日期] ,[联系人姓名],[联系电话] ,[家庭地址] ,[入院科室] ,[入院科室编码]
                                           ,[入院诊断医生] ,[入院床位] ,[入院主诊断] ,[入院主诊断ICD10] ,[入院次诊断] ,[入院次诊断ICD10]
                                           ,[入院病区] ,[入院经办人] ,[入院经办时间] ,[住院总费用] ,[备注] ,[出院科室] ,[出院科室编码] 
		                                   ,[出院病区] ,[出院床位]  ,[出院主诊断] ,[出院主诊断ICD10] ,[出院次诊断] ,[出院次诊断ICD10]
                                           ,[在院状态] ,[入院诊断医生编码] ,[入院床位编码]  ,[入院病区编码],[出院床位编码] ,[出院病区编码]
                                           ,[CreateTime] ,[UpdateTime] ,[IsDelete] ,[DeleteTime],OrgCode,CreateUserId)
                                     VALUES ('{item.医院名称}','{item.入院日期}','{item.出院日期}','{item.住院号}','{item.业务ID}','{item.姓名}','{item.身份证号}',
                                             '{item.性别}','{item.出生日期}','{item.联系人姓名}','{item.联系电话}','{item.家庭地址}','{item.入院科室}','{item.入院科室编码}',
                                             '{item.入院诊断医生}','{item.入院床位}','{item.入院主诊断}','{item.入院主诊断ICD10}','{item.入院次诊断}','{item.入院次诊断ICD10}',
                                             '{item.入院病区}','{item.入院经办人}','{item.入院经办时间}','{item.住院总费用}','{item.备注}','{item.出院科室}','{item.出院科室编码}',
                                             '{item.出院病区}','{item.出院床位}','{item.出院主诊断}','{item.出院主诊断ICD10}','{item.出院次诊断}','{item.出院主诊断ICD10}',
                                             '{item.在院状态}','{item.入院诊断医生编码}','{item.入院床位编码}','{item.入院病区编码}','{item.出院床位编码}','{item.出院病区编码}',
                                               GETDATE(),GETDATE(),0,null,'{user.机构编码}','{user.职员ID}'
                                              );";
                            insertSql += str;
                        }
                        var nums = await _sqlConnection.ExecuteAsync(insertSql, null, transaction);
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {

                        transaction.Rollback();
                        throw new Exception(exception.Message);
                    }
                }

            }
        }

        /// <summary>
        /// 住院病人查询
        /// </summary>
        /// <returns></returns>
        public async Task<QueryInpatientInfoDto> QueryInpatientInfo(QueryInpatientInfoParam param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {

                _sqlConnection.Open();
                string strSql = $@"SELECT top 1 [Id]
                                  ,[医院名称]
                                  ,[入院日期]
                                  ,[出院日期]
                                  ,[住院号]
                                  ,[业务ID]
                                  ,[姓名]
                                  ,[身份证号]
                                  ,[性别]
                                  ,[出生日期]
                                  ,[联系人姓名]
                                  ,[联系电话]
                                  ,[家庭地址]
                                  ,[入院科室]
                                  ,[入院科室编码]
                                  ,[入院诊断医生]
                                  ,[入院床位]
                                  ,[入院主诊断]
                                  ,[入院主诊断ICD10]
                                  ,[入院次诊断]
                                  ,[入院次诊断ICD10]
                                  ,[入院病区]
                                  ,[入院经办人]
                                  ,[入院经办时间]
                                  ,[住院总费用]
                                  ,[备注]
                                  ,[出院科室]
                                  ,[出院科室编码]
                                  ,[出院病区]
                                  ,[出院床位]
                                  ,[出院主诊断]
                                  ,[出院主诊断ICD10]
                                  ,[出院次诊断]
                                  ,[出院次诊断ICD10]
                                  ,[在院状态]
                                  ,[入院诊断医生编码]
                                  ,[入院床位编码]
                                  ,[入院病区编码]
                                  ,[出院床位编码]
                                  ,[出院病区编码]

                               FROM [dbo].[住院病人] where IsDelete=0 and 业务ID='{param.BusinessId}' and   OrgCode='{param.InstitutionalNumber}'
                                   ";

                var data = await _sqlConnection.QueryFirstAsync<QueryInpatientInfoDto>(strSql);

                _sqlConnection.Close();
                return data;
            }
        }
        /// <summary>
        /// 医保信息查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<Int32> QueryMedicalInsurance(string param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                _sqlConnection.Open();
                string strSql = $"select  COUNT(*) from [dbo].[住院医保信息] where [业务ID]={param} and IsDelete=0";
                var counts = await _sqlConnection.ExecuteAsync(strSql);
                _sqlConnection.Close();
                return counts;

            }
        }
        /// <summary>
        /// 医保信息保存
        /// </summary>
        /// <param name="user"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task MedicalInsurance(UserInfoDto user, List<MedicalInsuranceDto> param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {

                _sqlConnection.Open();
                if (param.Any())
                {
                    string insertSql = "";
                    foreach (var item in param)
                    {
                        string str = $@"INSERT INTO [dbo].[住院医保信息]([住院Id],[业务ID],[医保卡号]
                               ,[医保总费用],[报账费用] ,[自付费用],[其他信息] 
		                       ,[CreateTime],[UpdateTime] ,[IsDelete] ,[DeleteTime],OrgCode,CreateUserId)
                           VALUES(
                                 {item.业务ID},{item.业务ID}, {item.医保卡号},{item.医保总费用},
                                 {item.报账费用},{item.自付费用}, {item.其他信息},
                                GETDATE(),GETDATE(),0,null,'{user.机构编码}','{user.职员ID}'
                                 );";
                        insertSql += str;

                    }
                    var nums = await _sqlConnection.ExecuteAsync(insertSql);
                }

            }
        }
        /// <summary>
        ///  医保反馈数据保存
        /// </summary>
        /// <param name="user"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task SaveMedicalInsuranceDataAll(MedicalInsuranceDataAllParam param)
        {


            using (var _sqlConnection = new SqlConnection(_connectionString))
            {

                _sqlConnection.Open();

                IDbTransaction transaction = _sqlConnection.BeginTransaction();
                try
                {
                    
                    string strSql =
                        $@"update MedicalInsuranceDataAll set DeleteTime=GETDATE(),DeleteUserId='{param.CreateUserId}' where  DeleteTime is  null and DataId='{param.DataId}' and BusinessId='{param.BusinessId}'";
                    var num = await _sqlConnection.ExecuteAsync(strSql, null, transaction);
                    string insertSql = $@"INSERT INTO [dbo].[MedicalInsuranceDataAll]
                   ([DataAllId]
                   ,[ParticipationJson]
                   ,[ResultDataJson]
                   ,[DataType]
                   ,[DataId]
                   ,[Remark]
                   ,[CreateUserId]
                   ,[CreateTime]
                   ,BusinessId
                   ,HisMedicalInsuranceId
                   ,OrgCode
                   ,IDCard
                    )
                VALUES ('{param.DataAllId}','{param.ParticipationJson}','{param.DataType}','{param.DataId}'
                        , '{param.Remark}','{param.CreateUserId}', GETDATE(),'{param.BusinessId}'
                        ,'{param.HisMedicalInsuranceId}','{param.OrgCode}','{param.IDCard}')";
                    var nums = await _sqlConnection.ExecuteAsync(insertSql, null, transaction);
                    transaction.Commit();
                }
                catch (Exception exception)
                {

                    transaction.Rollback();
                    throw new Exception(exception.Message);
                }

            }

        }
        /// <summary>
        ///  医保反馈数据查询
        /// </summary>
        /// <param name="user"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<MedicalInsuranceDataAllDto> SaveMedicalInsuranceDataAllQuery(MedicalInsuranceDataAllParamUIQueryParam param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                var resultData = new MedicalInsuranceDataAllDto();
                _sqlConnection.Open();
                string strSql = $@"
                SELECT [DataAllId]
                      ,[ParticipationJson]
                      ,[ResultDataJson]
                      ,[DataType]
                      ,[DataId]
                      ,[HisMedicalInsuranceId]
                      ,[BusinessId]
                      ,[Remark]
                      ,[CreateUserId]
                      ,[CreateTime]
                      ,[DeleteTime]
                      ,[OrgCode]
                      ,[DeleteUserId]
                  FROM [dbo].[MedicalInsuranceDataAll] where DataId='{param.DataId}' and  DataType='{param.DataType}' and OrgCode='{param.OrgCode}' and BusinessId='{param.BusinessId}' and  DeleteTime is  null";
                 var data = await _sqlConnection.QueryFirstOrDefaultAsync<MedicalInsuranceDataAllDto>(strSql);
                 return data ?? resultData;


            }

            
        }
        /// <summary>
        /// 业务ID
        /// </summary>
        /// <param name="user"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<Int32> DeleteMedicalInsurance(UserInfoDto user,string param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                int result = 0;
                _sqlConnection.Open();
                if (param.Any())
                {

                    string insertSql = $@"update [dbo].[住院医保信息] set IsDelete=1,DeleteTime=GETDATE(),DeleteUserId='{user.职员ID}' where  [业务ID]={param}";
                    result = await _sqlConnection.ExecuteAsync(insertSql);
                }
                return result;
            }
        }
        public async Task<Int32> InformationInfoSave(UserInfoDto user,List<InformationDto> param, InformationParam info)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                Int32 counts = 0;
                _sqlConnection.Open();
                if (param.Any())
                {
                    IDbTransaction transaction = _sqlConnection.BeginTransaction();
                    try
                    {

                        var outpatientNum = ListToStr(param.Select(c => c.目录编码).ToList());
                        string strSql =
                            $@"update [dbo].[基本信息] set  [IsDelete] =1 ,DeleteTime=GETDATE(),DeleteUserId='{user.职员ID}' where [IsDelete]=0 
                                and [目录编码] in(" + outpatientNum + ")";
                        await _sqlConnection.ExecuteAsync(strSql, null, transaction);
                        string insertSql = "";
                        int mund = 0;
                        foreach (var item in param)
                        {
                            mund++;
                            string str = $@"INSERT INTO [dbo].[基本信息]
                                   ([typeId] ,[orgCode],[目录编码],[目录名称]
                                   ,[助记码],[目录类别名称],[备注] ,[CreateTime]
		                           ,[UpdateTime] ,[IsDelete],[DeleteTime],CreateUserId)
                             VALUES ({info.目录类型},'{info.机构编码}','{item.目录编码}','{item.目录名称}',
                                     '{item.助记码}','{item.目录类别名称}','{item.备注}',GETDATE(),
                                        GETDATE(),0, null,'{user.职员ID}');";
                            insertSql += str;

                        }

                        counts = await _sqlConnection.ExecuteAsync(insertSql, null, transaction);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {

                        transaction.Rollback();
                        throw;
                    }
                    _sqlConnection.Close();
                }

                return counts;
            }
        }

        public async Task<Int32> PairCode(UserInfoDto user,List<PairCodeDto> param)
        {
            using (var _sqlConnection = new SqlConnection(_connectionString))
            {
                int result = 0;
                
                _sqlConnection.Open();
                if (param.Any())
                {
                    string insertSql =null;
                    foreach (var item in param)
                    {
                         insertSql += $@"INSERT INTO [dbo].[社保对码]
                           ([居民普通门诊报销标志],[居民普通门诊报销限价] ,[操作人员姓名] ,[版本],[状态]
                            [社保目录类别],[社保目录ID] ,[社保目录编码],[社保目录名称]
                           ,[拼音],[剂型],[规格],[单位],[生产厂家],[收费级别],[准字号]
                           ,[新码标志],[限制用药标志] ,[限制支付范围] ,[职工自付比例],[居民自付比例]
                           ,[备注],[CreateTime])
                          VALUES(  {Convert.ToInt16(item.CKE889)},{Convert.ToDecimal(item.CKA601)},'{user.职员ID}','y',{Convert.ToInt16(item.AAE100)}
                                  ,{Convert.ToInt16(item.AKA063)},'{DateTime.Now.ToString("yyyymmddhhmmssfff")}', '{item.AKE001}','{item.AKE002}'
                                  ,'{item.AKA020}','{item.AKA070}','{item.AKA074}','{item.AKA067}','{item.AKA098}','{item.AKA065}','{item.CKA603}'
                                  ,{Convert.ToInt16(item.CKE897)},{Convert.ToInt16(item.AKA036)},'{item.CKE599}','{item.AKA069}','{item.CKE899}',
                                  ,'{item.AAE013}',GETDATE()
                               )";
                    }

                    
                    result = await _sqlConnection.ExecuteAsync(insertSql);
                }
                return result;
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
