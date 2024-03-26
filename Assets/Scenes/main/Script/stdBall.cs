using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stdBall : MonoBehaviour
{
    public bool isAutoInit = true;
    public int countSpeedUp = 0;
    public float att = 1.1f;
    public double BallLevel = 1;
    private const int MIN = 8, MAX = 16;
    private const string BALL_TAG = "Ball", WALL_TAG = "Wall";
    private Rigidbody rb;

    public void InitSpeed(int min, int max) // ������min����max
    {
        // Random.Range�́A������ <= return < ������ �ł���
        rb.velocity += Vector3.right * Random.Range(min, max + 1);
        rb.velocity += Vector3.forward * Random.Range(min, max + 1);

        // �����_����+-���t�]������
        if (System.Convert.ToBoolean(Random.Range(0, 2)))
            rb.velocity = new Vector3(-1 * rb.velocity.x, rb.velocity.y, rb.velocity.z);
        if (System.Convert.ToBoolean(Random.Range(0, 2)))
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -1 * rb.velocity.z);

        // ForceMode.VelocityChange�F
        // ���ʂ𖳎����A����1�b�ԗ͂��������lvelocity��ω�������
        // ���������ȗ�����ƁA0.02�b(1�t���[��)�����͂�������
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

    // �N���X�̃����o�ϐ��𒼐ڂ�����̂͂�낵���Ȃ��炵���̂ŗp�ӂ���
    // �d���Ȃ�悤�Ȃ璼�ڏ��������悤
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

    // num��90�x��]������@�}�C�i�X����
    public void rotate(int num)
    {
        // �Ⴆ�� -7%4 �� -3 �ƂȂ�̂ŁA�܂��v���X�ɂ���
        while (num < 0)
            num += 4;
        num %= 4;
        // 90�x��]
        for (int i = 0; i < num; i++)
            rb.velocity = new Vector3(rb.velocity.z, rb.velocity.y, -rb.velocity.x);
    }

    public void OnRefrection(string obj) // ���Ō��߂������A�u���b�N���o�[���ǂ����肷��
    {
        // ���������Ƃ������N���鏈�������������Ȃ珑��
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == WALL_TAG)
        {
            //Debug.Log("�Ԃ�����");

            //// BALL_TAG�������̑S�Ă�z��ɓ����
            //GameObject[] balls = GameObject.FindGameObjectsWithTag(BALL_TAG);

            //Debug.Log(balls.Length);

            //for (int i = 0; i < balls.Length; i++)
            //{
            //}

            //// �z��̈���ball�ɓ���
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
            //Debug.Log("�Ԃ����Ă���");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == WALL_TAG)
        {
            //Debug.Log("���ꂽ");
        }
    }
}
