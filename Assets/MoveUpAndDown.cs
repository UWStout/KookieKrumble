using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{

    //Adjusts speed of arrow
    float speed = 5f;
    //Deciding how high the arrow goes
    float height = 0.5f;

    Vector3 pos;
    void Start()
    {
        //Use local position because the arrow is a child of the cookie jar
        pos = transform.localPosition;
    }

    void Update()
    {
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.localPosition = new Vector3(pos.x, newY + 5, pos.z) * height;
    }
}
