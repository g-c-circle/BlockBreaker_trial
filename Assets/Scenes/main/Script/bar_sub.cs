using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar_sub : bar_inside
{
    override public float append_ball_attack(float def_point)
    {
        return 1.0f;
    }
}
