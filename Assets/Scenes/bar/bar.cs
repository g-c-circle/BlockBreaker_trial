using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed = 50f;
    public float v = 10f;
    private float vInput;
    public float bx=0f;
    public bool stay=false;
    public Rigidbody ball;
    private float balls = 1.01f;
    void OnTriggerStay(Collider other) {
        if (!stay) stay = true;
            transform.position= new Vector3(bx, 0f, 0f);
        Debug.Log("stay");
      
    }
    void OnTriggerEnter(Collider collider){ 
        if (!stay) stay = true;
        transform.position = new Vector3(bx, 0f, 0f);
        ball = collider.gameObject.GetComponent<Rigidbody>();
        Debug.Log(ball.velocity);
        balls += 0.001f;
        Debug.Log(balls);
        ball.velocity = new Vector3(balls*ball.velocity.x,(ball.velocity.y*-1)*balls, 0);
        //ball.velocity = new Vector3(ball.velocity.x*1.01f, (ball.velocity.y * -1) * 1.01f,0);
        Debug.Log(ball.velocity);
    }
    void OnTriggerExit(Collider other){
        stay = false;
        //Debug.Log("exit");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!stay){
            bx = transform.position.x;
           // Debug.Log(bx);
        }
    vInput = Input.GetAxis("Horizontal")*v;
       // Debug.Log(vInput*Time.deltaTime);
    transform.Translate(Vector3.right*vInput*movespeed*Time.deltaTime);

        /*if (Input.GetKey(KeyCode.A))
            transform.Translate(-1f, 0f, 0f, Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(1f, 0f, 0f, Space.World);*/
    }
}
