using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SPCommon.Code;
//photon管理

public class PhotonManager : Singleton<PhotonManager>, IPhotonPeerListener
{
    #region Receivers
    //账号
    private AccountReceiver account;
    public AccountReceiver Account
    {
        get
        {
            if (account == null)
                account = FindObjectOfType<AccountReceiver>();
            return account;

        }
    }

    //角色
    private PlayerReceiver player;
    public PlayerReceiver Player
    {
        get
        {
            if (player == null)
                player = FindObjectOfType<PlayerReceiver>();
            return player;

        }
    }
    #endregion

    #region Photon接口


    //代表客户端
    private PhotonPeer peer;
    //IP地址 deploy/bin_win64/PhotonServer.Config 里面可改接口（Port）
    private string serverAddress = "127.0.0.1:5055";
    //名字 应与deploy/bin_win64/PhotonServer.Config 里面deploy/bin_win64/PhotonServer.Config 里面的一致
    private string applicationName = "SP";
    //协议
    private ConnectionProtocol protocol = ConnectionProtocol.Udp;
    //连接flag
    private bool isConnect = false;

    public void DebugReturn(DebugLevel level, string message)
    {

    }

    public void OnEvent(EventData eventData)
    {

    }
    //接收服务器的响应
    public void OnOperationResponse(OperationResponse response)
    {
        Log.Debug (response.ToStringFull());
        byte opCode = response.OperationCode;
        byte subCode = (byte)response[80];
        //转接
        switch(opCode)
        {
            case OpCode.AccountCode:
                Account.OnReceive(subCode, response);
                break;
            case OpCode.PlayerCode:
                Player.OnReceive(subCode, response);
                break;
            default:
                break;
        }
    }
    //连接状态改变
    public void OnStatusChanged(StatusCode statusCode)
    {
        Log.Debug("连接状态改变为"+statusCode);
        switch(statusCode)
        {
            case StatusCode.Connect:
                isConnect = true;
                break;
            case StatusCode.Disconnect:
                isConnect = false;
                break;
            default:
                break;
        }
    }
    #endregion

    protected override void Awake()
    {
        base.Awake();
        peer = new PhotonPeer(this, protocol);
        peer.Connect(serverAddress, applicationName);
    }

    void Update()
    {
        if(!isConnect)
        {
            peer.Connect(serverAddress, applicationName);
        }

        peer.Service();
    }

    void OnApplicationQuit()
    {
        Debug.Log("断开连接");
        peer.Disconnect();//断开连接
    }

    /// <summary>
    /// 向服务器发送请求(把这个方法封装好 以便别处调用 （LoginView.cs里面会用到）)
    /// </summary>
    /// <param name="code">操作码</param>
    /// <param name="SubCode">子操作码</param>
    /// <param name="parameters">参数</param>
    public void Request(byte code, byte SubCode, params object[] parameters)
    {
        //创建参数字典
        Dictionary<byte, object> dict = new Dictionary<byte, object>();
        //指定子操作码
        dict[80] = SubCode;//80是一个上限
        //给参数赋值
        for (int i = 0; i < parameters.Length; i++)
        {
            dict[(byte)i] = parameters[i];
        }
        //发送
        peer.OpCustom(code, dict, true);
    }

}
