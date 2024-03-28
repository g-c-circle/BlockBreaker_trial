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

                if (maxHitCount == 0)
                {
                    return;
                }
                else if (sumStrenge >= maxHitCount)//hitCount �� maxHitCount �� �����ɂȂ�����
                {
                    Destroy(gameObject); // �u���b�N����
                    sum.destroyedBlockCount++;
                }
                else//�łȂ����
                {
                    Renderer blockRenderer = GetComponent<Renderer>();
                    if (maxHitCount - sumStrenge <= 7)//����1�`7�Ȃ�
                    {
                        if (blockRenderer != null)
                        {
                            blockRenderer.material = materials[maxHitCount - sumStrenge - 1];
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