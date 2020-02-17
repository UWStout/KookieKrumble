using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    private Animator anim;
    private SpriteRenderer spRender;
    private int counter = 0;

    public float runSpeed = 20.0f;

    void Start()
    {
        spRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (horizontal > 0)
        {
            spRender.flipX = false;
            anim.SetInteger("Moving", 2);
        }
        else if (horizontal < 0)
        {
            spRender.flipX = true;
            anim.SetInteger("Moving", 2);
        }
        else if (vertical < 0)
        {
            anim.SetInteger("Moving", 1);
        }
        else if (vertical > 0)
        {
            anim.SetInteger("Moving", 2);
        }
        else
        {
            counter += 1;

            if (counter > 5)
            {
                anim.SetInteger("Moving", 0);
            }
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        if (horizontal != 0 || vertical != 0)
        {
            counter = 0;
        }


        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CookieJars")
        {
            print("Collision");
            GameObject[] objs;
            objs = GameObject.FindGameObjectsWithTag("BabyCookie");
            foreach (GameObject cookie in objs)
            {
                if (cookie.GetComponent<Collectable>().target != null)
                {
                    Destroy(cookie);
                    GameObject.Find("GameRunner").GetComponent<GameRunner>().BabyCookies -= 1;
                }
            }


        }
        if (collision.gameObject.tag == "Hazard")
        {
            print("Hazard Collision");

            Die();
        }
    }
}
