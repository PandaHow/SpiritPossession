using SPCommon.Code;
using SPCommon.Dto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System;

public class AccountView : MonoBehaviour
{
    #region 注册模块
    [Header("登录模块")]
    [SerializeField]
    private InputField inAcc4Register;//注册界面中的账户名
    [SerializeField]
    private InputField inPwd4Register;//注册界面中的输入密码
    [SerializeField]
    private InputField inPwd4Repeat;//注册界面中的再次输入密码

    public void OnResetPanel()
    {
        inAcc4Register.text = string.Empty;
        inPwd4Register.text = string.Empty;
        inPwd4Repeat.text = string.Empty;
    }
    //注册的点击事件
    public void OnRegisterClick()
    {
        //判断账号密码是否为空 两次密码输入是否相同
        if(string.IsNullOrEmpty(inAcc4Register.text)|| string.IsNullOrEmpty(inPwd4Register.text) 
            || !inPwd4Register.text.Equals(inPwd4Repeat.text))
        {
            //通知客户输入不合法 直接返回

            return;
        }

        string account = inAcc4Register.text;
        string password = inPwd4Register.text;
        // 1 account 2 password
        PhotonManager.Instance.Request(OpCode.AccountCode, OpAccount.Register, account, password);
    }

    #endregion
    
    #region 登录模块
    [Header("登录模块")]
    [SerializeField]
    private InputField inAcc4Login;//登录界面中的账户名
    [SerializeField]
    private InputField inPwd4Login;//登录界面中的密码
    [SerializeField]
    private Button btnEnter;
    
    //进入按钮是否可以点击
    public bool EnterInteractable
    {
        set { btnEnter.interactable = value; }
    }
    //进入游戏的点击事件
    public void OnEnterClick()
    {
        if (string.IsNullOrEmpty(inAcc4Login.text) || string.IsNullOrEmpty(inPwd4Login.text))
        {
            //输入不合法 需要提示 （后面做）
            return;
        }
        //创建传输模型
        AccountDto dto = new AccountDto()
        {
            Account = inAcc4Login.text,
            Password = inPwd4Login.text
        };
        //发送
        PhotonManager.Instance.Request(OpCode.AccountCode, OpAccount.Login, JsonMapper.ToJson(dto));
        //设置进入按钮不可点击状态
        EnterInteractable = false;

    }

    //重置登录面板的输入
    public void ResetLoginInput()
    {
        inAcc4Login.text = string.Empty;
        inPwd4Login.text = string.Empty;
    }


    #endregion

    #region UIBase

    #endregion
}
