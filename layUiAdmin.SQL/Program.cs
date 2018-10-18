using layUiAdmin.SQL.Entities;
using layUiAdmin.SQL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace layUiAdmin.SQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LayuiDataRepository userRepository = new LayuiDataRepository();
            LayuiData layuiData = new LayuiData();
            for (int i = 0; i < 100; i++)
            {
                layuiData.username = "User-" + i.ToString();
                layuiData.sex = i % 2 == 0 ? "女" : "男";
                layuiData.city = "城市-" + i.ToString();
                layuiData.sign = "签名-" + i.ToString();
                layuiData.experience = 255;
                layuiData.logins = 24;
                layuiData.wealth = 83289381;
                layuiData.classify = "作家";
                layuiData.score = 55;
            }
            
        }
    }
}
