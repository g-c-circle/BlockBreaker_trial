using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stdBall : MonoBehaviour
{
    public bool isAutoInit = true;
    public int countSpeedUp = 0;
    public double BallLevel = 1;

    private const int MIN = 8, MAX = 16;
    private const string BALL_TAG = "Ball", WALL_TAG = "Wall";
    private Rigidbody rb;

    public void InitSpeed(int min, int max) // 初速がminからmax
    {
        // Random.Rangeは、第一引数 <= return < 第二引数 である
        rb.velocity += Vector3.right * Random.Range(min, max + 1);
        rb.velocity += Vector3.forward * Random.Range(min, max + 1);

        // ランダムに+-を逆転させる
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
        countSpeedUp = 0;

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

    public void OnRefrection(string obj) // 仮で決めた引数、ブロックかバーか壁か判定する
    {
        // 当たったとき何か起こる処理を書きたいなら書く
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == WALL_TAG)
        {
            //Debug.Log("ぶつかった");

            //// BALL_TAGを持つもの全てを配列に入れる
            //GameObject[] balls = GameObject.FindGameObjectsWithTag(BALL_TAG);

            //Debug.Log(balls.Length);

            //for (int i = 0; i < balls.Length; i++)
            //{
            //}

            //// 配列の一つ一つがballに入る
            //foreach (GameObject ball in balls)
            //{
            //    stdBall stdBall = ball.gameObject.GetComponent<stdBall>();
            //    stdBall.count++;
            //}
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == WALL_TAG)
        {
            //Debug.Log("ぶつかっている");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == WALL_TAG)
        {
            //Debug.Log("離れた");
        }
    }
}
