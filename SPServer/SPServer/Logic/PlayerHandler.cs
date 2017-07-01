using System;
using Photon.SocketServer;
using SPCommon.Code;
using SPServer.Cache;
using SPCommon.Dto;
using SPServer.Model;
using LitJson;


namespace SPServer.Logic
{
    public class PlayerHandler : SingleSend, IOpHandler
    {
        //账号缓存
        private AccountCache accountCache = Caches.Account;
        private PlayerCache playerCache = Caches.Player;

        void IOpHandler.OnDisconnect(SPClient client)
        {
            playerCache.Offline(client);
        }

        void IOpHandler.OnRequest(SPClient client, byte subCode, OperationRequest request)
        {
            switch(subCode)
            {
                case OpPlayer.GetInfo:
                    onGetInfo(client);
                    break;
                case OpPlayer.Create:
                    string name = request[0].ToString();
                    onCreate(client, name);
                    break;
                case OpPlayer.Online:
                    onOnline(client);
                    break;
                default:
                    break;
            }
            
        }

        /// <summary>
        /// 上线的处理
        /// </summary>
        /// <param name="client"></param>
        private void onOnline(SPClient client)
        {
            int accId = accountCache.GetId(client);
            int playerId = playerCache.GetId(accId);
            //防止重复在线
            if (playerCache.Has(client))
                return;
            //上线
            playerCache.Online(client, playerId);

            PlayerModel model = playerCache.GetModel(playerId);
            PlayerDto dto = new PlayerDto()
            {
                id = model.Id,
                exp = model.Exp,
                friendIdList = model.FriendIdList,
                heroIdList = model.HeroIdList,
                loseCount = model.LoseCount,
                lv = model.Lv,
                name = model.Name,
                power = model.Power,
                runCount = model.RunCount,
                winCount = model.WinCount
            };
            Send(client, OpCode.PlayerCode, OpPlayer.Online, 0, "上线成功！", JsonMapper.ToJson(dto));
        }

        //创建角色
        private void onCreate(SPClient client, string name)
        {
            int accId = accountCache.GetId(client);
            if (playerCache.Has(accId))
                return;

            //验证时候开始创建
            playerCache.Creat(name, accId);
            Send(client, OpCode.PlayerCode, OpPlayer.Create, 0, "创建成功！");
        }

        //获取角色信息
        private void onGetInfo(SPClient client)
        {
            int accId = accountCache.GetId(client);
            if(accId == -1)
            {
                Send(client, OpCode.PlayerCode, OpPlayer.GetInfo, -1, "非法登录！");
                return;
            }

            if(playerCache.Has(accId))
            {
                Send(client, OpCode.PlayerCode, OpPlayer.GetInfo, 0, "已存在玩家信息！");
                return;
            }
            else
            {
                Send(client, OpCode.PlayerCode, OpPlayer.GetInfo, -2, "不存在玩家信息！");
                return;
            }
        }

    }
}
