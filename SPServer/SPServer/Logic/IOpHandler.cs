using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPServer.Logic
{

    public  interface IOpHandler
    {
        /// <summary>
        /// 收到请求时的处理
        /// </summary>
        /// <param name="client">哪个客户端</param>
        /// <param name="subCode">子操作码</param>
        /// <param name="request">请求</param>
        void OnRequest(SPClient client, byte subCode, OperationRequest request);
        /// <summary>
        /// 掉线时的处理
        /// </summary>
        /// <param name="client"></param>
        void OnDisconnect(SPClient client);
    }
}
