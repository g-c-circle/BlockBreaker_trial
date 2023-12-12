using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
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
                Vector3 currentVelocity = ballRb.velocity;
                Vector3 reflection = Vector3.Reflect(currentVelocity, collision.contacts[0].normal);
                //ballRb.velocity = reflection;
                reflection.y = currentVelocity.y;
                ballRb.velocity = reflection * 2.0f;
            }
        }


    }
    
    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                //Vector3 currentVelocity = ballRb.velocity;
                Vector3 forceDirection = transform.position - collision.contacts[0].point;
                //ballRb.velocity = reflection;
                //reflection.y = currentVelocity.y;
                ballRb.AddForce(forceDirection * 100f, ForceMode.Force);
            }
        }


    }
    */




}
