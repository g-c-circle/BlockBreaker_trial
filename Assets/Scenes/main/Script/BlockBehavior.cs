using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int hitCount = 0; // �u���b�N�Ƀq�b�g������

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BlockBehavior script attached to block object.");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GenerateBlocks blockScript = collision.gameObject.GetComponent<GenerateBlocks>();
            if (blockScript != null)
            {
                hitCount++; // �q�b�g�񐔂𑝉�

                if (hitCount >= blockScript.maxHitCount)//hitCount �� maxHitCount �� �����ɂȂ�����
                {
                    // �Փ˂����u���b�N��j�󂷂�
                    Destroy(gameObject);
                    Debug.Log("aoyama");
                }
                else // �����ɂȂ�Ȃ��ꍇ
                {
                    Renderer blockRenderer = GetComponent<Renderer>();
                    if (blockScript.maxHitCount - hitCount == 1)
                    {
                        // ���F�ɕύX
                        if (blockRenderer != null)
                        {
                            Material material = new Material(blockRenderer.material);
                            material.color = Color.black;
                            blockRenderer.material = material;
                        }
                    }
                    else if (blockScript.maxHitCount - hitCount == 2) // �ȉ����l�̏�������
                    {
                        if (blockRenderer != null)
                        {
                            Material material = new Material(blockRenderer.material);
                            material.color = Color.gray;
                            blockRenderer.material = material;
                        }
                    }
                    else if (blockScript.maxHitCount - hitCount == 3)
                    {
                        if (blockRenderer != null)
                        {
                            Material material = new Material(blockRenderer.material);
                            material.color = new Color(0.9f, 0.9f, 0.9f);
                            blockRenderer.material = material;
                        }
                    }
                    else if (blockScript.maxHitCount - hitCount == 4)
                    {
                        if (blockRenderer != null)
                        {
                            Material material = new Material(blockRenderer.material);
                            material.color = new Color(0.85f, 0.85f, 0.85f);
                            blockRenderer.material = material;
                        }
                    }
                    else if (blockScript.maxHitCount - hitCount == 5)
                    {
                        if (blockRenderer != null)
                        {
                            Material material = new Material(blockRenderer.material);
                            material.color = new Color(0.8f, 0.8f, 0.8f);
                            blockRenderer.material = material;
                        }
                    }
                    else // ����ȏ�̏ꍇ
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


    // Update is called once per frame
    void Update()
    {

    }
}
