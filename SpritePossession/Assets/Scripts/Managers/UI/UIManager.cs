using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// UI管理类
public class UIManager : Singleton<UIManager>, IResourceListener
{
    // UI名字和面板的映射关系
    private Dictionary<string, UIBase> nameUIDict = new Dictionary<string, UIBase>();

    // 添加UI
    public void AddUI(UIBase ui)
    {
        if (ui == null)
            return;

        nameUIDict.Add(ui.UIName(), ui);
    }

    // 删除UI
    public void RemoveUI(UIBase ui)
    {
        if (ui == null)
            return;
        if (!nameUIDict.ContainsValue(ui))
            return;

        nameUIDict.Remove(ui.UIName());
    }

    // 显示UI 没有就创建一个
    public void ShowUIPanel(string uiName)
    {
        if (nameUIDict.ContainsKey(uiName))
        {
            UIBase ui = nameUIDict[uiName];
            ui.OnShow();
            return;
        }

        ResourcesManager.Instance.Load(uiName, typeof(GameObject), this);
    }

    public void OnLoaded(string assetName, object asset)
    {
        GameObject uiPrefab = Instantiate(asset as GameObject);
        UIBase ui = uiPrefab.GetComponent<UIBase>();
        ui.OnShow();
        AddUI(ui);
    }

    // 关闭UI

    public void HideUIPanel(string uiName)
    {
        if (!nameUIDict.ContainsKey(uiName))
            return;

        UIBase ui = nameUIDict[uiName];
        ui.OnHide();
        RemoveUI(ui);
    }

}


