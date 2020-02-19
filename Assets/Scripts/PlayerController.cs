using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    public ParticleSystem Smoke;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    private Animator anim;
    private SpriteRenderer spRender;
    private int counter = 0;

    public float initialRunSpeed;
    private float runSpeed = 8.0f;
    public float sprinkleSpeedBoost = 5f;
    private ParticleSystem.ColorOverLifetimeModule smokeColor;
    ParticleSystem.MinMaxGradient oldGradient;

    void Start()
    {
        spRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

        initialRunSpeed = runSpeed;
        smokeColor = Smoke.colorOverLifetime;
        oldGradient = smokeColor.color;
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
            Smoke.enableEmission = true;
            counter = 0;
        } else
        {
           Smoke.enableEmission = false;
        }


        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void Die()
    {
        gameObject.SetActive(false);
        GameManager.instance.OnPlayerDeath();
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
                    GameManager.instance.BabyCookies -= 1;
                }
            }


        }
        if (collision.gameObject.tag == "Hazards")
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sprinkle")
        {
            // Remove sprinkle
            collision.gameObject.SetActive(false);

            // Speed boost
            runSpeed += sprinkleSpeedBoost;

            // Smoke changes
            Smoke.startLifetime += 0.1f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
            smokeColor.color = gradient;

            // Cooldown
            StartCoroutine(SprinkleCooldown(oldGradient));
        }
    }

    IEnumerator SprinkleCooldown(ParticleSystem.MinMaxGradient oldGradient)
    {
        yield return new WaitForSeconds(5f);
        runSpeed -= sprinkleSpeedBoost;
        Smoke.startLifetime -= 0.1f;

        if (runSpeed == initialRunSpeed)
        {
            var smokeColor = Smoke.colorOverLifetime;
            smokeColor.color = oldGradient;
        }
    }
}
