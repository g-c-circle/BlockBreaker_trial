using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar_inside : bar
{
    private float ballspeed;
    private float collideposi;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("refrect");
        float barwidth = gameObject.GetComponent<Renderer>().bounds.size.x;
        float barposition = transform.position.x;
        if (!stay) stay = true;

        ball = collision.gameObject.GetComponent<Rigidbody>();//all colliding objects regard as ball(s).
        collideposi = (float)ball.position.x- (float)barposition;
        float diffper = collideposi / (barwidth / 2);

        double ballvectorx = Math.Pow((double)ball.velocity.x, 2d);
        double ballvectorz = Math.Pow((double)ball.velocity.z, 2d);

        ballspeed = (float)Math.Sqrt(ballvectorx + ballvectorz); //addspeed += 0.001f;
        ball.velocity = new Vector3(diffper * ballspeed, 0, (float)Math.Sin(Math.Acos((double)diffper)) * ballspeed);

    }

    override public void OnTriggerStay(Collider other)
    {
        if (!stay) stay = true;
    }
    override public void OnTriggerExit(Collider other)
    {
        stay = false;
    }
}