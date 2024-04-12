using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour
{
    public GameObject blockObject;

    private Vector3 currentSize = new Vector3(3f, 1f, 1f); // 大きさ
    public Vector3 blockRotation_ = new Vector3(0f, 0f, 0f); // ブロックの角度

    public List<GameObject> blocks = new List<GameObject>(); // ブロックオブジェクトを格納するリスト

    private int stageMode = 0;

    // Start is called before the first frame update
    void Start()
    {
        CreateStage(1); // ブロック生成
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))//ブロック削除(ゲーム終了)
        {
            DestroyBlocks();
        }

        //リトライ(リスタート)
        if (Input.GetKeyDown(KeyCode.B))
        {
            stageMode++;
            if (stageMode == 6) stageMode = 0;
            Debug.Log("Stage: " + stageMode);
            RestartStage(stageMode);//ここで指定したステージをリトライ(リスタート)する
        }
    }

    void CreateSimpleBlock(float x, float z, int maxHitCount = 1, float rotation = 0)
    {
        CreateBlock(x, z, maxHitCount, rotation, Color.white, 3f, 1f, 1f);
    }

    //ブロックを一個生成　　[X座標　Z座標　ブロックが壊れるまでの最大ヒット回数(基本は１～８)(0は絶対に壊れない）　向き(角度)　初期の色　幅 奥行 高さ]
    void CreateBlock(float x, float z, int maxHitCount, float rotation, Color color, float width, float height, float depth)// ブロックが壊れるまでの最大ヒット回数を[maxHitCount]に
    {
        blockRotation_ = new Vector3(0f, rotation, 0f);
        GameObject block = Instantiate(blockObject, new Vector3(x, 0, z), Quaternion.Euler(blockRotation_));

        currentSize = new Vector3(width, height, depth);
        block.transform.localScale = currentSize;

        // ブロックの色を設定
        Renderer renderer = block.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material material = new Material(renderer.material);
            material.color = color;
            renderer.material = material;
        }

        BlockBehaviour blockScript = block.GetComponent<BlockBehaviour>();
        blockScript.maxHitCount = maxHitCount;

        // 生成したブロックをリストに追加
        blocks.Add(block);

        Debug.Log("Block added to the list. Current block count: " + blocks.Count);
    }

    //ステージ生成の関数
    void CreateStage(int stage = 1)
    {
        if (stage == 0)
        {
            CreateBlock(10, 10, 1, 0f, Color.green, 3f, 1f, 1f);//一例　座標が(10,10)　1回で壊れる　初期の向き(角度）　最初は緑色 初期の大きさ
            CreateBlock(10, 20, 5, 10f, Color.white, 3f, 1f, 1f);//一例　座標が(10,20)　5回で壊れる　向き(角度）が10　最初は白色 初期の大きさ
            CreateBlock(10, 25, 0, 0f, Color.black, 10f, 1f, 1f);//一例　座標が(10,20)　絶対に壊れない　初期の向き(角度）　最初は黒色 初期の大きさ
        }
        if (stage == 1)//初期
        {
            // 接地する個数
            const int XNum = 8;
            const int ZNum = 6;

            // 余白サイズ
            const float Space = 1f;

            StageManager sm = GameObject.Find("StageManager").GetComponent<StageManager>();

            // 左端のブロック座標を取得
            float? temp_x = sm.GetLeftBlockPos(XNum, currentSize.x, Space);
            if (temp_x == null)
                return;

            // 下端のブロック座標を取得
            float? temp_z = sm.GetBottomBlockPos(ZNum, currentSize.z, Space, StageManager.StageLimitTop, System.Math.Abs(StageManager.StageLimitTop - StageManager.StageLimitBottom) / 2);
            if (temp_z == null)
                return;

            float x = (float)temp_x;
            for (int i = 0; i < XNum; i++)
            {
                float z = (float)temp_z;
                for (int j = 0; j < ZNum; j++)
                {
                    Debug.Log("x:" + x + ",z:" + z);
                    CreateBlock(x, z, 1, 0f, Color.white, 3f, 1f, 1f);
                    z += currentSize.z + Space;
                }
                x += currentSize.x + Space;
            }
        }
    }


    // ブロック削除の関数
    void DestroyBlocks()
    {
        foreach (var block in blocks)
        {
            Destroy(block);//ブロックを削除
        }
        blocks.Clear();
    }

    //リトライ(リスタート)関数
    void RestartStage(int stage)
    {
        DestroyBlocks();//ブロック削除
        CreateStage(stage);//ステージ生成
    }
}