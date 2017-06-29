using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotonHostRuntimeInterfaces;


namespace SPServer
{
    public class SPClient : ClientPeer
    {
        public SPClient(InitRequest initRequest) 
            : base(initRequest)
        {
        }

        //客户端断开连接
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
        }
        //客户端请求
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
        }
    }
}
