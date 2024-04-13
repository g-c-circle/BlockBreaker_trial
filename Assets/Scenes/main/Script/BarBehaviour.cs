using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private const float MoveSpeed = 10f;

    private float limitLeft = -9.5f;
    private float limitRight = 9.5f;

    void Start()
    {
        // transform.positionで得られるのはバーの中心の座標だが、
        // 実際にはBarの先端の座標がLIMITを超えてはならないというふうに差異がある。
        // ここでlimitLeft/Rightは、Barの中心座標が取ってよい範囲とする。
        float halfBarLength = transform.localScale.x / 2;
        //StageManager sm = GameObject.Find("StageManager").GetComponent<StageManager>();
        limitLeft = StageManager.StageLimitLeft + halfBarLength;
        limitRight = StageManager.StageLimitRight - halfBarLength;
    }

    void Update()
    {
        float vInput = Input.GetAxis("Horizontal");
        transform.Translate(MoveSpeed * vInput * Time.deltaTime * Vector3.right);

        // ステージ内に戻す
        Vector3 pos = transform.position;
        // Debug.Log(pos.x);
        if (pos.x < limitLeft)
        {
            pos.x = limitLeft;
        }
        else if (limitRight < pos.x)
        {
            pos.x = limitRight;
        }

        transform.position = pos;
    }
}
