using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{

    //adjust this to change speed
    float speed = 5f;
    //adjust this to change how high it goes
    float height = 0.5f;

    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.localPosition;
    }


    void Update()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        transform.localPosition = new Vector3(pos.x, newY + 5, pos.z) * height;
    }
}
