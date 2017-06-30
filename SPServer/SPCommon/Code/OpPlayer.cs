using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPCommon.Code
{
    /// 角色操作码
    public class OpPlayer
    {
        /// 获取信息
        public const byte GetInfo = 0;

        /// 创建角色
        public const byte Create = 1;

        /// 玩家上线
        public const byte Online = 2;

        /// 添加好友
        public const byte Add = 3;
    }
}
