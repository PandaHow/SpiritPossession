using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using SPCommon.Code;
using LitJson;
using SPCommon.Dto;
using SPServer.Cache;//SPServer是项目名 Cache是文件夹名

namespace SPServer.Logic
{
    // 账号的逻辑处理
    public class AccountHandler : SingleSend,IOpHandler
    {
        //账号缓存
        private AccountCache cache = Caches.Account;

        void IOpHandler.OnDisconnect(SPClient client)
        {
            cache.Offline(client);
        }

        void IOpHandler.OnRequest(SPClient client, byte subCode, OperationRequest request)
        {
            switch(subCode)
            {
                case OpAccount.Login:
                    AccountDto dto = JsonMapper.ToObject<AccountDto>(request[0].ToString());
                    //验证账号密码是否合法
                    onLogin(client,dto.Account, dto.Password);
                    break;
                case OpAccount.Register:
                    string acc = request[0].ToString();
                    string pwd = request[1].ToString();
                    //添加账号
                    onRegister(client,acc, pwd);

                    break;
                default:
                    break;
            }
        }

        #region 子处理
        //登录处理
        private void onLogin(SPClient client, string acc, string pwd)
        {
            //无效检测
            if (acc == null || pwd == null)
                return;
            //验证在线
            if(cache.IsOnline(acc))
            {
                this.Send(client, OpCode.AccountCode, OpAccount.Login,-1, "玩家已经在线！");
                return;
            }

            if (cache.Match(acc, pwd))
            {
                cache.Online(acc, client);
                //继承了singlesend类 所以可以调用send方法 那个0参数是returnCode 定义里说 Code 0 means OK
                this.Send(client, OpCode.AccountCode, OpAccount.Login, 0, "登录成功！");
            }
            else
            {
                this.Send(client, OpCode.AccountCode, OpAccount.Login, -2, "账号或密码错误！");
            }

        }

        //注册处理
        private void onRegister(SPClient client, string acc, string pwd)
        {
        
            //无效检测
            if (acc == null || pwd == null)
            {
               // this.Send(client, OpCode.AccountCode, OpAccount.Register, -3, "请将信息填写完整！");这个有问题 回来再改
                return;
            }
            //重复检测
            if (cache.Has(acc))
            {
                this.Send(client, OpCode.AccountCode, OpAccount.Register, -1, "账号已经被注册！");
                return;
            }
                
            cache.Add(acc, pwd);
            this.Send(client, OpCode.AccountCode, OpAccount.Register, 0, "注册成功！");
        }
        #endregion

    }
}
