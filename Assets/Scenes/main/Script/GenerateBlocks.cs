using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
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

    // Start is called before the first frame update
    void Start()
    {
        currentSize = initialSize; // 現在の大きさに初期値を設定
        //GenerateBlocksCreateStage(0); // ブロック生成
        GenerateBlocksCreateStage(7); // ブロック生成

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
        for (x = -10; x < 15; x += 5)
        {
            for (z = 20; z > 0; z -= 5)
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

                // 生成したブロックをリストに追加
                blocks.Add(block);
            }
        }
    }

    // ブロックがボールに触れたら作動する関数
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")//もしボールに触れたら
        {
            //ReflectBall(collision.gameObject.GetComponent<Rigidbody>());//ボールを跳ね返す
            Destroy(gameObject);//(ボールに触れた)ブロック削除


            // ----- スコアを増やす -----

            StageManager sm = GameObject.Find("StageManager").GetComponent<StageManager>();
            sm.Score += 1;

            // ----- スコアを増やす -----


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
    }

    //ブロックを一個生成
    void GenerateBlocksCreate(float x, float z)
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

        // 生成したブロックをリストに追加
        blocks.Add(block);
    }

    //ステージ生成の関数
    void GenerateBlocksCreateStage(int stage)
    {
        if (stage == 0)
        {
            SimpleGenerateBlocks();//シンプルステージを生成
        }

        if (stage == 1)
        {
            GenerateBlocksCreate(5, 20);//この文を(座標を変えて)個数分コピペする
            GenerateBlocksCreate(0, 15);
            GenerateBlocksCreate(10, 15);
            GenerateBlocksCreate(5, 10);
        }

        if (stage == 2)
        {
            GenerateBlocksCreate(-10, 20);//この文を(座標を変えて)個数分コピペする
            GenerateBlocksCreate(15, 20);
            GenerateBlocksCreate(-5, 15);
            GenerateBlocksCreate(10, 15);
            GenerateBlocksCreate(0, 10);
            GenerateBlocksCreate(5, 10);
        }

        if (stage == 3)
        {
            GenerateBlocksCreate(-10, 10);//この文を(座標を変えて)個数分コピペする
            GenerateBlocksCreate(15, 10);
            GenerateBlocksCreate(-5, 15);
            GenerateBlocksCreate(10, 15);
            GenerateBlocksCreate(0, 20);
            GenerateBlocksCreate(5, 20);
        }

        if (stage == 4)
        {
            GenerateBlocksCreate(-10, 20);//この文を(座標を変えて)個数分コピペする
            GenerateBlocksCreate(-5, 15);
            GenerateBlocksCreate(0, 10);
            GenerateBlocksCreate(10, 5);
            GenerateBlocksCreate(15, 0);
        }

        if (stage == 5)
        {
            GenerateBlocksCreate(-10, 0);//この文を(座標を変えて)個数分コピペする
            GenerateBlocksCreate(-5, 5);
            GenerateBlocksCreate(0, 10);
            GenerateBlocksCreate(10, 15);
            GenerateBlocksCreate(15, 20);
        }
        if (stage == 6)
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
                    GenerateBlocksCreate(x, z);
                }
            }
        }
        if (stage == 7)
        {
            // 接地する個数
            const int x_num = 4;
            const int z_num = 8;

            // 余白サイズ
            const float Space = 0.5f;

            StageManager sm = GameObject.Find("StageManager").GetComponent<StageManager>();

            // 左端のブロック座標を取得
            float? temp_x = sm.GetLeftBlockPos(x_num, currentSize.x, Space);
            if (temp_x == null)
                return;

            // 下端のブロック座標を取得
            float? temp_z = sm.GetBottomBlockPos(z_num, currentSize.z, Space, StageManager.STAGE_LIMIT_TOP, 15.5f);
            if (temp_z == null)
                return;

            float x = (float)temp_x;
            for (int i = 0; i < x_num; i++)
            {
                float z = (float)temp_z;
                for (int j = 0; j < z_num; j++)
                {
                    GenerateBlocksCreate(x, z);
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
        if (Input.GetKeyDown(KeyCode.Space))//もしスペースキーが押されたら
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


        if (Input.GetKeyDown(KeyCode.D))//ブロック削除(ゲーム終了)
        {
            BlocksDestroy();
        }

        //ステージ生成0
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            GenerateBlocksCreateStage(0);//ここで指定したステージを読み込む
        }

        //リトライ(リスタート)0
        if (Input.GetKeyDown(KeyCode.P))
        {
            GenerateBlocksStageRestart(0);//ここで指定したステージをリトライ(リスタート)する
        }


        //ステージ生成1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GenerateBlocksCreateStage(1);//ここで指定したステージを読み込む
        }

        //リトライ(リスタート)1
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GenerateBlocksStageRestart(1);//ここで指定したステージをリトライ(リスタート)する
        }


        //ステージ生成2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GenerateBlocksCreateStage(2);//ここで指定したステージを読み込む
        }

        //リトライ(リスタート)2
        if (Input.GetKeyDown(KeyCode.W))
        {
            GenerateBlocksStageRestart(2);//ここで指定したステージをリトライ(リスタート)する
        }


        //ステージ生成3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GenerateBlocksCreateStage(3);//ここで指定したステージを読み込む
        }

        //リトライ(リスタート)3
        if (Input.GetKeyDown(KeyCode.E))
        {
            GenerateBlocksStageRestart(3);//ここで指定したステージをリトライ(リスタート)する
        }


        //ステージ生成4
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GenerateBlocksCreateStage(4);//ここで指定したステージを読み込む
        }

        //リトライ(リスタート)4
        if (Input.GetKeyDown(KeyCode.R))
        {
            GenerateBlocksStageRestart(4);//ここで指定したステージをリトライ(リスタート)する
        }


        //ステージ生成5
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GenerateBlocksCreateStage(5);//ここで指定したステージを読み込む
        }

        //リトライ(リスタート)5
        if (Input.GetKeyDown(KeyCode.T))
        {
            GenerateBlocksStageRestart(5);//ここで指定したステージをリトライ(リスタート)する
        }


    }
}
