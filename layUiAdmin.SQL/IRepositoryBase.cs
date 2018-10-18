using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace layUiAdmin.SQL
{
    public interface IRepositoryBase<T>
    {
        Task Insert(T entity, string insertSql);

        Task Update(T entity, string updateSql);

        Task Delete(int Id, string deleteSql);

        Task<List<T>> Select(string selectSql);

        Task<T> Detail(int Id, string detailSql);

        /// <summary>
        /// 无参存储过程
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<List<T>> ExecQuerySP(string SPName);

        Task ExcuteSQL(string excuteSql);
    }
}
