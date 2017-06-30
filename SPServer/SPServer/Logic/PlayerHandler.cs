using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using SPCommon.Code;
using SPServer.Cache;

namespace SPServer.Logic
{
    public class PlayerHandler : SingleSend, IOpHandler
    {
        //账号缓存
        private AccountCache accountCache = Caches.Account;
        private PlayerCache playerCache = Caches.Player;

        void IOpHandler.OnDisconnect(SPClient client)
        {
            
        }

        void IOpHandler.OnRequest(SPClient client, byte subCode, OperationRequest request)
        {
            switch(subCode)
            {
                case OpPlayer.GetInfo:
                    onGetInfo(client);
                    break;
                default:
                    break;
            }
            
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
                Send(client, OpCode.PlayerCode, OpPlayer.GetInfo, 0, "不存在玩家信息！");
                return;
            }
        }

    }
}
