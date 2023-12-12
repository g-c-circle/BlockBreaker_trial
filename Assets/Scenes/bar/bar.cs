using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed = 0.0002f;
    public float v = 10f;
    private float vInput;
    public float bx=0f;
    public bool stay=false;
    void OnTriggerStay(Collider other) {
        if (!stay) stay = true;
            transform.position= new Vector3(bx, 0f, 0f);
        Debug.Log("stay");
    }
    void OnTriggerEnter(Collider collider) {
        if (!stay) stay = true;
        transform.position = new Vector3(bx, 0f, 0f);
        //Debug.Log("ent");
    }
    void OnTriggerExit(Collider other) {
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
    vInput = Input.GetAxis("Horizontal")*movespeed;
       // Debug.Log(vInput*Time.deltaTime);
    transform.Translate(Vector3.right*vInput*v*Time.deltaTime);

        /*if (Input.GetKey(KeyCode.A))
            transform.Translate(-1f, 0f, 0f, Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(1f, 0f, 0f, Space.World);*/
    }
}
