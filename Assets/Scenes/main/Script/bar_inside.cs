using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar_inside : bar
{
    public static bar_inside instance;
    private float ballspeed;
    private float collideposi;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    virtual public float append_ball_attack(float def_point, Collision collision)
    {
        //Debug.Log(def_point);
        return def_point * 1.0f;
    }
    public void OnCollisionEnter(Collision collision)
    {
        //init section.
        float barwidth = gameObject.GetComponent<Renderer>().bounds.size.x;
        float barposition = transform.position.x;
        float ball_attack = collision.gameObject.GetComponent<stdBall>().att;

        if (!stay) stay = true;

        ball = collision.gameObject.GetComponent<Rigidbody>();//all colliding objects regard as ball(s).
        collideposi = (float)ball.position.x - (float)barposition;
        float diffper = collideposi / (barwidth / 2);//-1�`1


        double ballvectorx = Math.Pow((double)ball.velocity.x, 2d);
        double ballvectorz = Math.Pow((double)ball.velocity.z, 2d);
        ballspeed = (float)Math.Sqrt(ballvectorx + ballvectorz);
        //speed = ��(x^2+z^2)

        if (Math.Abs(diffper) > 1)
        {
            ball.velocity = new Vector3(ball.velocity.x * -1, 0, ball.velocity.z);
        }
        else
        {
            ball.velocity = new Vector3(diffper * ballspeed, 0, (float)Math.Sin(Math.Acos((double)diffper)) * ballspeed);
        }

        //Debug.Log("this ball point is "+ball_attack);
        ball_attack = append_ball_attack(ball_attack, collision);
        collision.gameObject.GetComponent<stdBall>().att = ball_attack;
        //Debug.Log(ball_attack+"\n"+collision.gameObject.tag);
    }
}
