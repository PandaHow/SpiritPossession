using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paths : MonoBehaviour
{
    /// <summary> 声音暂时没用 最后才管声音
    /// UI声音资源路径
    /// </summary>
    public const string RES_SOUND_UI = "Sound/UI/";

    /// <summary>
    /// 获取UI声音资源全路径
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetSoundFullName(string name)
    {
        return RES_SOUND_UI + name;
    }

    /// <summary>
    /// UI的路径
    /// </summary>
    public const string RES_UI = "UI/";
}
