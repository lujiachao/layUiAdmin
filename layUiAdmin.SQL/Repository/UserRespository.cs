using Dapper;
using layUiAdmin.SQL.Entities;
using layUiAdmin.SQL.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace layUiAdmin.SQL.Repository
{
    public class UserRepository : RepositoryBase<Users>, IUserRepository
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

        public async Task<Users> GetUserDetail(int Id)
        {
            string detailSql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM Users WHERE Id=@Id";
            return await Detail(Id, detailSql);
        }

        public async Task<List<Users>> GetUsers()
        {
            string selectSql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM Users";
            return await Select(selectSql);
        }

        public async Task PostUser(Users entity)
        {
            string insertSql = @"INSERT INTO Users(UserName, Password, Gender, Birthday, CreateDate, IsDelete) VALUES(@UserName, @Password, @Gender, @Birthday, @CreateDate, @IsDelete)";
            await Insert(entity, insertSql);
        }

        public void PostUserNotAs(Users entity)
        {
            string insertSql = @"INSERT INTO Users(UserName, Password, Gender, Birthday, CreateDate, IsDelete) VALUES( @UserName, @Password, @Gender, @Birthday, @CreateDate, @IsDelete)";
             Insertnotas(entity, insertSql);
        }

        public async Task PutUser(Users entity)
        {
            string updateSql = "UPDATE Users SET UserName=@UserName, Password=@Password, Gender=@Gender, Birthday=@Birthday, CreateDate=@CreateDate, IsDelete=@IsDelete WHERE Id=@Id";
            await Update(entity, updateSql);
        }
    }
}
