using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cookiePlayer;
    public int distanceBack = 10;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(cookiePlayer.position.x, cookiePlayer.position.y, cookiePlayer.position.z - distanceBack);
    }
}
