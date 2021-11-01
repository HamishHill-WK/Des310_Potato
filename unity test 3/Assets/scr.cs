using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr : MonoBehaviour
{
    public Rigidbody2D rb;
    public float move = 0f;
    public float speed = 20f;
    bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal Movement 
        //Left
        move = Input.GetAxis("Horizontal");
        if (move > 0 && !facingRight)
            Flip();

        //Right
        if (move < 0 && facingRight)
            Flip();
        
    }

    void FixedUpdate()
    {
        //apply velocity to actor
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

//blair was here