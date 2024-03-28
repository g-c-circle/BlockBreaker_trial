using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour
{
    public GameObject BlockObject;

    private Vector3 currentSize = new Vector3(3f, 1f, 1f); // 大きさ

    public Vector3 blockRotation = new Vector3(0f, 0f, 0f); // ブロックの角度

    public List<GameObject> blocks = new List<GameObject>(); // ブロックオブジェクトを格納するリスト

    public float constantSpeed = 5.0f; // 一定の速度
    private Rigidbody ballRigidbody;

    int StageMode = 0;

    public int start = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // ブロック削除の関数
    void BlocksDestroy()
    {
        foreach (var block in blocks)
        {
            Destroy(block);//ブロックを削除
        }
        blocks.Clear();
    }

    //ブロックを一個生成　　[X座標　Z座標　ブロックが壊れるまでの最大ヒット回数(基本は１～８)(0は絶対に壊れない）　向き(角度)　初期の色　幅 奥行 高さ]
    void GenerateBlocksCreate(float x, float z, int MaxHitCount, float Rotation, Color color, float width, float height, float depth)// ブロックが壊れるまでの最大ヒット回数を[maxHitCount]に
    {
        blockRotation = new Vector3(0f, Rotation, 0f);
        GameObject block = Instantiate(BlockObject, new Vector3(x, 0, z), Quaternion.Euler(blockRotation));

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

        BlockBehavior blockScript = block.GetComponent<BlockBehavior>();
        blockScript.maxHitCount = MaxHitCount;

        // 生成したブロックをリストに追加
        blocks.Add(block);

        Debug.Log("Block added to the list. Current block count: " + blocks.Count);
        DestroyedBlockCount sum = GameObject.Find("BlockSumManager").GetComponent<DestroyedBlockCount>();
        sum.totalBlocks = blocks.Count;
    }

    //ステージ生成の関数
    void GenerateBlocksCreateStage(int stage)
    {
        if (stage == 0)
        {
            GenerateBlocksCreate(10, 10, 1, 0f, Color.green, 3f, 1f, 1f);//一例　座標が(10,10)　1回で壊れる　初期の向き(角度）　最初は緑色 初期の大きさ
            GenerateBlocksCreate(10, 20, 5, 10f, Color.white, 3f, 1f, 1f);//一例　座標が(10,20)　5回で壊れる　向き(角度）が10　最初は白色 初期の大きさ
            GenerateBlocksCreate(10, 25, 0, 0f, Color.black, 10f, 1f, 1f);//一例　座標が(10,20)　絶対に壊れない　初期の向き(角度）　最初は黒色 初期の大きさ
        }

        if (stage == 1)
        {

        }

        if (stage == 2)
        {

        }

        if (stage == 3)
        {

        }

        if (stage == 4)
        {

        }

        if (stage == 5)
        {

        }
        if (stage == 6)
        {

        }
        if (stage == 7)//初期　（１８９行目で実行）
        {
            // 接地する個数
            const int X_NUM = 4;
            const int Z_NUM = 8;

            // 余白サイズ
            const float Space = 0.5f;

            StageManager sm = GameObject.Find("StageManager").GetComponent<StageManager>();

            // 左端のブロック座標を取得
            float? temp_x = sm.GetLeftBlockPos(X_NUM, currentSize.x, Space);
            if (temp_x == null)
                return;

            // 下端のブロック座標を取得
            float? temp_z = sm.GetBottomBlockPos(Z_NUM, currentSize.z, Space, StageManager.STAGE_LIMIT_TOP, 15.5f);
            if (temp_z == null)
                return;

            float x = (float)temp_x;
            for (int i = 0; i < X_NUM; i++)
            {
                float z = (float)temp_z;
                for (int j = 0; j < Z_NUM; j++)
                {
                    Debug.Log("x:" + x + ",z:" + z);
                    GenerateBlocksCreate(x, z, 9, 0f, Color.white, 3f, 1f, 1f);
                    z += currentSize.z + Space;
                }
                x += currentSize.x + Space;
            }
        }
    }

    //リトライ(リスタート)関数
    void GenerateBlocksStageRestart(int stage)
    {
        BlocksDestroy();//ブロック削除
        GenerateBlocksCreateStage(stage);//ステージ生成
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))//ブロック削除(ゲーム終了)
        {
            BlocksDestroy();
        }

        //リトライ(リスタート)
        if (Input.GetKeyDown(KeyCode.B))
        {
            StageMode++;
            if (StageMode == 6) StageMode = 0;
            Debug.Log("Stage: " + StageMode);
            GenerateBlocksStageRestart(StageMode);//ここで指定したステージをリトライ(リスタート)する
        }

        if (start == 1)
        {
            GenerateBlocksCreateStage(7); // ブロック生成
            ballRigidbody = GetComponent<Rigidbody>();
            start = 0;
        }
    }
}