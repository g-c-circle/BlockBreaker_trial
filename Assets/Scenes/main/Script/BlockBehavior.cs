using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{

    public int hitCount = 0;
    public int maxHitCount = 1; // �u���b�N������܂ł̍ő�q�b�g��
    public int sumStrenge = 1;

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ball")//�����{�[���ɐG�ꂽ��
        {
            if (collision.gameObject.tag == "Ball")
            {
                DestroyedBlockCount sum = GameObject.Find("BlockSumManager").GetComponent<DestroyedBlockCount>();
                stdBall ballScript = collision.gameObject.GetComponent<stdBall>();
                double ballLevelValue = ballScript.BallLevel;
                hitCount++; // �q�b�g�񐔂𑝉�
                sum.SumHitCount++;
                sumStrenge = sumStrenge + (int)ballLevelValue;

                if (sumStrenge >= maxHitCount)//hitCount �� maxHitCount �� �����ɂȂ�����
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
                    if (maxHitCount - sumStrenge == 1)
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
                        if (maxHitCount - sumStrenge == 2)
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
                            if (maxHitCount - sumStrenge == 3)
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
                                if (maxHitCount - sumStrenge == 4)
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
                                    if (maxHitCount - sumStrenge == 5)
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