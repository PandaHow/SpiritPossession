using ExitGames.Threading;
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

        private SynchronizedDictionary<string, AccountModel> accModelDict = new SynchronizedDictionary<string, AccountModel>();

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
        private SynchronizedDictionary < SPClient, string> clientAccDict = new SynchronizedDictionary<SPClient, string>();
        //双向映射 访问起来比较容易 添加和删除需要两个都做
        private SynchronizedDictionary<string, SPClient> accClientDict = new SynchronizedDictionary<string, SPClient>();

        //是否在线
        public bool IsOnline(string acc)
        {
            return accClientDict.ContainsKey(acc);
        }

        //添加在线关系(上线）
        public bool Online(string acc, SPClient client)
        {
            if (IsOnline(acc))
                return false;
            clientAccDict[client] = acc;
            accClientDict[acc] = client;
            return true;

        }

        //下线
        public void Offline(SPClient client)
        {

            string acc = clientAccDict[client];
            //注意移除顺序
            if (accClientDict.ContainsKey(acc))
                accClientDict.Remove(acc);

            if (clientAccDict.ContainsKey(client))
                clientAccDict.Remove(client);
        }
        #endregion

        //根据连接对象获取账号id 有就返回id 没有就返回-1
        public int GetId(SPClient client)
        {
            if (!clientAccDict.ContainsKey(client))
                return -1;
            string account = clientAccDict[client];
            if (!accModelDict.ContainsKey(account))
                return -1;
            return accModelDict[account].Id;
         }
    }
}
