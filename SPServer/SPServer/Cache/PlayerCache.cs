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
        public void Creat(string name, int accId)
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
    }


}
