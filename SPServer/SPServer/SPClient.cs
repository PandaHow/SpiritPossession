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


        public SPClient(InitRequest initRequest) 
            : base(initRequest)
        {
            account = new AccountHandler();
        }

        //客户端断开连接
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
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
                default:
                    break;
            }
        }
    }
}
