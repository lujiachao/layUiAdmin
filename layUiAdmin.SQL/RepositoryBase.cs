using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace layUiAdmin.SQL.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        public async Task Delete(int Id, string deleteSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                await conn.ExecuteAsync(deleteSql, new { Id = Id });
            }
        }

        public async Task<T> Detail(int Id, string detailSql)
        {
            using (MySqlConnection conn = DataBaseConfig.GetSqlConnection())
            {
                //string querySql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM dbo.Users WHERE Id=@Id";
                return await conn.QueryFirstOrDefaultAsync<T>(detailSql, new { Id = Id });
            }
        }

        /// <summary>
        /// 无参存储过程
        /// </summary>
        /// <param name="SPName"></param>
        /// <returns></returns>
        public async Task<List<T>> ExecQuerySP(string SPName)
        {
            using (MySqlConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return await Task.Run(() => conn.Query<T>(SPName, null, null, true, null, CommandType.StoredProcedure).ToList());
            }
        }

        public async Task Insert(T entity, string insertSql)
        {
            using (MySqlConnection conn = DataBaseConfig.GetSqlConnection())
            {
                await conn.ExecuteAsync(insertSql, entity);
            }
        }

        public void Insertnotas(T entity, string insertSql)
        {
            using (MySqlConnection conn = DataBaseConfig.GetSqlConnection())
            {
                conn.Execute(insertSql,entity);
            }
        }
        public async Task<List<T>> Select(string selectSql)
        {
            using (MySqlConnection conn = DataBaseConfig.GetSqlConnection())
            {
                //string selectSql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM dbo.Users";
                return await Task.Run(() => conn.Query<T>(selectSql).ToList());
            }
        }

        public async Task<int> Update(T entity, string updateSql)
        {
            using (MySqlConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return await conn.ExecuteAsync(updateSql, entity);
            }
        }

        public async Task ExcuteSQL(string excuteSql)
        {
            using (MySqlConnection conn = DataBaseConfig.GetSqlConnection())
            {
                await conn.ExecuteAsync(excuteSql);
            }
        }
    }
}