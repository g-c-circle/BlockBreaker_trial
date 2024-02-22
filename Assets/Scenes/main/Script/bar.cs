using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed = 1f;

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
        // 実際にはBarの先端の座標がLIMITを超えてはならない。
        // なのでLimitは、Barの中心座標が取ってよい範囲とする。
        float HalfBarLength = transform.localScale.x / 2;
        //StageManager sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        LimitLeft = StageManager.STAGE_LIMIT_LEFT + HalfBarLength;
        LimitRight = StageManager.STAGE_LIMIT_RIGHT - HalfBarLength;
    }

    //{    void back_before_stay()
    //    {

    //        if (!stay) stay = true;

    //        transform.position = new Vector3(bx, 0f, -7.5f);
    //    }

    //virtual public void OnTriggerStay(Collider other)
    //{

    //    back_before_stay();

    //}
    //virtual public void OnTriggerEnter(Collider collider)
    //{
    //    back_before_stay();

    //    ball = collider.gameObject.GetComponent<Rigidbody>();

    //    //addspeed += 0.001f;

    //    //ball.velocity = new Vector3(addspeed * ball.velocity.x, 0, (ball.velocity.z * -1) * addspeed);

    //}

    //virtual public void OnTriggerExit(Collider other)
    //{

    //    stay = false;
    //}

    virtual public void move()
    {
        //if (!stay)
        //{
        //    bx = transform.position.x;//recorting bar x position that bar does't colliding to wall.
        //}
        vInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * vInput * movespeed * Time.deltaTime);

        // ステージ内に戻す
        Vector3 pos = transform.position;
        //Debug.Log(pos.x);
        if (pos.x < LimitLeft)
            pos.x = LimitLeft;

        if (LimitRight < pos.x)
            pos.x = LimitRight;

        transform.position = pos;
    }

    void Start()
    {
        GetLimit();
    }
    // Update is called once per frame
    void Update()
    {
        move();
    }
}
