using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private Animator anim;
    public Transform target;
    public int speed = 4;
    private Vector3 prevLoc;
    private SpriteRenderer spRender;
    private BoxCollider2D boxCollider;
    private new Rigidbody2D rigidbody;

    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRender = GetComponent<SpriteRenderer>();
        prevLoc = transform.position;
        boxCollider = GetComponent<BoxCollider2D>();
    }


    // 0 idle,,,,, 1 down,,,,,, 2 right,,,,, 3 left,,,,, 4 up
    // Update is called once per frame
    void Update()
    {   
        if (target != null) {
            gameObject.layer = LayerMask.NameToLayer("Collectables");
            boxCollider.isTrigger = false;
            float dist = Vector3.Distance(this.transform.position, target.transform.position);

            if (dist >= 5 && dist <= 15)
            {
                counter = 0;
          
                anim.SetInteger("State", 2);
                rigidbody.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                //Vector3 direction = target.position - transform.position;
                //rigidbody.AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);

                Vector3 currVel = transform.position - prevLoc;
                //moving up
                if (currVel.x * 100000 > 0)
                {

                    if (Mathf.Abs(currVel.x * 100000) > Mathf.Abs(currVel.y * 100000))
                    {
                        spRender.flipX = false;
                        anim.SetInteger("Moving", 2);
                    }
                    else
                    {
                        anim.SetInteger("Moving", 1);
                    }
                }
                else if (currVel.x * 100000 < 0)
                {
                    if (Mathf.Abs(currVel.x * 100000) > Mathf.Abs(currVel.y * 100000))
                    {
                        spRender.flipX = true;
                        anim.SetInteger("Moving", 2);
                    }
                    else
                    {
                        anim.SetInteger("Moving", 1);
                    }
                }
                else if (currVel.y * 100000 < 0)
                {
                    anim.SetInteger("Moving", 1);
                }
                else if (currVel.y * 100000 > 0)
                {
                    anim.SetInteger("Moving", 2);
                }
    
            }


            if (dist >= 15)
            {
                boxCollider.isTrigger = true;
                anim.SetInteger("State", 0);
                anim.SetInteger("Moving", 0);
                gameObject.layer = LayerMask.NameToLayer("Default");
                target = null;
            }

            if (prevLoc == transform.position)
            {
                counter += 1;

                if (counter > 5)
                {
                    anim.SetInteger("Moving", 0);
                }
            }


        }

        prevLoc = transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && target == null)
        {

            GameObject[] objs;
            bool isGood = true;
            objs = GameObject.FindGameObjectsWithTag("BabyCookie");
            foreach (GameObject cookie in objs)
            {
                if (cookie.GetComponent<Collectable>().target != null)
                {
                    isGood = false;
                }
            }

            if (isGood == true)
            {
                anim.SetInteger("State", 1);
                target = collision.transform;
            }

        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazards")
        {
            rigidbody.velocity = new Vector2(0, 0);
            boxCollider.isTrigger = true;
            anim.SetInteger("State", 0);
            anim.SetInteger("Moving", 0);
            gameObject.layer = LayerMask.NameToLayer("Default");
            target = null;
        }
    }



}
