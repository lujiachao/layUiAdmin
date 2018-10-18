using layUiAdmin.SQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace layUiAdmin.SQL.IRepository
{
    public interface ILayuiDataRepository : IRepositoryBase<LayuiData>
    {
        #region 扩展的dapper操作

        //加一个带参数的存储过程
        string ExecExecQueryParamSP(string spName, string name, int Id);

        Task<List<LayuiData>> GetUsers();

        Task PostUser(LayuiData entity);

        Task PutUser(LayuiData entity);

        Task DeleteUser(int Id);

        Task<LayuiData> GetUserDetail(int Id);

        #endregion
    }
}
