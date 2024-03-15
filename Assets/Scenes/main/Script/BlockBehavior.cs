using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{

    public int hitCount = 0;
    public int maxHitCount = 1; // �u���b�N������܂ł̍ő�q�b�g��
    public int sumStrenge = 1;

    public Material[] materials; // �u���b�N��4�̃}�e���A�����i�[����z��

    private Renderer blockRenderer;�@//�\���������������ł��Ȃ�����
    private int currentMaterialIndex = 0; // ���݂̃}�e���A���̃C���f�b�N�X�@//�\���������������ł��Ȃ�����
    
    //�u���b�N�ɂ��Ɖ���ŉ��邩�𐔎��̉摜�i�}�e���A���j���g���ĕ\��(42�s�ځ`50�s�ڂ�null���łĂ�)
    void OnEnable()
    {

        // �u���b�N��Renderer�R���|�[�l���g���擾
        blockRenderer = GetComponent<Renderer>();
        // �ŏ��̃}�e���A����ݒ�
        blockRenderer.material = materials[currentMaterialIndex];// materials�z���������
        materials = new Material[7]; // 4�̗v�f�����z��Ƃ��ď�����

        // �e�v�f�ɓK�؂ȃ}�e���A�������蓖�Ă�i����̓T���v���Ȃ̂œK�؂ȃ}�e���A�������蓖�Ă�K�v������܂��j
        materials[0] = Resources.Load<Material>("1");
        materials[1] = Resources.Load<Material>("2");
        materials[2] = Resources.Load<Material>("3");
        materials[3] = Resources.Load<Material>("4");
        materials[4] = Resources.Load<Material>("5");
        materials[5] = Resources.Load<Material>("6");
        materials[6] = Resources.Load<Material>("7");

        // �ŏ��̃}�e���A����ݒ�
        blockRenderer.material = materials[currentMaterialIndex];

        Debug.Log("BLOCKK");

    }

    public void OnCollisionEnter(Collision collision)
    {
        //null���łĂ��܂��@//void OnEnable�����܂��쓮���Ă��Ȃ��̂��������Ǝv����
        if (materials == null)
        {
            Debug.LogError("materials�z��null�ł��B");
        }
        else
        {
            Debug.Log("BLOCK ERROER");
        }

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

                            blockRenderer.material = materials[0];//���̊֐��łP�Ԗڂ̃}�e���A��(�u�P�v�Ƃ������O�j�ɕύX
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

                                blockRenderer.material = materials[1];//���̊֐��łQ�Ԗڂ̃}�e���A��(�u�Q�v�Ƃ������O�j�ɕύX
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

                                    blockRenderer.material = materials[2];//���̊֐��łR�Ԗڂ̃}�e���A��(�u�R�v�Ƃ������O�j�ɕύX
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

                                        blockRenderer.material = materials[3];//���̊֐��łS�Ԗڂ̃}�e���A��(�u�S�v�Ƃ������O�j�ɕύX
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

                                            blockRenderer.material = materials[4];//���̊֐���5�Ԗڂ̃}�e���A��(�u5�v�Ƃ������O�j�ɕύX
                                        }
                                    }
                                    else//6�Ȃ�
                                    {
                                        if (maxHitCount - sumStrenge == 6)
                                        {
                                            if (blockRenderer != null)
                                            {
                                                Material material = new Material(blockRenderer.material);
                                                material.color = new Color(0.8f, 0.8f, 0.8f);
                                                blockRenderer.material = material;

                                                blockRenderer.material = materials[5];//���̊֐��łU�Ԗڂ̃}�e���A��(�u�U�v�Ƃ������O�j�ɕύX
                                            }
                                        }
                                        else//7�Ȃ�
                                        {
                                            if (maxHitCount - sumStrenge == 7)
                                            {
                                                if (blockRenderer != null)
                                                {
                                                    Material material = new Material(blockRenderer.material);
                                                    material.color = new Color(0.8f, 0.8f, 0.8f);
                                                    blockRenderer.material = material;

                                                    blockRenderer.material = materials[6];//���̊֐��łV�Ԗڂ̃}�e���A��(�u�V�v�Ƃ������O�j�ɕύX
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
    }
}