using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI的基类

public abstract class UIBase : MonoBehaviour
{
    // 名称
    public abstract string UIName();

    protected CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = gameObject.AddComponent<CanvasGroup>();

        Init();
    }

    // 初始化
    public abstract void Init();
    
    // 显示
    public virtual void OnShow()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    // 隐藏
    public virtual void OnHide()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    // 销毁
    public abstract void OnDestroy();


}
