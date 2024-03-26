using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedBlockCount : MonoBehaviour
{
    public int destroyedBlockCount = 0; // 破壊されたブロック数
    public int SumHitCount = 0;
    public int totalBlocks = 0; // 全体のブロック数

    private float timer = 0f;
    public float interval = 2f; // 2秒ごとに動作させたい場合


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            //Debug.Log("DestroyBlock" + destroyedBlockCount);
            //Debug.Log("HitCount" + SumHitCount);
            //Debug.Log("TotalBlock" + totalBlocks);

            timer = 0f; // タイマーリセット
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            destroyedBlockCount = 0;
            SumHitCount = 0;
            totalBlocks = 0;
        }
    }
}
