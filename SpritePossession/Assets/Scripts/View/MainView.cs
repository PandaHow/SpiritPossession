using SPCommon.Code;
using SPCommon.Dto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour {

    #region 创建角色模块

    [Header("创建模块")]
    [SerializeField]
    private InputField inName;
    [SerializeField]
    private Button btnCreate;

    // 创建按钮的可点状态
    public bool CreateInteractable
    {
        set { btnCreate.interactable = value; }
    }

    [SerializeField]
    private GameObject createPanel;

    // 创建面板可见
    public bool CreatePanelActive
    {
        set { createPanel.SetActive(value); }
    }

    public void OnCreateClick()
    {

        //输入检测
        if (string.IsNullOrEmpty(inName.text))
            return;

        //发起创建请求
        PhotonManager.Instance.Request(OpCode.PlayerCode, OpPlayer.Create, inName.text);
        //禁用按钮
        CreateInteractable = false;
    }



    #endregion

    //private void Start()
    //{
    //    //添加监听 这样就不用手动去点击+ onclick然后拖拽了
    //    btnCreate.onClick.AddListener(OnCreateClick);
    //}

    [Header("角色信息")]
    [SerializeField]
    private Text txtName;
    [SerializeField]
    private Slider barExp;
    [SerializeField]
    private Transform friendTran;

    // 更新显示
    public void UpdateView(PlayerDto player)
    {

        txtName.text = player.name;
        barExp.value = (float)player.exp / (player.lv * 100);// 经验值滑动条的填充部分计算公式
        //TODO
    }
}
