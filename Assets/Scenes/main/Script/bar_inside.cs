using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar_inside : bar
{
    private float ballspeed;
    private float collideposi;
    private Transform bardetaill;
    override public void OnTriggerEnter(Collider collider)
    {
        float barwidth = gameObject.GetComponent<Renderer>().bounds.size.x;        
        float barposition = bardetaill.position.x;
        if (!stay) stay = true;

        ball = collider.gameObject.GetComponent<Rigidbody>();//all colliding objects regard as ball(s).
        collideposi = (float) barposition- (float) ball.position.x;
        float diffper = collideposi / (barwidth / 2);

        double ballvectorx = Math.Pow((double) ball.velocity.x,2d);
        double ballvectorz = Math.Pow((double) ball.velocity.z,2d);

        ballspeed = (float) Math.Sqrt(ballvectorx + ballvectorz); //addspeed += 0.001f;
        ball.velocity = new Vector3((1-diffper)*ballspeed, 0, Math.Abs(diffper) * ballspeed);

    }

    override public void OnTriggerStay(Collider other)
    {
        if (!stay) stay = true;
    }
    override public void OnTriggerExit(Collider other)
    {
        stay = false;
    }
    override public void move()
    {
        //this overriden objects move without a script.
    }
}