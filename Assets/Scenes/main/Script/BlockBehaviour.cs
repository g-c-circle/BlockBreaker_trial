using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
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

        //Debug.Log("BLOCK");

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")//もしボールに触れたら
        {
            BallBehaviour ballScript = collision.gameObject.GetComponent<BallBehaviour>();
            double ballLevelValue = ballScript.ballLevel;
            hitCount++; // ヒット回数を増加
            sumStrenge += (int)ballLevelValue;

            if (maxHitCount == 0)
            {
                return;
            }
            else if (sumStrenge >= maxHitCount)//hitCount と maxHitCount が 同じになったら
            {
                Destroy(gameObject); // ブロックを壊す
            }
            else//でなければ
            {
                Renderer blockRenderer = GetComponent<Renderer>();
                if (maxHitCount - sumStrenge <= 7)//もし1～7なら
                {
                    if (blockRenderer != null)
                    {
                        blockRenderer.material = materials[maxHitCount - sumStrenge - 1];
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