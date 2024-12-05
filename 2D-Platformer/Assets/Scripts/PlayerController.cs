using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    Rigidbody2D rb;
    public float jumpForce;
    public float speed;

    //ground check
    public bool isGrounded;

    public GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        //variab;es to mirror the player
        Vector3 newScale = transform.localScale;
        float currentScale = Mathf.Abs(transform.localScale.x); //take absolute value of the current x scale, this is always positive


        if (Input.GetKey("a"))
        {
            newPosition.x -= speed;
            newScale.x = -currentScale;
        }

        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
            newScale.x = currentScale;
        }

        if (Input.GetKey("w") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        transform.position = newPosition;
        transform.localScale = newScale;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = true;
        }

        if(collision.gameObject.tag.Equals("Box"))
        {
            isGrounded = true;
        }

        if(collision.gameObject.tag.Equals("Coin"))
        {
            //score goes up
            gm.score++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Goal"))
        {
            //Go to Goal Screen
            SceneManager.LoadScene("GoalScreen");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Ground"))
        {
            isGrounded = false;
        }

        if(collision.gameObject.tag.Equals("Box"))
        {
            isGrounded = false;
        }
    }

}
