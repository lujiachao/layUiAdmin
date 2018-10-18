using System;
using System.Collections.Generic;
using System.Text;

namespace layUiAdmin.SQL.Entities
{
    public class Users
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 性别（0女，1男）
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 出生年月日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 是否删除（0正常，1删除）
        /// </summary>
        public int IsDelete { get; set; }
    }
}
