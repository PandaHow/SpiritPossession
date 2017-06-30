using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPServer.Model
{
    // 玩家数据模型
    public class PlayerModel
    {
        private int id;
        private string name;
        private int lv;
        private int exp;
        private int power;
        private int winCount;
        private int loseCount;
        private int runCount;
        private string heroIdList;
        private string friendIdList;
        private int accountId;

        #region Property
        // 主键
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        // 名称
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        // 等级
        public int Lv
        {
            get
            {
                return lv;
            }

            set
            {
                lv = value;
            }
        }
        // 经验
        public int Exp
        {
            get
            {
                return exp;
            }

            set
            {
                exp = value;
            }
        }
        // 战斗力
        public int Power
        {
            get
            {
                return power;
            }

            set
            {
                power = value;
            }
        }
        // 胜利场次
        public int WinCount
        {
            get
            {
                return winCount;
            }

            set
            {
                winCount = value;
            }
        }
        // 失败场次
        public int LoseCount
        {
            get
            {
                return loseCount;
            }

            set
            {
                loseCount = value;
            }
        }
        // 逃跑场次
        public int RunCount
        {
            get
            {
                return runCount;
            }

            set
            {
                runCount = value;
            }
        }
        // 英雄ID列表
        public string HeroIdList
        {
            get
            {
                return heroIdList;
            }

            set
            {
                heroIdList = value;
            }
        }
        // 好友ID列表
        public string FriendIdList
        {
            get
            {
                return friendIdList;
            }

            set
            {
                friendIdList = value;
            }
        }
        #endregion

        public PlayerModel()
        {

        }

        public PlayerModel(int id, string name, int accId)
        {
            this.Id = id;
            this.Name = name;
            this.accountId = accId;

            Lv = 1;
            Exp = 0;
            Power = 2000;
            WinCount = 0;
            LoseCount = 0;
            RunCount = 0;
            HeroIdList = "0,1";
            FriendIdList = string.Empty;
        }
    }
}
