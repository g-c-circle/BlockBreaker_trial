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

    // float? : null���e�^��float
    // float����肤��S�Ă̒l�ƁAnull������ifloat��null�͓���Ȃ��j
    // float?�^��float�^�ɑ�����邱�Ƃ͂ł��Ȃ��̂ŁA

    // float value;
    // float? temp_value = GetLeftBlockPos(0,0,0);
    // if(temp_value == null){
    //     return;
    // }
    // value = (float)temp_value;

    // �̂悤�ɃL���X�g���Ďg��
    // null��e�����ɒ��ڎg����null���������Ɏ��s���G���[�ƂȂ�̂ŁAnull���ǂ����̔�������邱�ƁB
    public float? GetLeftBlockPos(int Num, float Size, float Space, float Left = STAGE_LIMIT_LEFT, float Right = STAGE_LIMIT_RIGHT)
    {
        // ���E�ƊԂ̗]�����܂߂��S�̂̉��̒���
        float Length = Num * Size + (Num + 1) * Space;
        float MaxLength = Math.Abs(Right - Left);

        // ���肫��Ȃ��Ƃ�
        if (MaxLength < Length)
        {
            Debug.Log("�u���b�N�̐ݒu�͈͂��������܂� : StageManager.cs");
            return null;
        }

        float Mid = (Right + Left) / 2;
        Debug.Log("Left:" + Left + "Right:" + Right);
        Debug.Log("mid:" + Mid);
        Debug.Log("length/2:" + Length / 2);
        Debug.Log("left:" + (Mid - Length / 2 + Size / 2));

        float LeftEdge = Mid - Length / 2;
        float LeftBlockPos = LeftEdge + Space + Size / 2;

        // 0�𒆐S�Ƃ������[�̃u���b�N�̒��S���W��Ԃ�
        //return Mid - Length / 2 + Size / 2;
        return LeftBlockPos;
    }

    // �����̒l�����ς���Ă�
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
            GameObject.Find("Canvas").transform.Find("TextScore").GetComponent<Text>().text = "���肠";
        else
        {
            GameObject.Find("Canvas").transform.Find("TextScore").GetComponent<Text>().text = ((int)Score).ToString();
            //Debug.Log("�̂���" + Blocks.Length);
        }
    }
}
