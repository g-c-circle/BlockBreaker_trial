using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockscript : MonoBehaviour
{
    public GameObject BlockObject;
    // Start is called before the first frame update
    void Start()
    {
        int i, j;
        for (i = -10; i < 20; i = i+5)
        {
            for (j = 0; j < -20; j = j-5)
            {
                Instantiate(BlockObject, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
        
    }

    //ブロックがボールに触れたら作動する関数
    private void OnCollisionEnter(Collision collision)//(ブロックが)何かに触れたら
    {
        if(collision.gameObject.name == "debug(sphere)")//もし、触れたものがボールだったら
        {
            Destroy(gameObject);//ブロック(自分自身)を削除する
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
