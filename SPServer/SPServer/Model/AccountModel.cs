using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPServer.Model
{
    //账号的数据模型
    public class AccountModel
    {
        private int id;
        private string account;
        private string password;

        public int Id { get { return id; } set { id = value; } }
        public string Account { get { return account; } set { account = value; } }
        public string Password { get { return password; } set { password = value; } }

        public AccountModel()
       {
            //构造函数

       }

         public AccountModel(int id,string account,string password)
       {
            //构造函数
            this.Id = id;
            this.Account = account;
            this.Password = password;

       }
    }
}
