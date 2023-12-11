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
        // stdBall��ҏW����� ��x�ς���Ɠ����I�ɒl���ێ��������ۂ��H�g��Ȃ������悳����
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
        Debug.Log(deltaTime + ", " + generateSpeed + "," + (deltaTime < generateSpeed));
        if (deltaTime < generateSpeed)
            return;
        Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        generatedBallNum++;
        deltaTime = 0;
    }
}
