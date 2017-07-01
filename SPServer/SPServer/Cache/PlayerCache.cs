using SPServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExitGames.Threading;

namespace SPServer.Cache
{
    public class PlayerCache
    {
        #region 数据
        //玩家ID和模型的映射（玩家id对应的玩家数据）
        SynchronizedDictionary<int, PlayerModel> idModelDict = new SynchronizedDictionary<int, PlayerModel>();
        //账号id对应的玩家id
        //private Dictionary<int, int> accPlayerDict = new Dictionary<int, int>();
        SynchronizedDictionary<int, int> accPlayerDict = new SynchronizedDictionary<int, int>();
        //线程互斥锁 （解决两个玩家同事创建账号index的自增问题）

        //主键id
        private int index = 0;
        //创建角色
        public void Creat(string name, int accId)//create拼错了
        {
            PlayerModel model = new PlayerModel(index, name, accId);
            accPlayerDict.TryAdd(accId, model.Id);
            idModelDict.TryAdd(model.Id, model);
        }

        //判断是否存在角色
        public bool Has(int accountId)
        {
            return accPlayerDict.ContainsKey(accountId);
        }
        #endregion
        #region 上线

        private SynchronizedDictionary<SPClient, int> clientIdDict = new SynchronizedDictionary<SPClient, int>();
        //双向映射 访问起来比较容易 添加和删除需要两个都做
        private SynchronizedDictionary<int, SPClient> idClientDict = new SynchronizedDictionary<int, SPClient>();

        //上线
        public void Online(SPClient client, int playerId)
        {
            clientIdDict.TryAdd(client, playerId);
            idClientDict.TryAdd(playerId, client);
        }

        // 下线
        public void Offline(SPClient client)
        {
            int id = clientIdDict[client];

            if (clientIdDict.ContainsKey(client))
                clientIdDict.Remove(client);

            if (idClientDict.ContainsKey(id))
                idClientDict.Remove(id);
        }

        // 玩家是否在线
        public bool Has(SPClient client)
        {
            return clientIdDict.ContainsKey(client);
        }


        #endregion

        /// 获取玩家ID
        public int GetId(int accId)
        {
            int playerId = -1;
            accPlayerDict.TryGetValue(accId, out playerId);
            return playerId;
        }
        /// 获取玩家数据
        public PlayerModel GetModel(int playerId)
        {
            return idModelDict[playerId];
        }
    }


}
