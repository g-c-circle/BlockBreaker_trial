using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stdBall : MonoBehaviour
{
    public bool isAutoInit = true;
    public int count = 0;

    private const int MIN = 8, MAX = 16;
    private const string BALL_TAG = "Ball", WALL_TAG = "Wall";
    private Rigidbody rb;

    public void InitSpeed(int min, int max) // 初速がminからmax
    {
        // Random.Rangeは、第一引数 <= return < 第二引数 である
        rb.velocity += Vector3.right * Random.Range(min, max + 1);
        rb.velocity += Vector3.forward * Random.Range(min, max + 1);

        // ランダムに+-を逆転させる
        // AddForceはあくまで物理演算するためのものなので、velocityを直接書き換えていいかも。
        if (System.Convert.ToBoolean(Random.Range(0, 2)))
            rb.velocity = new Vector3(-1 * rb.velocity.x, rb.velocity.y, rb.velocity.z);
        if (System.Convert.ToBoolean(Random.Range(0, 2)))
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -1 * rb.velocity.z);

        // ForceMode.VelocityChange：
        // 質量を無視し、かつ1秒間力をかけた値velocityを変化させる
        // 第二引数を省略すると、0.02秒(1フレーム)だけ力がかかる
        //if (System.Convert.ToBoolean(Random.Range(0, 2)))
        //    rb.AddForce(new Vector3(rb.velocity.x * -2, 0, 0), ForceMode.VelocityChange);
        //if (System.Convert.ToBoolean(Random.Range(0, 2)))
        //    rb.AddForce(new Vector3(0, 0, rb.velocity.z * -2), ForceMode.VelocityChange);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (isAutoInit)
        {
            InitSpeed(MIN, MAX);
        }
    }

    void Update()
    {
        // test
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotate(1);
        }
    }

    // クラスのメンバ変数を直接いじるのはよろしくないらしいので用意した
    // 重くなるようなら直接書き換えよう
    public Vector3 getVelocity()
    {
        return rb.velocity;
    }


    public void changeVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }


    public void addVelocity(float x, float y, float z)
    {
        rb.velocity = new Vector3(rb.velocity.x + x, rb.velocity.y + y, rb.velocity.z + z);
    }

    public void addVelocity(Vector3 vec)
    {
        rb.velocity += vec;
    }


    public void multiplyVelocity(float num)
    {
        rb.velocity *= num;
    }

    public void multiplyVelocity(float x, float y, float z)
    {
        rb.velocity = new Vector3(rb.velocity.x * x, rb.velocity.y * y, rb.velocity.z * z);
    }

    public void multiplyVelocity(Vector3 vec)
    {
        float x = vec.x;
        float y = vec.y;
        float z = vec.z;
        rb.velocity = new Vector3(rb.velocity.x * x, rb.velocity.y * y, rb.velocity.z * z);
    }

    // num回90度回転させる　マイナスも可
    public void rotate(int num)
    {
        // 例えば -7%4 は -3 となるので、まずプラスにする
        while (num < 0)
            num += 4;
        num %= 4;
        // 90度回転
        for (int i = 0; i < num; i++)
            rb.velocity = new Vector3(rb.velocity.z, rb.velocity.y, -rb.velocity.x);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == WALL_TAG)
        {
            Debug.Log("ぶつかった");
            count++;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == WALL_TAG)
        {
            Debug.Log("ぶつかっている");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == WALL_TAG)
        {
            Debug.Log("離れた");
        }
    }
}
