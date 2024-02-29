using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    
    public int hitCount = 0;
    

    
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ball")//�����{�[���ɐG�ꂽ��
        {
            if (collision.gameObject.tag == "Ball")
            {
                GenerateBlocks blockScript = GameObject.Find("PrefabManager").GetComponent<GenerateBlocks>();
                DestroyedBlockCount sum = GameObject.Find("BlockSumManager").GetComponent<DestroyedBlockCount>();
                hitCount++; // �q�b�g�񐔂𑝉�
                sum.SumHitCount++;

                if (hitCount >= blockScript.maxHitCount)//hitCount �� maxHitCount �� �����ɂȂ�����
                {

                    //ReflectBall(collision.gameObject.GetComponent<Rigidbody>());//�{�[���𒵂˕Ԃ�
                    Destroy(gameObject); // �u���b�N����
                    //destroyedBlockCount++; // �j�󂳂ꂽ�u���b�N���𑝂₷
                    //Debug.Log("destroyedBlockCount: " + destroyedBlockCount);
                    //blocks.Remove(gameObject);
                    //blockScript.destroyedBlockCount++;
                    sum.destroyedBlockCount++;
                }
                else//�łȂ����
                {

                    Renderer blockRenderer = GetComponent<Renderer>();
                    if (blockScript.maxHitCount - hitCount == 1)
                    {
                        //���F�ɕύX
                        if (blockRenderer != null)
                        {
                            Material material = new Material(blockRenderer.material);
                            material.color = Color.black;
                            blockRenderer.material = material;
                        }
                    }
                    else//2�Ȃ�
                    {
                        if (blockScript.maxHitCount - hitCount == 2)
                        {
                            if (blockRenderer != null)
                            {
                                Material material = new Material(blockRenderer.material);
                                material.color = Color.gray;
                                blockRenderer.material = material;
                            }
                        }
                        else//3�Ȃ�
                        {
                            if (blockScript.maxHitCount - hitCount == 3)
                            {
                                if (blockRenderer != null)
                                {
                                    Material material = new Material(blockRenderer.material);
                                    material.color = new Color(0.9f, 0.9f, 0.9f);
                                    blockRenderer.material = material;
                                }
                            }
                            else//4�Ȃ�
                            {
                                if (blockScript.maxHitCount - hitCount == 4)
                                {
                                    if (blockRenderer != null)
                                    {
                                        Material material = new Material(blockRenderer.material);
                                        material.color = new Color(0.85f, 0.85f, 0.85f);
                                        blockRenderer.material = material;
                                    }
                                }
                                else//5�Ȃ�
                                {
                                    if (blockScript.maxHitCount - hitCount == 5)
                                    {
                                        if (blockRenderer != null)
                                        {
                                            Material material = new Material(blockRenderer.material);
                                            material.color = new Color(0.8f, 0.8f, 0.8f);
                                            blockRenderer.material = material;
                                        }
                                    }
                                    else//����ȏ�Ȃ�
                                    {
                                        if (blockRenderer != null)
                                        {
                                            float grayValue = (float)(0.75 - ((blockScript.maxHitCount - hitCount) / 100));
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