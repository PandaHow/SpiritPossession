using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using SPCommon.Code;
using UnityEngine.UI;

public class AccountReceiver : MonoBehaviour, IReceiver
{
    [SerializeField]
    private AccountView view;
    [SerializeField]
    private GameObject UIAccount;
    [SerializeField]
    private GameObject UIMain;

    public void OnReceive(byte subCode, OperationResponse response)
    {
        switch (subCode)
        {
            case OpAccount.Login:
                onLogin(response.ReturnCode, response.DebugMessage);
                break;
            case OpAccount.Register:
                onRegister(response.ReturnCode, response.DebugMessage);
                break;
            default:
                break;
        }
    }
    //在AccountHandler.cs里面写了“玩家在线”“登录成功”“错误”的返回码
    //show函数里面的mess参数对应的就是AccountpHandler.cs里面的this.send()函数里面的字符串参数
    //登录的处理
    private void onLogin(short retCode, string mess)
    {
        switch (retCode)
        {
            case 0:
                //成功 进入下一个UI
                ShowUI(UIMain);
                HideUI(UIAccount);
                PhotonManager.Instance.Request(OpCode.PlayerCode, OpPlayer.GetInfo);
                break;
            case -1:
                //失败 玩家在线
                MessageTip.Instance.Show(mess);
                view.EnterInteractable = true;
                view.ResetLoginInput();
                break;
            case -2:
                //失败 账号密码错误
                MessageTip.Instance.Show(mess);
                view.EnterInteractable = true;
                view.ResetLoginInput();
                break;
            default:
                break;
        }
    }
    //注册的处理
    private void onRegister(short retCode,string mess)
    {
        switch (retCode)
        {
            case 0:
                //成功 注册成功
                MessageTip.Instance.Show(mess);
                break;
            case -1:
                //失败 账号重复
                MessageTip.Instance.Show(mess);
                break;
            default:
                break;
        }
    }

    #region 处理UI显示与隐藏的函数（就是UIBase.cs里面的onshow和onhide（））

    private void ShowUI(GameObject ob)
    {
        if (ob.GetComponent<CanvasGroup>())
        {
            ob.GetComponent<CanvasGroup>().alpha = 1;
            ob.GetComponent<CanvasGroup>().interactable = true;
            ob.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    private void HideUI(GameObject ob)
    {
        if (ob.GetComponent<CanvasGroup>())
        {
            ob.GetComponent<CanvasGroup>().alpha = 0;
            ob.GetComponent<CanvasGroup>().interactable = false;
            ob.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    #endregion
}

