using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour
{
    // Start is called before the first frame update

        public float movespeed = 5f;
        private float vInput;
    // Update is called once per frame
    void Update()
    {
    vInput = Input.GetAxis("Horizontal") * movespeed;
    transform.Translate(Vector3.right * vInput);
        /*if (Input.GetKey(KeyCode.A))
            transform.Translate(-1f, 0f, 0f, Space.World);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(1f, 0f, 0f, Space.World);*/
    }
}
