using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour
{
    // Start is called before the first frame update
    private float movespeed = 10f;

    public float vInput;

    public float bx = 0f; //bar's position before colliding wall.

    public bool stay = false; // whether bar is colliding wall.

    public Rigidbody ball;

    public float addspeed = 1.00f;

    private const string WALL_LEFT = "WallLeft";
    private const string WALL_RIGHT = "WallRight";

    private float LimitLeft = -9.5f;
    private float LimitRight = 9.5f;

    void GetLimit()
    {
        // transform.positionで得られるのはバーの中心の座標だが、
        // 実際にはBarの先端の座標がLIMITを超えてはならないというふうに差異がある。
        // ここでLimitLeft/Rightは、Barの中心座標が取ってよい範囲とする。
        float HalfBarLength = transform.localScale.x / 2;
        //StageManager sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        LimitLeft = StageManager.STAGE_LIMIT_LEFT + HalfBarLength;
        LimitRight = StageManager.STAGE_LIMIT_RIGHT - HalfBarLength;
    }

    virtual public void move()
    {
        vInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * vInput * movespeed * Time.deltaTime);

        // ステージ内に戻す
        Vector3 pos = transform.position;
        Debug.Log(pos.x);
        if (pos.x < LimitLeft)
            pos.x = LimitLeft;

        if (LimitRight < pos.x)
            pos.x = LimitRight;

        transform.position = pos;
    }
    void Awake()
    {
        GetLimit();
    }
    // Update is called once per frame
    void Update()
    {
        move();
    }
}
