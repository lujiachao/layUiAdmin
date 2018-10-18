using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layUiAdmin.Result
{
    public class ResultUser : IAPIResult
    {
        public int id
        {
            get; set;
        }

        public string username
        {
            get; set;
        }

        public string sex
        {
            get; set;
        }

        public string city
        {
            get; set;
        }

        public string sign
        {
            get; set;
        }

        public int experience
        {
            get; set;
        }

        public int logins
        {
            get; set;
        }

        public int wealth
        {
            get; set;
        }

        public string classify
        {
            get; set;
        }

        public int score
        {
            get; set;
        }
    }
}
