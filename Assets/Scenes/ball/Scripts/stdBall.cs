using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stdBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity += Vector3.right * Random.Range(0, 8);
        rb.velocity += Vector3.forward * Random.Range(0, 8);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
