using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingPin : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private GameObject directionalArrow = null;

    Rigidbody2D rbody;
    Vector2 velocity;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        directionalArrow.SetActive(false);

        float rotationInDegrees = transform.rotation.eulerAngles.z;

        // Set constant velocity based on initatial rotation
        if (Mathf.Approximately(rotationInDegrees, 0.0f))
        {
            velocity = new Vector2(0.0f, speed);
            rbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else if (Mathf.Approximately(rotationInDegrees, 90.0f))
        {
            velocity = new Vector2(-speed, 0.0f);
            rbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        else if (Mathf.Approximately(rotationInDegrees, 180.0f))
        {
            velocity = new Vector2(0.0f, -speed);
            rbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else if (Mathf.Approximately(rotationInDegrees, 270.0f))
        {
            velocity = new Vector2(speed, 0.0f);
            rbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void Update()
    {
        rbody.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") 
            || collision.gameObject.layer == LayerMask.NameToLayer("Collectables"))
        {
            velocity = Vector2.zero;
        }
        else
        {
            // Reverse velocity direction
            velocity = -velocity;
        }
    }
}

