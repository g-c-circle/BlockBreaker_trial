using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar_sub : bar_inside
{
    private static float this_longness;
    private static float this_position;
    private static float this_top;
    private static float this_bottom;
    private static float MAX;
    private float attackp;
    private float ballposition;

    void Start() {
    this_longness = this.transform.localScale.z;
    this_position = this.transform.position.z;
    this_top = this_position + this_longness / 2;
    this_bottom = this_position - this_longness / 2;
    MAX = 3.0f;
    }

    override public float append_ball_attack(float def_point,Collision collision)
    {

        ballposition = collision.transform.position.z-collision.transform.localScale.z/2;
        //Debug.Log("ballposi\n" + ballposition);
        if (ballposition > this_top||this_bottom>ballposition){
            Debug.Log("outside ball");
            return def_point * 1f;
        }
        //Debug.Log("calc\n"+ (ballposition - this_bottom) / this_longness );
        attackp = (1 - (ballposition - this_bottom)/this_longness )*MAX+1;
        attackp = (float)Math.Round((double)attackp, 1);
        //Debug.Log("return                             " + attackp);
        return attackp*def_point;
    }
}
