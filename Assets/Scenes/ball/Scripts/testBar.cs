using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBar : MonoBehaviour
{
    public float limit_left, limit_right;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * 10, 0, 0);
        Transform transform = rb.transform;
        if (limit_left < transform.position.x)
        {
            transform.position = new Vector3(limit_left, 0, 0);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }
}
