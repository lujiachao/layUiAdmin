using layUiAdmin.SQL.Repository;
using System;
using System.Threading;

namespace DataLooper
{
    class Program
    {
        public static void Main(string[] args)
        {
            Timer timer = new Timer(reloadDataToMysql,"test",1000,5000);
            Console.ReadKey();
        }

        public static async void reloadDataToMysql(object obj)
        {
            ReloadDataRespository reloadDataRespository = new ReloadDataRespository();
            await reloadDataRespository.reloadData();
        }
    }
}
