using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    #region 注册模块
    [SerializeField]
    private InputField inAcc4Register;//注册界面中的账户名
    [SerializeField]
    private InputField inPwd4Register;//注册界面中的输入密码
    [SerializeField]
    private InputField inPwd4Repeat;//注册界面中的再次输入密码

    //注册的点击事件
    public void OnRegisterClick()
    {
        if(string.IsNullOrEmpty(inAcc4Register.text)|| string.IsNullOrEmpty(inPwd4Register.text) 
            || !inPwd4Register.text.Equals(inPwd4Repeat.text))
        {
            //输入不合法 直接返回

            return;
        }
    }

    #endregion

}
