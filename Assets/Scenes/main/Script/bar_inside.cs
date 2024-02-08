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
          private float barposition = bardetaill.position.x;
        if (!stay) stay = true;

        ball = collider.gameObject.GetComponent<Rigidbody>();//all colliding objects regard as ball(s).
        collideposi = (float) barposition.position.x - (float) ball.position.x;

        private double ballvectorx = Math.Pow((double) ball.velocity.x,2d);
        private double ballvectory = Math.Pow((double) ball.velolcity.y,2d);

        ballspeed = (float) Math.Sqrt(ballvectorx + ballvectory); //addspeed += 0.001f;
        ball.velocity = new Vector3(addspeed* -ball.velocity.x, 0, ball.velocity.z* addspeed);

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