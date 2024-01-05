using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float reflectSpeed = 1.0f;
    public float maxSpeedUps = 3;
    public float speedUpCount = 0;
    //public bool isColliding = false;サンプル３
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                /*
                Vector3 currentVelocity = ballRb.velocity;
                Vector3 reflection = Vector3.Reflect(currentVelocity, collision.contacts[0].normal).normalized * reflectSpeed;
                */

                //ballRb.velocity = reflection;
                //reflection.y = currentVelocity.y;
                // ballRb.velocity = reflection;


                //これかサンプル1
                if (speedUpCount < maxSpeedUps)
                {
                    ballRb.velocity *= reflectSpeed;
                    Vector3 reflection = Vector3.Reflect(ballRb.velocity, collision.contacts[0].normal).normalized;
                    ballRb.AddForce(reflection * reflectSpeed, ForceMode.Impulse);
                    speedUpCount++;
                }


                /*これサンプル2
                if (speedUpCount < maxSpeedUps)
                {
                    Vector3 reflection = Vector3.Reflect(ballRb.velocity, collision.contacts[0].normal).normalized;
                    ballRb.velocity = reflection * reflectSpeed * ballRb.velocity.magnitude;
                    speedUpCount++;
                }*/


            }
        }


    }

    /*void OnCollisionExit(Collision collision)サンプル3
     {
         if (collision.gameObject.CompareTag("Ball"))
         {
             isColliding = false;
         }
     }

     void OnCollisionEnter(Collision collision)
     {


         if (!isColliding && collision.gameObject.CompareTag("Ball"))
         {
             isColliding = true;

             Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
             if (ballRb != null)
             {
                 if (speedUpCount < maxSpeedUps)
                 {
                     ballRb.velocity *= reflectSpeed;
                     Vector3 reflection = Vector3.Reflect(ballRb.velocity, collision.contacts[0].normal).normalized;
                     ballRb.AddForce(reflection * reflectSpeed, ForceMode.Impulse);
                     speedUpCount++;
                 }
             }
         }
     }*/
}
