using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 按键显示 : MonoBehaviour {
    public GameObject btnA;
    public GameObject btnB;
    public GameObject btnY;
    public GameObject btnX;
    public GameObject btnL1;
    public GameObject btnL2;
    public GameObject btnR1;
    public GameObject btnR2;
    public GameObject btnUp;
    public GameObject btnDown;
    public GameObject btnRight;
    public GameObject btnLeft;

	void Start () {
        
    }
	
	void Update () {
        float t = Input.GetAxis("LRT");
        float h1 = Input.GetAxis("Horizontal_Left");
        float v1 = Input.GetAxis("Vertical_Left");
        float x = Input.GetAxis("Xbox +X");
        float y = Input.GetAxis("Xbox +Y");

        if (x > 0 || h1 > 0)
            btnRight.SetActive(true);
        else
            btnRight.SetActive(false);
        if (x < 0 || h1 < 0)
            btnLeft.SetActive(true);
        else
            btnLeft.SetActive(false);
        if (y > 0 || v1 > 0)
            btnUp.SetActive(true);
        else
            btnUp.SetActive(false);
        if (y < 0 || v1 < 0)
            btnDown.SetActive(true);
        else
            btnDown.SetActive(false);
        if (t>0)
            btnL2.SetActive(true);
        else
            btnL2.SetActive(false);
        if (t < 0)
            btnR2.SetActive(true);
        else
            btnR2.SetActive(false);
        if(Input.GetKey(KeyCode.Joystick1Button0))
            btnA.SetActive(true);
        else
            btnA.SetActive(false);
        if (Input.GetKey(KeyCode.Joystick1Button1))
            btnB.SetActive(true);
        else
            btnB.SetActive(false);
        if (Input.GetKey(KeyCode.Joystick1Button2))
            btnX.SetActive(true);
        else
            btnX.SetActive(false);
        if (Input.GetKey(KeyCode.Joystick1Button3))
            btnY.SetActive(true);
        else
            btnY.SetActive(false);
        if (Input.GetKey(KeyCode.Joystick1Button4))
            btnL1.SetActive(true);
        else
            btnL1.SetActive(false);
        if (Input.GetKey(KeyCode.Joystick1Button5))
            btnR1.SetActive(true);
        else
            btnR1.SetActive(false);
    }
}
