using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject BlockObject;
    private Vector3 initialSize = new Vector3(3f, 1f, 1f); // 初期の大きさ
    private Vector3 currentSize; // 現在の大きさ
    private Color blockColor = Color.white; // ブロックの色
    public Vector3 blockRotation = new Vector3(0f, 0f, 0f); // ブロックの角度

    private List<GameObject> blocks = new List<GameObject>(); // ブロックオブジェクトを格納するリスト

    // Start is called before the first frame update
    void Start()
    {
        currentSize = initialSize; // 現在の大きさに初期値を設定
        GenerateBlocksCreateStage(0); // ブロック生成
    }

    //ブロック生成の関数(ステージ0)
    void SimpleGenerateBlocks()
    {
        int x, y;//ブロックの座標変数
        for (x = -10; x < 15; x += 5)
        {
            for (y = 20; y > 0; y -= 5)
            {
                GameObject block = Instantiate(BlockObject, new Vector3(x, y, 0), Quaternion.Euler(blockRotation));
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
        if (collision.gameObject.tag == "debug(sphere)")//もしボールに触れたら
        {
            Destroy(gameObject);//(ボールに触れた)ブロック削除

            collision.gameObject.transform.localScale = Vector3.one * 2f;//ボールの大きさを変更

            // ボールのRendererコンポーネントを取得
            Renderer ballRenderer = collision.gameObject.GetComponent<Renderer>();
            // 新しいランダム色を生成
            blockColor = new Color(Random.value, Random.value, Random.value);
            // ボールのマテリアルの色を変更
            if (ballRenderer != null)
            {
                Material material = new Material(ballRenderer.material);
                material.color = blockColor;
                ballRenderer.material = material;
            }

            GameObject newBall = Instantiate(collision.gameObject, collision.gameObject.transform.position, Quaternion.identity); ;//ボールを複製

            ChangeOtherBlocksColor();//ブロックの色を変更
        }
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

    //ブロックを一個生成
    void GenerateBlocksCreate(int x, int y)
    {
        GameObject block = Instantiate(BlockObject, new Vector3(x, y, 0), Quaternion.Euler(blockRotation));
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
        if(stage == 0)
        {
            SimpleGenerateBlocks();//シンプルステージを生成
        }

        if(stage == 1)
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
            blockRotation = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));//角度変数を変更(ランダム)
            

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
