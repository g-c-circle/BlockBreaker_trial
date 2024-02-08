using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBlocks : MonoBehaviour
{
    public GameObject BlockObject;

    private Vector3 initialSize = new Vector3(3f, 1f, 1f); // �����̑傫��
    private Vector3 currentSize; // ���݂̑傫��

    private Color blockColor = Color.white; // �u���b�N�̐F
    public Vector3 blockRotation = new Vector3(0f, 0f, 0f); // �u���b�N�̊p�x

    private List<GameObject> blocks = new List<GameObject>(); // �u���b�N�I�u�W�F�N�g���i�[���郊�X�g

    public float constantSpeed = 5.0f; // ���̑��x
    private Rigidbody ballRigidbody;

    int mode = 0;
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
        //GenerateBlocksCreateStage(0); // �u���b�N����
        GenerateBlocksCreateStage(6); // �u���b�N����

        ballRigidbody = GetComponent<Rigidbody>();
        // �{�[���ɕ����I�Ȕ�����ݒ�
        //ballRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        //ballRigidbody.isKinematic = false;
        //ballRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    //�u���b�N�����̊֐�(�X�e�[�W0)
    void SimpleGenerateBlocks()
    {
        int x, z;//�u���b�N�̍��W�ϐ�
        for (x = -6; x < 5; x += 5)
        {
            for (z = 12; z > 2; z -= 3)
            {
                // �u���b�N����
                GameObject block = Instantiate(BlockObject, new Vector3(x, 0, z), Quaternion.Euler(blockRotation));
                block.transform.localScale = currentSize;

                // �u���b�N�̐F��ݒ�
                Renderer renderer = block.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Material material = new Material(renderer.material);
                    material.color = blockColor;
                    renderer.material = material;
                }

                block.GetComponent<GenerateBlocks>().maxHitCount = 1;

                // ���������u���b�N�����X�g�ɒǉ�
                blocks.Add(block);

                //totalBlocks++;
            }
        }
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
                    // �V���������_���F�𐶐�
                    blockColor = new Color(Random.value, Random.value, Random.value);

                    //���[�h�P��������
                    if (mode == 1)
                    {

                        // �{�[���̃}�e���A���̐F��ύX
                        if (ballRenderer != null)
                        {
                            Material material = new Material(ballRenderer.material);
                            material.color = blockColor;
                            ballRenderer.material = material;
                        }

                        collision.gameObject.transform.localScale = Vector3.one * 2f;//�{�[���̑傫����ύX

                        GameObject newBall = Instantiate(collision.gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + currentSize.z), Quaternion.identity);//�{�[���𕡐�

                        newBall.tag = "Ball";

                        GameObject[] allBalls = GameObject.FindGameObjectsWithTag("Ball");
                        foreach (GameObject ball in allBalls)
                        {
                            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
                            if (ballRigidbody != null)
                            {
                                ballRigidbody.velocity *= 5f; // ���x���ܔ{�ɂ���
                            }
                        }

                        ChangeOtherBlocksColor();//�u���b�N�̐F��ύX
                    }
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

    //void ReflectBall(Rigidbody ballRigidbody)
    //{
    //    if (ballRigidbody != null)
    //    {
    //        // ���ˊp�x���v�Z
    //        Vector3 reflection = Vector3.Reflect(ballRigidbody.velocity, Vector3.up);
    //        ballRigidbody.velocity = reflection.normalized * constantSpeed;
    //    }
    //}

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
    void GenerateBlocksCreate(float x, float z, int maxHitCount)// �u���b�N������܂ł̍ő�q�b�g�񐔂�[maxHitCount]��
    {
        GameObject block = Instantiate(BlockObject, new Vector3(x, 0, z), Quaternion.Euler(blockRotation));
        block.transform.localScale = currentSize;

        // �u���b�N�̐F��ݒ�
        Renderer renderer = block.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material material = new Material(renderer.material);
            material.color = blockColor;
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
        if (stage == 0)//�V���v��
        {
            SimpleGenerateBlocks();//�V���v���X�e�[�W�𐶐�
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
                    GenerateBlocksCreate(x, z, 1);
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
                    GenerateBlocksCreate(x, z, 2);
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
                    GenerateBlocksCreate(x, z, 3);
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
                    GenerateBlocksCreate(x, z, 4);
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
                    GenerateBlocksCreate(x, z, 5);
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
                    GenerateBlocksCreate(x, z, 1);// �u���b�N������܂ł̍ő�q�b�g�񐔂�ǉ�
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


    void ChangeOtherBlocksColor()//�u���b�N�̐F��ύX����֐�
    {
        foreach (var block in blocks)
        {
            //���������ɍ�������F��ύX�i�����ł̓����_���F�ɂ��Ă��܂��j
            if (block != null && block != gameObject)
            {
                Renderer blockRenderer = block.GetComponent<Renderer>();
                if (blockRenderer != null)
                {
                    blockRenderer.material.color = new Color(Random.value, Random.value, Random.value);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ��u���b�N�̑傫���E�p�x�E�F��ύX����
        if (Input.GetKeyDown(KeyCode.V))//�����X�y�[�X�L�[�������ꂽ��
        {
            blockColor = new Color(Random.value, Random.value, Random.value);//�F�ϐ���ύX(�����_��)
            currentSize += new Vector3(0.1f, 0.1f, 0.1f);//�傫���ϐ���ύX(�����傫��)
            blockRotation = new Vector3(0f, Random.Range(0f, 360f), 0f);//�p�x�ϐ���ύX(�����_��)


            //�u���b�N�̑傫����ύX
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    block.transform.localScale = currentSize;
                }
            }

            //�u���b�N�̊p�x��ύX
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    block.transform.rotation = Quaternion.Euler(blockRotation);
                }
            }

            //�u���b�N�̐F��ύX
            foreach (var block in blocks)
            {
                if (block != null)
                {
                    Renderer blockRenderer = block.GetComponent<Renderer>();
                    if (blockRenderer != null)
                    {
                        Material material = new Material(blockRenderer.material);
                        material.color = blockColor;
                        blockRenderer.material = material;
                    }
                }
            }

        }

        //���[�h�؂�ւ�
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mode == 0)
            {
                mode = 1;
            }
            else
            {
                mode = 0;
            }
        }

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