using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject x;
    public float speed = 1f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
            x.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        if (Input.GetKeyDown(KeyCode.W))
            x.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
    }
}
