using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar_sub : MonoBehaviour
{
    public GameObject subbar;
    private float time;
    void Update()
    {
        time = Time.deltaTime;
        if (Input.GetKey(KeyCode.Return))
        {
            Instantiate(subbar, new Vector3(0, 0, -5), Quaternion.identity);
        }
        if (time > 0.2f){
            Destroy(subbar);
        }
    }
}