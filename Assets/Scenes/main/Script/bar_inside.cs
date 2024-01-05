using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar_inside : bar
{
    override public void OnTriggerEnter(Collider collider)
    {
        if (!stay) stay = true;
        ball = collider.gameObject.GetComponent<Rigidbody>();//all colliding objects regard as ball(s).
        addspeed += 0.001f;
        ball.velocity = new Vector3(addspeed * -ball.velocity.x, 0, ball.velocity.z * addspeed);
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