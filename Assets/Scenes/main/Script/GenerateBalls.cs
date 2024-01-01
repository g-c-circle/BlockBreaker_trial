using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBalls : MonoBehaviour
{
    public GameObject ballPrefab;
    public int ballNum;
    public float generateSpeed;

    private int generatedBallNum = 0;
    private float deltaTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        // stdBallを編集する例 一度変えるとunity上のチェックボックスが書き換わるので注意
        //stdBall cs = ballPrefab.GetComponent<stdBall>();
        //cs.isAutoInit = false;
        //cs.InitSpeed(5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (generatedBallNum < ballNum)
        {
            Generate();
        }
    }

    private void Generate()
    {
        deltaTime += Time.deltaTime;
        //Debug.Log(deltaTime + ", " + generateSpeed + "," + (deltaTime < generateSpeed));
        if (deltaTime < generateSpeed)
            return;

        // ボールのインスタンスを作成
        Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        generatedBallNum++;
        deltaTime = 0;
    }
}
