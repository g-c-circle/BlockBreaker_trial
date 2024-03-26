using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedBlockCount : MonoBehaviour
{
    public int destroyedBlockCount = 0; // �j�󂳂ꂽ�u���b�N��
    public int SumHitCount = 0;
    public int totalBlocks = 0; // �S�̂̃u���b�N��

    private float timer = 0f;
    public float interval = 2f; // 2�b���Ƃɓ��삳�������ꍇ


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

            timer = 0f; // �^�C�}�[���Z�b�g
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            destroyedBlockCount = 0;
            SumHitCount = 0;
            totalBlocks = 0;
        }
    }
}
