using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soulController : MonoBehaviour
{
    public enum SPstatus
    {
        soul,
        red,
        blue,
        green
    }
    public SPstatus status;
    public float moveSpeed = 5f;
    public bool facingRight = false;
    float h, v;
    void Start()
    {

    }


    void Update()
    {
        h = Input.GetAxis("Horizontal_Left");
        v = Input.GetAxis("Vertical_Left");
        float t = Input.GetAxis("LRT");
        Vector2 direction = new Vector2(h, v);
        GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }
       
    }

    void OnTriggerEnter2D(Collider2D coll)
    {


    }
    void OnTriggerStay2D(Collider2D coll)
    {


    }

    void OnTriggerExit2D(Collider2D coll)
    {



    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}