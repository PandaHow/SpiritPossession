using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotonHostRuntimeInterfaces;
using SPServer.Logic;
using SPCommon.Code;

namespace SPServer
{
    public class SPClient : ClientPeer
    {
        //账号逻辑
        IOpHandler account;
        IOpHandler player;

        public SPClient(InitRequest initRequest) 
            : base(initRequest)
        {
            account = new AccountHandler();
            player = new PlayerHandler();
        }

        //客户端断开连接
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {//注意顺序 往后添加的东西都在player一层层往上
            player.OnDisconnect(this);
            account.OnDisconnect(this);
        }
        //客户端请求
        protected override void OnOperationRequest(OperationRequest request, SendParameters sendParameters)
        {
            byte opCode = request.OperationCode;
            byte subCode = (byte)request[80];

            switch(opCode)
            {
                case OpCode.AccountCode:
                    account.OnRequest(this,subCode,request);
                    break;
                case OpCode.PlayerCode:
                    player.OnRequest(this, subCode, request);
                    break;
                default:
                    break;
            }
        }
    }
}
