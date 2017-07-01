using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class 光标控制 : MonoBehaviour {
    float h1, h2, v1, v2;
	void Start () {
        Cursor.visible = false;
	}

    public KeyCode getKeyDownCode()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    Debug.Log(keyCode.ToString());
                    return keyCode;
                }
            }
        }
        return KeyCode.None;
    }

    void Update()
    {
        getKeyDownCode();
        float hl = Input.GetAxis("Horizontal_Left");
        float vl = Input.GetAxis("Vertical_Left");
        float x = Input.GetAxis("Xbox +X");
        float y = Input.GetAxis("Xbox +Y");
        float hr = Input.GetAxis("Horizontal_Right");
        float vr = Input.GetAxis("Vertical_Right");
        float t = Input.GetAxis("LRT");
        if (Mathf.Abs(hl) > 0.05f || Mathf.Abs(vl) > 0.05f)
        {
            print("左摇杆leftX:" + hl);
            print("左摇杆leftY:" + vl);
        }

        if (Mathf.Abs(x) > 0.05f || Mathf.Abs(y) > 0.05f)
        {
            print("十字键Xbox +X:" + x);
            print("十字键Xbox +Y:" + y);
        }

        if (Mathf.Abs(hr) > 0.05f || Mathf.Abs(vr) > 0.05f)
        {
            print("右摇杆RightX:" + hr);
            print("右摇杆RightY:" + vr);
        }

        if (Mathf.Abs(t) > 0.05f)
        {
            print("LRT:" + t);
        }

    }
}
