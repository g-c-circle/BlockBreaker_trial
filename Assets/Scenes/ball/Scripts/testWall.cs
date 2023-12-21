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

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        //Vector3 velocityNext = Vector3.Reflect(velocity, collision.contacts[0].normal);
        //velocity = velocityNext;

        Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);

        Vector3 reflectDirection = Vector3.Reflect(rb.velocity, hitPos);
        rb.velocity = reflectDirection;


    }
}
