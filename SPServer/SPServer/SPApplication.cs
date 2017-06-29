using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPServer
{
    class SPApplication : ApplicationBase
    {
        //客户端连接
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new SPClient(initRequest);
        }
        //服务器初始化
        protected override void Setup()
        {
            
        }
        //服务器断开
        protected override void TearDown()
        {
            
        }

        #region 日志功能

        private static readonly ILogger log = ExitGames.Logging.LogManager.GetCurrentClassLogger();

        private void InitLogging()
        {
            LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
            log4net.GlobalContext.Properties["LogFileName"] = "SP"+this.ApplicationName;
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(this.BinaryPath, "log4net.config")));
        }

        public static void LogInfo(string text)
        {
            log.Info(text);
        }

        #endregion

    }
}
