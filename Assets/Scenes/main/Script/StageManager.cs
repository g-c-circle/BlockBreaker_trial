using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    private const string BlockTag = "Block";

    public const float StageLimitTop = 30.5f;
    public const float StageLimitBottom = 0.5f;
    public const float StageLimitLeft = 0.5f;
    public const float StageLimitRight = 40.5f;

    public float inGameTime = 0;
    public float Score = 0;

    public bool isPlaying = true;

    void Start()
    {
        inGameTime = 0;
        isPlaying = true;
    }

    void Update()
    {
        if (!isPlaying) return;

        inGameTime += Time.deltaTime;

        // クリアしているかどうか
        GameObject[] blocks = GameObject.FindGameObjectsWithTag(BlockTag);
        if (blocks.Length == 0)
        {
            GameObject.Find("Canvas").transform.Find("TextScore").GetComponent<Text>().text = "クリア：" + Score.ToString() + "点"; isPlaying = false;
        }
        else
        {
            GameObject.Find("Canvas").transform.Find("TextScore").GetComponent<Text>().text = ((int)Score).ToString();
            GameObject.Find("Canvas").transform.Find("TextTime").GetComponent<Text>().text = ((int)inGameTime).ToString();
        }
    }

    // float? : null許容型のfloat
    // floatが取りうる全ての値と、nullが入る（floatにnullは入らない）
    // float?型をfloat型に代入することはできないので、

    // float value;
    // float? temp_value = GetLeftBlockPos(0,0,0);
    // if(temp_value == null){
    //     return;
    // }
    // value = (float)temp_value;

    // のようにキャストして使う
    // nullを弾かずに直接使うとnullだった時に実行時エラーとなるので、nullかどうかの判定をすること。

    // 等間隔にブロックを設置したい場合
    public float? GetLeftBlockPos(int num, float size, float space, float left = StageLimitLeft, float right = StageLimitRight)
    {
        // 左右と間の余白を含めた全体の横の長さ
        float length = num * size + (num + 1) * space;
        float maxLength = Math.Abs(right - left);

        // 入りきらないとき
        if (maxLength < length)
        {
            Debug.Log($"ブロックの設置範囲が狭すぎます : StageManager.cs\nnum:{num}, size:{size}, space:{space}, left:{left}, right:{right}");
            return null;
        }

        float mid = (right + left) / 2;
        //Debug.Log("left:" + left + "right:" + right);
        //Debug.Log("mid:" + mid);
        //Debug.Log("length/2:" + length / 2);
        //Debug.Log("left:" + (mid - length / 2 + size / 2));

        float leftEdge = mid - length / 2;
        float leftBlockPos = leftEdge + space + size / 2;

        // 0を中心とした左端のブロックの中心座標を返す
        //return mid - length / 2 + size / 2;
        return leftBlockPos;
    }

    // 引数の値だけ変わってる
    public float? GetBottomBlockPos(int num, float size, float space, float top = StageLimitTop, float bottom = StageLimitBottom)
    {
        return GetLeftBlockPos(num, size, space, top, bottom);
    }
}
