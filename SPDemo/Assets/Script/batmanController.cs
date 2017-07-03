using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batmanController : MonoBehaviour {

    public GameObject aimSquare;
    public GameObject aimTriangle;
    float t;
    public float speed = 5f;
    public float scalee=1.4f;
    public bool isAttached = false;
    AnimatorStateInfo aaaa;
    void Start () {
		
	}
	
	void Update () {
        t = Input.GetAxis("LRT");
        if (isAttached)
        {
            attachAnim();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="soul")
        {
            aimSquare.SetActive(true);
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (t < 0)
        {
            if (col.tag == "soul")
        {
            
                isAttached = true;
                col.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "soul")
        {
            aimSquare.SetActive(false);
        }
    }

    void attachAnim()
    {
        aimTriangle.SetActive(true);
        aimSquare.SetActive(true);
        GetComponent<Animator>().enabled = true;
        aaaa = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (aaaa.normalizedTime>2)
        {
            GetComponent<Animator>().enabled = false;
            transform.localScale = new Vector3(scalee, scalee, scalee);
            aimTriangle.SetActive(false);
            aimSquare.SetActive(false);
            GetComponent<soulController>().enabled = true;
            GetComponent<batmanController>().enabled = false;
            isAttached = false;
        }
    }
}
