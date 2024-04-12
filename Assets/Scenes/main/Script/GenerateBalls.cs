using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBalls : MonoBehaviour
{
    public GameObject ballPrefab;
    public int maxBallNum;
    public float generateSpeed;

    private int generatedBallNum = 0;
    private float time = 0;

    //void Start()
    //{
    //}

    void Update()
    {
        if (generatedBallNum < maxBallNum)
        {
            Generate();
        }
    }

    private void Generate()
    {
        time += Time.deltaTime;
        if (time < generateSpeed)
            return;

        // ボールのインスタンスを作成
        GameObject ball = Instantiate(ballPrefab, new Vector3(20.5f, 0, 15.5f), Quaternion.identity);
        BallBehaviour ballScript = ball.GetComponent<BallBehaviour>();
        ballScript.ballLevel = 1;
        ballScript.InitSpeed();

        generatedBallNum++;
        time = 0;
    }
}
