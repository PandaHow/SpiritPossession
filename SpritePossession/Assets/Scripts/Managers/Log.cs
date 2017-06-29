using System;
using System.Collections.Generic;

    //封装输出类 测试时用上面的 发布时用下面的 这样发布时后台log的结果就是空 不会消耗资源
    public class Log
    {
        //委托
        public static Action<object> Debug   = UnityEngine.Debug.Log;
        public static Action<object> Error   = UnityEngine.Debug.LogError;
        public static Action<object> Warning = UnityEngine.Debug.LogWarning;

        //public static void Debug(string text) { }
        //public static void Error(string text) { }
        //public static void Warning(string text) { }
    }

