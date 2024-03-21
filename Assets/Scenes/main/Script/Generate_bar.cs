using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Generate_bar : MonoBehaviour
{
    public GameObject subbar;//生成するバー
    public GameObject tmpsubbar;//削除用生成するバー
    private GameObject mainbar;
    private bool flag=false;
    private float time;

    public IEnumerator emarge_bar()
    {
        mainbar = GameObject.Find("Cube");
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                tmpsubbar = Instantiate(subbar, new Vector3(mainbar.transform.position.x, 0, mainbar.transform.position.z+subbar.transform.localScale.z/2), Quaternion.identity) as GameObject;
                flag = true;
                yield return new WaitForSeconds(0.2f);
            }

            if (flag)
            {
                Debug.Log("dest");
                Destroy(tmpsubbar);
                flag = false;
            }
            //yield return new WaitForSeconds(0.1f);
            yield return new WaitForSeconds(0.0f);
        }
    }
    void Start() 
    { 
        StartCoroutine(emarge_bar());
    }
    void Update()
    {
    }
}