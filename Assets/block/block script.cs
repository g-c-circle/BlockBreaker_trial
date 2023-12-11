using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject BlockObject;
    private Vector3 initialSize = new Vector3(3f, 1f, 1f); // 初期の大きさ
    private Vector3 currentSize; // 現在の大きさ
    public Color blockColor = Color.white; // ブロックの色
    public Vector3 blockRotation = new Vector3(0f, 0f, 0f); // ブロックの角度

    // Start is called before the first frame update
    void Start()
    {
        currentSize = initialSize;//現在の大きさに初期値を設定
        GenerateBlocks();//ブロック生成
    }

    // ブロック生成の関数
    void GenerateBlocks()
    {
        int x, y;
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
            }
        }
    }

    // ブロックがボールに触れたら作動する関数
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "debug(sphere)")//もしボールに触れたら
        {
            Destroy(gameObject);//ブロック削除
        }
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押されたら少し大きくする
        if (Input.GetKeyDown(KeyCode.Space))//もしスペースキーが押されたら
        {
            blockColor = new Color(Random.value, Random.value, Random.value);//色変数を変更(ランダム)
            currentSize += new Vector3(0.1f, 0.1f, 0.1f);//大きさ変数を変更(少し大きく)
            blockRotation = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));//角度変数を変更(ランダム)
            GenerateBlocks(); // ブロックを再生成して新しい大きさを反映
        }
    }
}
