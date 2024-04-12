using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public int countSpeedUp = 0;
    public float ballLevel = 1;

    public const int Min = 6, Max = 8;
    public Rigidbody rb;

    public void InitSpeed(int min = Min, int max = Max) // 初速がminからmaxの間
    {
        //rb = GetComponent<Rigidbody>();
        // Random.Rangeは、第一引数 <= return < 第二引数 である
        rb.velocity += Vector3.right * Random.Range(min, max + 1);
        rb.velocity += Vector3.forward * Random.Range(min, max + 1);

        // ランダムに+-を逆転させる
        if (System.Convert.ToBoolean(Random.Range(0, 2)))
            rb.velocity = new Vector3(-1 * rb.velocity.x, rb.velocity.y, rb.velocity.z);
        if (System.Convert.ToBoolean(Random.Range(0, 2)))
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -1 * rb.velocity.z);
    }

    // void Start()だと、以下のコードが実行時エラーとなる
    // 1. GameObject ball = Instantiate(ballPrefab, new Vector3(20.5f, 0, 15.5f), Quaternion.identity);
    // 2. BallBehaviour ballScript = ball.GetComponent<BallBehaviour>();
    // 3. ballScript.InitSpeed();
    // Startだとrb = GetComponent<>()のタイミングが遅くなるためである。
    // Startはフレーム更新のタイミング（Updateの直前）に呼び出される。
    // Awakeはインスタンス化された瞬間に呼び出される。
    // Awakeなら1.と2.の間で呼び出されるため、rb = GetComponent<>()が実行される。
    // ちょっと違うけど面白い記事：https://dkrevel.com/unity-explain/how-to-call-start-awake-onenable/
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        countSpeedUp = 0;
    }

    //void Update()
    //{
    //}

    private void OnCollisionEnter(Collision collision)
    {
        StageManager sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        if (sm == null)
        {
            Debug.Log("Failed to find StageManager");
            return;
        }

        if (collision.gameObject.tag == "Block")
        {
            sm.Score += 1;
        }
    }
}
