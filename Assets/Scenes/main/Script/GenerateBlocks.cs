using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour
{
    public GameObject BlockObject;

    private Vector3 initialSize = new Vector3(3f, 1f, 1f); // �����̑傫��
    private Vector3 currentSize; // ���݂̑傫��

    public Vector3 blockRotation = new Vector3(0f, 0f, 0f); // �u���b�N�̊p�x

    private List<GameObject> blocks = new List<GameObject>(); // �u���b�N�I�u�W�F�N�g���i�[���郊�X�g

    public float constantSpeed = 5.0f; // ���̑��x
    private Rigidbody ballRigidbody;

    int StageMode = 0;

    //private int totalBlocks = 0; // �S�̂̃u���b�N��
    //private int destroyedBlockCount = 0; // �j�󂳂ꂽ�u���b�N��

    private int hitCount = 0; // �u���b�N�Ƀq�b�g������
    public int maxHitCount = 1; // �u���b�N������܂ł̍ő�q�b�g��

    //public int changeCount = 5; // �F���ω������
    //public Color targetColor = Color.black; // �ω���̐F
    //private int currentCount = 0; // ���݂̕ω���
    //private Color currentColor = Color.white; // ���݂̐F�i�����l�͔��j

    // Start is called before the first frame update
    void Start()
    {
        currentSize = initialSize; // ���݂̑傫���ɏ����l��ݒ�
        GenerateBlocksCreateStage(6); // �u���b�N����

        ballRigidbody = GetComponent<Rigidbody>();
    }

    // �u���b�N�폜�̊֐�
    void BlocksDestroy()
    {
        foreach (var block in blocks)
        {
            Destroy(block);//�u���b�N���폜
        }
        blocks.Clear();
        //totalBlocks = 0;
        //destroyedBlockCount = 0; // �j�󂳂ꂽ�u���b�N�������Z�b�g
        //Debug.Log("Blocks list cleared. Current block count: " + blocks.Count);
    }

    //�u���b�N�������
    void GenerateBlocksCreate(float x, float z, int maxHitCount, float Rotation, Color color)// �u���b�N������܂ł̍ő�q�b�g�񐔂�[maxHitCount]��
    {
        blockRotation = new Vector3(0f, Rotation, 0f);
        GameObject block = Instantiate(BlockObject, new Vector3(x, 0, z), Quaternion.Euler(blockRotation));
        block.transform.localScale = currentSize;

        // �u���b�N�̐F��ݒ�
        Renderer renderer = block.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material material = new Material(renderer.material);
            material.color = color;
            renderer.material = material;
        }

        block.GetComponent<GenerateBlocks>().maxHitCount = maxHitCount;

        // ���������u���b�N�����X�g�ɒǉ�
        blocks.Add(block);

        Debug.Log("Block added to the list. Current block count: " + blocks.Count);

        //totalBlocks++;
        //Debug.Log(totalBlocks);
    }

    //�X�e�[�W�����̊֐�
    void GenerateBlocksCreateStage(int stage)
    {
        if (stage == 0)
        {

        }

        if (stage == 1)
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 1, 0f, Color.white);
                }
            }
        }

        if (stage == 2)
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 2, 0f, Color.white);
                }
            }
        }

        if (stage == 3)
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 3, 0f, Color.white);
                }
            }
        }

        if (stage == 4)
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 4, 0f, Color.white);
                }
            }
        }

        if (stage == 5)
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 5, 0f, Color.white);
                }
            }
        }
        if (stage == 6)//����
        {
            const float LEFT = -10f;
            const float RIGHT = 10f;
            const float TOP = 15f;
            const float BOTTOM = 0f;
            const float SPACE = 0.5f;
            currentSize = new Vector3(3f, 1f, 1f);
            for (float x = LEFT + SPACE + currentSize.x; x < RIGHT - SPACE - currentSize.x; x += (SPACE + currentSize.x))
            {
                for (float z = BOTTOM + SPACE + currentSize.z; z < TOP - SPACE - currentSize.z; z += (SPACE + currentSize.z))
                {
                    GenerateBlocksCreate(x, z, 1, 0f, Color.white);// �u���b�N������܂ł̍ő�q�b�g�񐔂�ǉ�
                }
            }

        }
    }

    //���g���C(���X�^�[�g)�֐�
    void GenerateBlocksStageRestart(int stage)
    {
        BlocksDestroy();//�u���b�N�폜
        GenerateBlocksCreateStage(stage);//�X�e�[�W����
    }

    // �u���b�N���{�[���ɐG�ꂽ��쓮����֐�
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ball")//�����{�[���ɐG�ꂽ��
        {
            if (collision.gameObject.tag == "Ball")
            {
                hitCount++; // �q�b�g�񐔂𑝉�

                if (hitCount >= maxHitCount)//hitCount �� maxHitCount �� �����ɂȂ�����
                {

                    //ReflectBall(collision.gameObject.GetComponent<Rigidbody>());//�{�[���𒵂˕Ԃ�
                    Destroy(gameObject); // �u���b�N����
                    //destroyedBlockCount++; // �j�󂳂ꂽ�u���b�N���𑝂₷
                    //Debug.Log("destroyedBlockCount: " + destroyedBlockCount);
                    blocks.Remove(gameObject);
                    // �{�[����Renderer�R���|�[�l���g���擾
                    Renderer ballRenderer = collision.gameObject.GetComponent<Renderer>();
                }
                else//�łȂ����
                {

                    Renderer blockRenderer = GetComponent<Renderer>();
                    if (maxHitCount - hitCount == 1)
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
                        if (maxHitCount - hitCount == 2)
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
                            if (maxHitCount - hitCount == 3)
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
                                if (maxHitCount - hitCount == 4)
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
                                    if (maxHitCount - hitCount == 5)
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
                                            float grayValue = (float)(0.75 - ((maxHitCount - hitCount) / 100));
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
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))//�u���b�N�폜(�Q�[���I��)
        {
            BlocksDestroy();
        }

        //if (destroyedBlockCount >= totalBlocks) Debug.Log("All blocks destroyed!" + totalBlocks + destroyedBlockCount);

        //���g���C(���X�^�[�g)
        if (Input.GetKeyDown(KeyCode.B))
        {
            StageMode++;
            if (StageMode == 6) StageMode = 0;
            Debug.Log("Stage: " + StageMode);
            GenerateBlocksStageRestart(StageMode);//�����Ŏw�肵���X�e�[�W�����g���C(���X�^�[�g)����
        }

    }
}