using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BallControl : MonoBehaviour
{
    private Rigidbody myRigid;
    public float speed = 1.0f;

    void Start()
    {
        myRigid = this.GetComponent<Rigidbody>();
        myRigid.AddForce((transform.forward) * speed, ForceMode.VelocityChange);

    }

    void Update()
    {

    }
}
