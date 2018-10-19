using Dapper;
using layUiAdmin.Common.Result;
using layUiAdmin.SQL.Entities;
using layUiAdmin.SQL.IRepository;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace layUiAdmin.SQL.Repository
{
    public class LayuiDataRepository : RepositoryBase<LayuiData>, ILayuiDataRepository
    {
        public async Task DeleteUser(int Id)
        {
            string deleteSql = "DELETE FROM Users WHERE Id=@Id";
            await Delete(Id, deleteSql);
        }

        public string ExecExecQueryParamSP(string spName, string name, int Id)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", name, DbType.String, ParameterDirection.Output, 100);
                parameters.Add("@Id", Id, DbType.String, ParameterDirection.Input);
                conn.Execute(spName, parameters, null, null, CommandType.StoredProcedure);
                string strUserName = parameters.Get<string>("@UserName");
                return strUserName;
            }
        }

        public async Task<LayuiData> GetUserDetail(int Id)
        {
            string detailSql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM Users WHERE Id=@Id";
            return await Detail(Id, detailSql);
        }

        public async Task<List<LayuiData>> GetUsers()
        {
            string selectSql = @"SELECT Id, UserName, sex, city, sign, experience, logins, wealth, classify, score FROM layuidata";
            return await Select(selectSql);
        }

        public async Task PostUser(LayuiData entity)
        {
            string insertSql = @"INSERT INTO layuidata(UserName, sex, city, sign, experience, logins, wealth, classify, score) VALUES(@username, @sex, @city, @sign, @experience, @logins, @wealth, @classify, @score)";
            await Insert(entity, insertSql);
        }

        public async Task PutUser(LayuiData entity)
        {
            string updateSql = "UPDATE Users SET UserName=@UserName, Password=@Password, Gender=@Gender, Birthday=@Birthday, CreateDate=@CreateDate, IsDelete=@IsDelete WHERE Id=@Id";
            await Update(entity, updateSql);
        }

        //实现分页查询
        public async Task<List<LayuiData>> GetUsersByPage(int page, int limit)
        {
            string selectSql = @"SELECT Id, UserName, sex, city, sign, experience, logins, wealth, classify, score FROM layuidata limit "+(page-1) * limit+","+limit+"";
            return await Select(selectSql);
        }

        //获取重载数据
        public async Task<List<LayuiData>> GetListReload(int page, int limit)
        {
            string selectSql = @"SELECT Id, UserName, sex, city, sign, experience, logins, wealth, classify, score FROM layuiDataForReload limit " + (page - 1) * limit + "," + limit + "";
            return await Select(selectSql);
        }

        //修改签名
        public async Task<ReturnCode> UpdateSign(int Id, string Sign)
        {
            LayuiData layuiData = new LayuiData();
            layuiData.id = Id;
            layuiData.sign = Sign;
            string updateSql = @"UPDATE layuidata SET sign = @sign WHERE Id = @id";
            if (await Update(layuiData, updateSql) <= 0)
            {
                return new ReturnCode
                {
                    Code = 400,
                    Message = "未查找到对应数据"
                };
            }
            else
            {
                return new ReturnCode
                {
                    Code = 200,
                    Message = "修改数据成功"
                };
            }
        }
    }
}
