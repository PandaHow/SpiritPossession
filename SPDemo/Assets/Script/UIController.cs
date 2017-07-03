using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject skillSquare;
    public GameObject chooseSquare;
    public float moveSpeedSkill;
    public float moveSpeedChoose;
    void Start ()
    {
		
	}
	
	void Update ()
    {
        float t = Input.GetAxis("LRT");
        if (t > 0)
        {
            skillSquare.transform.localPosition = Vector3.MoveTowards(skillSquare.transform.localPosition, new Vector3(0.12f, -2.35f, 0), Time.deltaTime * moveSpeedSkill);
            if (skillSquare.transform.localPosition.y < -2.34f)
            {
                chooseSquare.transform.localPosition = Vector3.MoveTowards(chooseSquare.transform.localPosition, new Vector3(-1.35f, 0.2f, 0), Time.deltaTime * moveSpeedChoose);
            }
        }
        else
        {
            chooseSquare.transform.localPosition = Vector3.MoveTowards(chooseSquare.transform.localPosition, new Vector3(-8f, 0.2f, 0), Time.deltaTime * moveSpeedChoose);
            if(chooseSquare.transform.localPosition.x<-7.8f)
            {
                skillSquare.transform.localPosition = Vector3.MoveTowards(skillSquare.transform.localPosition, new Vector3(0.12f, -0.02f, 0), Time.deltaTime * moveSpeedSkill);
            }
        }
        
    }
}
