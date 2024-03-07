using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{

    public int hitCount = 0;
    public int maxHitCount = 1; // ブロックが壊れるまでの最大ヒット回数
    public int sumStrenge = 1;

    public void OnCollisionEnter(Collision collision)
    {

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