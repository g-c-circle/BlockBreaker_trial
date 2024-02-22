using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    private const string BLOCK_TAG = "Block";

    public const float STAGE_LIMIT_TOP = 30.5f;
    public const float STAGE_LIMIT_BOTTOM = 0.5f;
    public const float STAGE_LIMIT_LEFT = 0.5f;
    public const float STAGE_LIMIT_RIGHT = 20.5f;
    public float Score = 0;

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
    public float? GetLeftBlockPos(int Num, float Size, float Space, float Left = STAGE_LIMIT_LEFT, float Right = STAGE_LIMIT_RIGHT)
    {
        // 左右と間の余白を含めた全体の横の長さ
        float Length = Num * Size + (Num + 1) * Space;
        float MaxLength = Math.Abs(Right - Left);

        // 入りきらないとき
        if (MaxLength < Length)
        {
            Debug.Log("ブロックの設置範囲が狭すぎます : StageManager.cs");
            return null;
        }

        float Mid = (Right + Left) / 2;
        Debug.Log("Left:" + Left + "Right:" + Right);
        Debug.Log("mid:" + Mid);
        Debug.Log("length/2:" + Length / 2);
        Debug.Log("left:" + (Mid - Length / 2 + Size / 2));

        float LeftEdge = Mid - Length / 2;
        float LeftBlockPos = LeftEdge + Space + Size / 2;

        // 0を中心とした左端のブロックの中心座標を返す
        //return Mid - Length / 2 + Size / 2;
        return LeftBlockPos;
    }

    // 引数の値だけ変わってる
    public float? GetBottomBlockPos(int Num, float Size, float Space, float Top = STAGE_LIMIT_TOP, float Bottom = STAGE_LIMIT_BOTTOM)
    {
        return GetLeftBlockPos(Num, Size, Space, Top, Bottom);
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Blocks = GameObject.FindGameObjectsWithTag(BLOCK_TAG);
        if (Blocks.Length == 0)
            GameObject.Find("Canvas").transform.Find("TextScore").GetComponent<Text>().text = "くりあ";
        else
        {
            GameObject.Find("Canvas").transform.Find("TextScore").GetComponent<Text>().text = ((int)Score).ToString();
            //Debug.Log("のこり" + Blocks.Length);
        }
    }
}
