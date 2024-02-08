using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour
{
    public GameObject BlockObject;

    private Vector3 initialSize = new Vector3(3f, 1f, 1f); // 初期の大きさ
    private Vector3 currentSize; // 現在の大きさ

    private Color blockColor = Color.white; // ブロックの色
    public Vector3 blockRotation = new Vector3(0f, 0f, 0f); // ブロックの角度

    private List<GameObject> blocks = new List<GameObject>(); // ブロックオブジェクトを格納するリスト

    public float constantSpeed = 5.0f; // 一定の速度
    private Rigidbody ballRigidbody;

    int mode = 0;
    int StageMode = 0;

    //private int totalBlocks = 0; // 全体のブロック数
    //private int destroyedBlockCount = 0; // 破壊されたブロック数

    private int hitCount = 0; // ブロックにヒットした回数
    public int maxHitCount = 1; // ブロックが壊れるまでの最大ヒット回数

    //public int changeCount = 5; // 色が変化する回数
    //public Color targetColor = Color.black; // 変化後の色
    //private int currentCount = 0; // 現在の変化回数
    //private Color currentColor = Color.white; // 現在の色（初期値は白）

    // Start is called before the first frame update
    void Start()
    {
        currentSize = initialSize; // 現在の大きさに初期値を設定
        //GenerateBlocksCreateStage(0); // ブロック生成
        GenerateBlocksCreateStage(6); // ブロック生成

        ballRigidbody = GetComponent<Rigidbody>();
        // ボールに物理的な反発を設定
        //ballRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        //ballRigidbody.isKinematic = false;
        //ballRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    //ブロック生成の関数(ステージ0)
    void SimpleGenerateBlocks()
    {
        int x, z;//ブロックの座標変数
        for (x = -6; x < 5; x += 5)
        {
            for (z = 12; z > 2; z -= 3)
            {
                // ブロック生成
                GameObject block = Instantiate(BlockObject, new Vector3(x, 0, z), Quaternion.Euler(blockRotation));
                block.transform.localScale = currentSize;

                // ブロックの色を設定
                Renderer renderer = block.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Material material = new Material(renderer.material);
                    material.color = blockColor;
                    renderer.material = material;
                }

                block.GetComponent<GenerateBlocks>().maxHitCount = 1;

                // 生成したブロックをリストに追加
                blocks.Add(block);

                //totalBlocks++;
            }
        }
    }

    // ブロックがボールに触れたら作動する関数
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ball")//もしボールに触れたら
        {
            if (collision.gameObject.tag == "Ball")
            {
                hitCount++; // ヒット回数を増加

                if (hitCount >= maxHitCount)//hitCount と maxHitCount が 同じになったら
                {

                    //ReflectBall(collision.gameObject.GetComponent<Rigidbody>());//ボールを跳ね返す
                    Destroy(gameObject); // ブロックを壊す
                    //destroyedBlockCount++; // 破壊されたブロック数を増やす
                    //Debug.Log("destroyedBlockCount: " + destroyedBlockCount);
                    blocks.Remove(gameObject);
                    // ボールのRendererコンポーネントを取得
                    Renderer ballRenderer = collision.gameObject.GetComponent<Renderer>();
                    // 新しいランダム色を生成
                    blockColor = new Color(Random.value, Random.value, Random.value);

                    //モード１だったら
                    if (mode == 1)
                    {

                        // ボールのマテリアルの色を変更
                        if (ballRenderer != null)
                        {
                            Material material = new Material(ballRenderer.material);
                            material.color = blockColor;
                            ballRenderer.material = material;
                        }

                        collision.gameObject.transform.localScale = Vector3.one * 2f;//ボールの大きさを変更

                        GameObject newBall = Instantiate(collision.gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + currentSize.z), Quaternion.identity);//ボールを複製

                        newBall.tag = "Ball";

                        GameObject[] allBalls = GameObject.FindGameObjectsWithTag("Ball");
                        foreach (GameObject ball in allBalls)
                        {
                            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
                            if (ballRigidbody != null)
                            {
                                ballRigidbody.velocity *= 5f; // 速度を五倍にする
                            }
                        }

                        ChangeOtherBlocksColor();//ブロックの色を変更
                    }
                }
                else//でなければ
                {

                    Renderer blockRenderer = GetComponent<Renderer>();
                    if (maxHitCount - hitCount == 1)
                    {
                        //黒色に変更
                        if (blockRenderer != null)
                        {
                            Material material = new Material(blockRenderer.material);
                            material.color = Color.black;
                            blockRenderer.material = material;
                        }
                    }
                    else//2なら
                    {
                        if (maxHitCount - hitCount == 2)
                        {
                            if (blockRenderer != null)
                            {
                                Material material = new Material(blockRenderer.material);
                                material.color = Color.gray;
                                blockRenderer.material = material;
                            }
                        }
                        else//3なら
                        {
                            if (maxHitCount - hitCount == 3)
                            {
                                if (blockRenderer != null)
                                {
                                    Material material = new Material(blockRenderer.material);
                                    material.color = new Color(0.9f, 0.9f, 0.9f);
                                    blockRenderer.material = material;
                                }
                            }
                            else//4なら
                            {
                                if (maxHitCount - hitCount == 4)
                                {
                                    if (blockRenderer != null)
                                    {
                                        Material material = new Material(blockRenderer.material);
                                        material.color = new Color(0.85f, 0.85f, 0.85f);
                                        blockRenderer.material = material;
                                    }
                                }
                                else//5なら
                                {
                                    if (maxHitCount - hitCount == 5)
                                    {
                                        if (blockRenderer != null)
                                        {
                                            Material material = new Material(blockRenderer.material);
                                            material.color = new Color(0.8f, 0.8f, 0.8f);
                                            blockRenderer.material = material;
                                        }
                                    }
                                    else//それ以上なら
                                    {
                                        if (blockRenderer != null)
                                        {
                                            float grayValue = (float)(0.75 - ((maxHitCount - hitCount) / 100));
                                            Material material = new Material(blockRenderer.material);
                                            material.color = new Color(grayValue, grayValue, grayValue);
                                            blockRenderer.material = material;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    //void ReflectBall(Rigidbody ballRigidbody)
    //{
    //    if (ballRigidbody != null)
    //    {
    //        // 反射角度を計算
    //        Vector3 reflection = Vector3.Reflect(ballRigidbody.velocity, Vector3.up);
    //        ballRigidbody.velocity = reflection.normalized * constantSpeed;
    //    }
    //}

    // ブロック削除の関数
    void BlocksDestroy()
    {
        foreach (var block in blocks)
        {
            Destroy(block);//ブロックを削除
        }
        blocks.Clear();
        //totalBlocks = 0;
        //destroyedBlockCount = 0; // 破壊されたブロック数をリセット
        //Debug.Log("Blocks list cleared. Current block count: " + blocks.Count);
    }

    //ブロックを一個生成
    void GenerateBlocksCreate(float x, float z, int maxHitCount)// ブロックが壊れるまでの最大ヒット回数を[maxHitCount]に
    {
        GameObject block = Instantiate(BlockObject, new Vector3(x, 0, z), Quaternion.Euler(blockRotation));
        block.transform.localScale = currentSize;

        // ブロックの色を設定
        Renderer renderer = block.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material material = new Material(renderer.material);
            material.color = blockColor;
            renderer.material = material;
        }

        block.GetComponent<GenerateBlocks>().maxHitCount = maxHitCount;

        // 生成したブロックをリストに追加
        blocks.Add(block);

        Debug.Log("Block added to the list. Current block count: " + blocks.Count);

        //totalBlocks++;
        //Debug.Log(totalBlocks);
    }

    //ステージ生成の関数
    void GenerateBlocksCreateStage(int stage)
    {
        if (stage == 0)//シンプル
        {
            SimpleGenerateBlocks();//シンプルステージを生成
        }

        if (stage == 1)
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 1);
                }
            }
        }

        if (stage == 2)
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 2);
                }
            }
        }

        if (stage == 3)
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 3);
                }
            }
        }

        if (stage == 4)
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 4);
                }
            }
        }

        if (stage == 5)
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 5);
                }
            }
        }
        if (stage == 6)//初期
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 1);// ブロックが壊れるまでの最大ヒット回数を追加
                }
            }

        }
    }

    //リトライ(リスタート)関数
    void GenerateBlocksStageRestart(int stage)
    {
        BlocksDestroy();//ブロック削除
        GenerateBlocksCreateStage(stage);//ステージ生成
    }


    void ChangeOtherBlocksColor()//ブロックの色を変更する関数
    {
        foreach (var block in blocks)
        {
            //同じ条件に合ったら色を変更（ここではランダム色にしています）
            if (block != null && block != gameObject)
            {
                Renderer blockRenderer = block.GetComponent<Renderer>();
                if (blockRenderer != null)
                {
                    blockRenderer.material.color = new Color(Random.value, Random.value, Random.value);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押されたらブロックの大きさ・角度・色を変更する
        if (Input.GetKeyDown(KeyCode.V))//もしスペースキーが押されたら
        {
            blockColor = new Color(Random.value, Random.value, Random.value);//色変数を変更(ランダム)
            currentSize += new Vector3(0.1f, 0.1f, 0.1f);//大きさ変数を変更(少し大きく)
            blockRotation = new Vector3(0f, Random.Range(0f, 360f), 0f);//角度変数を変更(ランダム)


            //ブロックの大きさを変更
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    block.transform.localScale = currentSize;
                }
            }

            //ブロックの角度を変更
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    block.transform.rotation = Quaternion.Euler(blockRotation);
                }
            }

            //ブロックの色を変更
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    Renderer blockRenderer = block.GetComponent<Renderer>();
                    if (blockRenderer != null)
                    {
                        Material material = new Material(blockRenderer.material);
                        material.color = blockColor;
                        blockRenderer.material = material;
                    }
                }
            }

        }

        //モード切り替え
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mode == 0)
            {
                mode = 1;
            }
            else
            {
                mode = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.N))//ブロック削除(ゲーム終了)
        {
            BlocksDestroy();
        }

        //if (destroyedBlockCount >= totalBlocks) Debug.Log("All blocks destroyed!" + totalBlocks + destroyedBlockCount);

        //リトライ(リスタート)
        if (Input.GetKeyDown(KeyCode.B))
        {
            StageMode++;
            if (StageMode == 6) StageMode = 0;
            Debug.Log("Stage: " + StageMode);
            GenerateBlocksStageRestart(StageMode);//ここで指定したステージをリトライ(リスタート)する
        }

    }
}