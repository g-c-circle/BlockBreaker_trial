using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{

    public int hitCount = 0;
    public int maxHitCount = 1; // ブロックが壊れるまでの最大ヒット回数
    public int sumStrenge = 1;

    public Material[] materials; // ブロックの4つのマテリアルを格納する配列

    private Renderer blockRenderer;　//表示したかったができなかった
    private int currentMaterialIndex = 0; // 現在のマテリアルのインデックス　//表示したかったができなかった
    
    //ブロックにあと何回で壊れるかを数字の画像（マテリアル）を使って表示(42行目～50行目でnullがでてる)
    void OnEnable()
    {

        // ブロックのRendererコンポーネントを取得
        blockRenderer = GetComponent<Renderer>();
        // 最初のマテリアルを設定
        blockRenderer.material = materials[currentMaterialIndex];// materials配列を初期化
        materials = new Material[7]; // 4つの要素を持つ配列として初期化

        // 各要素に適切なマテリアルを割り当てる（これはサンプルなので適切なマテリアルを割り当てる必要があります）
        materials[0] = Resources.Load<Material>("1");
        materials[1] = Resources.Load<Material>("2");
        materials[2] = Resources.Load<Material>("3");
        materials[3] = Resources.Load<Material>("4");
        materials[4] = Resources.Load<Material>("5");
        materials[5] = Resources.Load<Material>("6");
        materials[6] = Resources.Load<Material>("7");

        // 最初のマテリアルを設定
        blockRenderer.material = materials[currentMaterialIndex];

        Debug.Log("BLOCKK");

    }

    public void OnCollisionEnter(Collision collision)
    {
        //nullがでてしまう　//void OnEnableがうまく作動していないのが原因だと思われる
        if (materials == null)
        {
            Debug.LogError("materials配列がnullです。");
        }
        else
        {
            Debug.Log("BLOCK ERROER");
        }

        if (collision.gameObject.tag == "Ball")//もしボールに触れたら
        {
            if (collision.gameObject.tag == "Ball")
            {
                DestroyedBlockCount sum = GameObject.Find("BlockSumManager").GetComponent<DestroyedBlockCount>();
                stdBall ballScript = collision.gameObject.GetComponent<stdBall>();
                double ballLevelValue = ballScript.BallLevel;
                hitCount++; // ヒット回数を増加
                sum.SumHitCount++;
                sumStrenge = sumStrenge + (int)ballLevelValue;

                if (sumStrenge >= maxHitCount)//hitCount と maxHitCount が 同じになったら
                {

                    //ReflectBall(collision.gameObject.GetComponent<Rigidbody>());//ボールを跳ね返す
                    Destroy(gameObject); // ブロックを壊す
                    //destroyedBlockCount++; // 破壊されたブロック数を増やす
                    //Debug.Log("destroyedBlockCount: " + destroyedBlockCount);
                    //blocks.Remove(gameObject);
                    //blockScript.destroyedBlockCount++;
                    sum.destroyedBlockCount++;
                }
                else//でなければ
                {

                    Renderer blockRenderer = GetComponent<Renderer>();
                    if (maxHitCount - sumStrenge == 1)
                    {
                        //黒色に変更
                        if (blockRenderer != null)
                        {
                            Material material = new Material(blockRenderer.material);
                            material.color = Color.black;
                            blockRenderer.material = material;

                            blockRenderer.material = materials[0];//この関数で１番目のマテリアル(「１」という名前）に変更
                        }
                    }
                    else//2なら
                    {
                        if (maxHitCount - sumStrenge == 2)
                        {
                            if (blockRenderer != null)
                            {
                                Material material = new Material(blockRenderer.material);
                                material.color = Color.gray;
                                blockRenderer.material = material;

                                blockRenderer.material = materials[1];//この関数で２番目のマテリアル(「２」という名前）に変更
                            }
                        }
                        else//3なら
                        {
                            if (maxHitCount - sumStrenge == 3)
                            {
                                if (blockRenderer != null)
                                {
                                    Material material = new Material(blockRenderer.material);
                                    material.color = new Color(0.9f, 0.9f, 0.9f);
                                    blockRenderer.material = material;

                                    blockRenderer.material = materials[2];//この関数で３番目のマテリアル(「３」という名前）に変更
                                }
                            }
                            else//4なら
                            {
                                if (maxHitCount - sumStrenge == 4)
                                {
                                    if (blockRenderer != null)
                                    {
                                        Material material = new Material(blockRenderer.material);
                                        material.color = new Color(0.85f, 0.85f, 0.85f);
                                        blockRenderer.material = material;

                                        blockRenderer.material = materials[3];//この関数で４番目のマテリアル(「４」という名前）に変更
                                    }
                                }
                                else//5なら
                                {
                                    if (maxHitCount - sumStrenge == 5)
                                    {
                                        if (blockRenderer != null)
                                        {
                                            Material material = new Material(blockRenderer.material);
                                            material.color = new Color(0.8f, 0.8f, 0.8f);
                                            blockRenderer.material = material;

                                            blockRenderer.material = materials[4];//この関数で5番目のマテリアル(「5」という名前）に変更
                                        }
                                    }
                                    else//6なら
                                    {
                                        if (maxHitCount - sumStrenge == 6)
                                        {
                                            if (blockRenderer != null)
                                            {
                                                Material material = new Material(blockRenderer.material);
                                                material.color = new Color(0.8f, 0.8f, 0.8f);
                                                blockRenderer.material = material;

                                                blockRenderer.material = materials[5];//この関数で６番目のマテリアル(「６」という名前）に変更
                                            }
                                        }
                                        else//7なら
                                        {
                                            if (maxHitCount - sumStrenge == 7)
                                            {
                                                if (blockRenderer != null)
                                                {
                                                    Material material = new Material(blockRenderer.material);
                                                    material.color = new Color(0.8f, 0.8f, 0.8f);
                                                    blockRenderer.material = material;

                                                    blockRenderer.material = materials[6];//この関数で７番目のマテリアル(「７」という名前）に変更
                                                }
                                            }
                                            else//それ以上なら
                                            {
                                                if (blockRenderer != null)
                                                {
                                                    float grayValue = (float)(0.75 - ((maxHitCount - sumStrenge) / 100));
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
        }
    }
}