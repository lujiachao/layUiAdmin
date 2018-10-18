using layUiAdmin.SQL.Entities;
using layUiAdmin.SQL.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace layUiAdmin.SQL.Repository
{
    public class ReloadDataRespository : RepositoryBase<LayuiData>, IReloadDataRespository
    {
        public async Task reloadData()
        {
            //string tunckSql = "TRUNCATE TABLE layuiDataForReload";
            //await ExcuteSQL(tunckSql);
            LayuiData layuiData = new LayuiData()
             {
                 username = "ljc",
                 sex = "男",
                 city = "宁波",
                 sign = "adsad",
                 experience = 5,
                 logins = 5,
                 wealth = 5,
                 classify = "dsad",
                 score = 6
             };

            string insertSql = @"INSERT INTO layuidataforreload(UserName, sex, city, sign, experience, logins, wealth, classify, score) VALUES(@username, @sex, @city, @sign, @experience, @logins, @wealth, @classify, @score)";
            await Insert(layuiData, insertSql);   
            
        }
    }
}
