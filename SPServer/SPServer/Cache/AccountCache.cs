using SPServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPServer.Cache
{
    //账号的缓存层
    public class AccountCache
    {
        #region 数据


        // 账号和模型的映射

        private Dictionary<string, AccountModel> accModelDict = new Dictionary<string, AccountModel>();

        //匹配账号密码是否存在且正确
        public bool Match(string acc, string pwd)
        {
            if (!accModelDict.ContainsKey(acc))
                return false;
            return accModelDict[acc].Password == pwd;
        }

        private int id = 0;//模拟自增id
        //注册时添加账号密码
        public bool Add(string acc, string pwd)
        {
            //用户名是否已经被注册
            if (Has(acc))
                return false;
            //添加
            accModelDict[acc] = new AccountModel(id, acc, pwd);
            id++;
            return true;
        }

        //是否有账号
        public bool Has(string acc)
        {
            return accModelDict.ContainsKey(acc);
        }
        #endregion

        #region 在线玩家
        private Dictionary< SPClient, string> clientAccDict = new Dictionary<SPClient, string>();

        //是否在线
        public bool IsOnline(string acc)
        {
            return clientAccDict.ContainsValue(acc);
        }

        //添加在线关系(上线）
        public bool Online(string acc, SPClient client)
        {
            if (IsOnline(acc))
                return false;
            clientAccDict[client] = acc;
            return true;

        }

        //下线
        public void Offline(SPClient client)
        {
            if(clientAccDict.ContainsKey(client))
                clientAccDict.Remove(client);
        }
        #endregion

    }
}
