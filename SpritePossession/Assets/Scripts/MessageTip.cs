using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageTip : Singleton<MessageTip> {

    //显示文字
    [SerializeField]
    private Text txtContent;
    [SerializeField]
    private GameObject tip;

    // 点击之后的调用
    private Action onCompleted;

    // 显示文字

    public void Show(string text, Action action = null)
    {
        tip.SetActive(true);
        txtContent.text = text;
        onCompleted = action;
    }

    // 点击确定按钮
    public void OnClick()
    {
        tip.SetActive(false);

        if (onCompleted != null)
        {
            onCompleted();
            onCompleted = null;
        }
    }

}
