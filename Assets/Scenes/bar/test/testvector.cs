using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testvector : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {  
        rb = GetComponent<Rigidbody>();
        Rigidbody br = this.gameObject.GetComponent<Rigidbody>();
        br.AddForce(new Vector3(-300f, -125f, 0));

    }
    

    // Update is called once per frame
    void Update()
    {

    }
}
