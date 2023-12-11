using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stdBall : MonoBehaviour
{
    public bool isAutoInit = true;
    private const int MIN = 8, MAX = 16;
    private const string BALL_TAG = "Ball", WALL_TAG = "Wall";
    public void InitSpeed(int min, int max)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Random.Rangeは、第一引数 <= return < 第二引数 である
        rb.velocity += Vector3.right * Random.Range(min, max + 1);
        rb.velocity += Vector3.forward * Random.Range(min, max + 1);

        // ランダムに+-を逆転させる
        // ForceMode.VelocityChange：
        // 質量を無視し、かつ1秒間力をかけた値velocityを変化させる
        // 引数を省略すると、0.02秒(1フレーム)だけ力がかかる
        if (System.Convert.ToBoolean(Random.Range(0, 2)))
            rb.AddForce(new Vector3(rb.velocity.x * -2, 0, 0), ForceMode.VelocityChange);
        if (System.Convert.ToBoolean(Random.Range(0, 2)))
            rb.AddForce(new Vector3(0, 0, rb.velocity.z * -2), ForceMode.VelocityChange);
    }
    void Start()
    {
        if (isAutoInit)
        {
            InitSpeed(MIN, MAX);
        }
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("ぶつかった");
            //Rigidbody rb = GetComponent<Rigidbody>();
            //rb.AddForce(rb.velocity += new Vector3(rb.velocity.x / rb.velocity.x * 10, 0, 0), ForceMode.VelocityChange);
            //Debug.Log(new Vector3(rb.velocity.x / rb.velocity.x * 10, 0, 0) + "," + rb.velocity);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("ぶつかっている");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("離れた");
        }
    }
}
