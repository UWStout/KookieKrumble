using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefMove : MonoBehaviour
{

    private Animator anim;
    public Vector2 target;
    public Vector2 startPos;
    private Vector2 CurrentTarget;
    public int speed = 4;
    private Vector3 prevLoc;
    private SpriteRenderer spRender;
    private BoxCollider2D boxCollider;
    private new Rigidbody2D rigidbody;

    private bool MovingToTarget = true;

    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTarget = target;
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
        if (CurrentTarget != null)
        {
            float dist = Vector2.Distance(this.transform.position, CurrentTarget);

            if (dist > 0.5)
            {
                counter = 0;

                anim.SetInteger("State", 2);
                rigidbody.position = Vector2.MoveTowards(transform.position, CurrentTarget, speed * Time.deltaTime);

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
            } else
            {
                if (MovingToTarget == true)
                {
                    CurrentTarget = startPos;
                    MovingToTarget = false;
                } else
                {
                    CurrentTarget = target;
                    MovingToTarget = true;
                }
            }

        }

        prevLoc = transform.position;
    }



}
