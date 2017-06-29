using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PhotonManager : MonoBehaviour, IPhotonPeerListener
{
    //代表客户端
    private PhotonPeer peer;
    //IP地址 deploy/bin_win64/PhotonServer.Config 里面可改接口（Port）
    private string serverAddress = "127.0.0.1:5055";//我好像把之前的server都拼错了...
    //名字 应与deploy/bin_win64/PhotonServer.Config 里面deploy/bin_win64/PhotonServer.Config 里面的一致
    private string applicationName = "SP";
    //协议
    private ConnectionProtocol protocol = ConnectionProtocol.Udp;

    private bool isConnect = false;
    #region Photon接口
    public void DebugReturn(DebugLevel level, string message)
    {

    }

    public void OnEvent(EventData eventData)
    {

    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {

    }
    //连接状态改变
    public void OnStatusChanged(StatusCode statusCode)
    {
        Debug.Log(statusCode);
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

    void Awake()
    {
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
        peer.Disconnect();//断开连接
    }
}
