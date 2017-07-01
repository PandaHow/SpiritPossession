using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using ExitGames.Client.Photon;
using SPCommon.Code;
using SPCommon.Dto;
using LitJson;
using UnityEngine.Experimental.Director;

public class PlayerReceiver : MonoBehaviour,IReceiver
{
    [SerializeField]
    private MainView view;
    public void OnReceive(byte subCode, OperationResponse response)
    {
        
        switch (subCode)
        { 
            case OpPlayer.GetInfo://返回码信息在服务器端的playerHandler.cs
                Debug.Log("获取玩家信息的返回码是"+response.ReturnCode);
                onGetInfo(response.ReturnCode);
            break;
            case OpPlayer.Create:
                onCreate();
                break;
            case OpPlayer.Online:
                PlayerDto dto = JsonMapper.ToObject<PlayerDto>(response[0].ToString());
                onOnline(dto);
                break;
            default:
            break;
        }
    }

    /// 上线
    private void onOnline(PlayerDto dto)
    {
        //保存数据
        GameData.Player = dto;
        //刷新视图
        view.UpdateView(dto);
    }
    //创建角色
    private void onCreate()
    {
        //隐藏创建面板
        view.CreatePanelActive = false;
        //创建成功后发起上线的请求
        playerOnline();
    }
    //获取信息
    private void onGetInfo(int retCode)
    {
        if (retCode == -1)
        {
            //非法登录
        }
        else if (retCode == 0)
        {
            //角色存在 上线
            playerOnline();
        }
        else if (retCode == -2)
        {
            //角色不存在 显示创建玩家角色面板
            view.CreatePanelActive = true;
            
        }
    }

    /// 角色上线
    private void playerOnline()
    {
        PhotonManager.Instance.Request(OpCode.PlayerCode, OpPlayer.Online);
    }
}
