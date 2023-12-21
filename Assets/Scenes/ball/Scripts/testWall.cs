using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class testWall : MonoBehaviour
{
    private const string BALL_TAG = "Ball", WALL_TAG = "Wall";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == BALL_TAG)
        {
            //Debug.Log("‚Ô‚Â‚©‚Á‚½");
            stdBall stdBall = collision.gameObject.GetComponent<stdBall>();
            //Debug.Log(stdBall.count);
        }
    }
}
