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
        for (x = -10; x < 15; x += 5)
        {
            for (z = 20; z > 0; z -= 5)
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

                // ���������u���b�N�����X�g�ɒǉ�
                blocks.Add(block);
            }
        }
    }

    // �u���b�N���{�[���ɐG�ꂽ��쓮����֐�
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")//�����{�[���ɐG�ꂽ��
        {
            //ReflectBall(collision.gameObject.GetComponent<Rigidbody>());//�{�[���𒵂˕Ԃ�
            Destroy(gameObject);//(�{�[���ɐG�ꂽ)�u���b�N�폜


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
    }

    //�u���b�N�������
    void GenerateBlocksCreate(float x, float z)
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

        // ���������u���b�N�����X�g�ɒǉ�
        blocks.Add(block);
    }

    //�X�e�[�W�����̊֐�
    void GenerateBlocksCreateStage(int stage)
    {
        if (stage == 0)
        {
            SimpleGenerateBlocks();//�V���v���X�e�[�W�𐶐�
        }

        if (stage == 1)
        {
            GenerateBlocksCreate(5, 20);//���̕���(���W��ς���)�����R�s�y����
            GenerateBlocksCreate(0, 15);
            GenerateBlocksCreate(10, 15);
            GenerateBlocksCreate(5, 10);
        }

        if (stage == 2)
        {
            GenerateBlocksCreate(-10, 20);//���̕���(���W��ς���)�����R�s�y����
            GenerateBlocksCreate(15, 20);
            GenerateBlocksCreate(-5, 15);
            GenerateBlocksCreate(10, 15);
            GenerateBlocksCreate(0, 10);
            GenerateBlocksCreate(5, 10);
        }

        if (stage == 3)
        {
            GenerateBlocksCreate(-10, 10);//���̕���(���W��ς���)�����R�s�y����
            GenerateBlocksCreate(15, 10);
            GenerateBlocksCreate(-5, 15);
            GenerateBlocksCreate(10, 15);
            GenerateBlocksCreate(0, 20);
            GenerateBlocksCreate(5, 20);
        }

        if (stage == 4)
        {
            GenerateBlocksCreate(-10, 20);//���̕���(���W��ς���)�����R�s�y����
            GenerateBlocksCreate(-5, 15);
            GenerateBlocksCreate(0, 10);
            GenerateBlocksCreate(10, 5);
            GenerateBlocksCreate(15, 0);
        }

        if (stage == 5)
        {
            GenerateBlocksCreate(-10, 0);//���̕���(���W��ς���)�����R�s�y����
            GenerateBlocksCreate(-5, 5);
            GenerateBlocksCreate(0, 10);
            GenerateBlocksCreate(10, 15);
            GenerateBlocksCreate(15, 20);
        }
        if (stage == 6)
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
                    GenerateBlocksCreate(x, z);
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
        if (Input.GetKeyDown(KeyCode.Space))//�����X�y�[�X�L�[�������ꂽ��
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


        if (Input.GetKeyDown(KeyCode.M))//�u���b�N�폜(�Q�[���I��)
        {
            BlocksDestroy();
        }

        //�X�e�[�W����0
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            GenerateBlocksCreateStage(0);//�����Ŏw�肵���X�e�[�W��ǂݍ���
        }

        //���g���C(���X�^�[�g)0
        if (Input.GetKeyDown(KeyCode.P))
        {
            GenerateBlocksStageRestart(0);//�����Ŏw�肵���X�e�[�W�����g���C(���X�^�[�g)����
        }


        //�X�e�[�W����1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GenerateBlocksCreateStage(1);//�����Ŏw�肵���X�e�[�W��ǂݍ���
        }

        //���g���C(���X�^�[�g)1
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GenerateBlocksStageRestart(1);//�����Ŏw�肵���X�e�[�W�����g���C(���X�^�[�g)����
        }


        //�X�e�[�W����2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GenerateBlocksCreateStage(2);//�����Ŏw�肵���X�e�[�W��ǂݍ���
        }

        //���g���C(���X�^�[�g)2
        if (Input.GetKeyDown(KeyCode.X))
        {
            GenerateBlocksStageRestart(2);//�����Ŏw�肵���X�e�[�W�����g���C(���X�^�[�g)����
        }


        //�X�e�[�W����3
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GenerateBlocksCreateStage(3);//�����Ŏw�肵���X�e�[�W��ǂݍ���
        }

        //���g���C(���X�^�[�g)3
        if (Input.GetKeyDown(KeyCode.C))
        {
            GenerateBlocksStageRestart(3);//�����Ŏw�肵���X�e�[�W�����g���C(���X�^�[�g)����
        }


        //�X�e�[�W����4
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GenerateBlocksCreateStage(4);//�����Ŏw�肵���X�e�[�W��ǂݍ���
        }

        //���g���C(���X�^�[�g)4
        if (Input.GetKeyDown(KeyCode.V))
        {
            GenerateBlocksStageRestart(4);//�����Ŏw�肵���X�e�[�W�����g���C(���X�^�[�g)����
        }


        //�X�e�[�W����5
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GenerateBlocksCreateStage(5);//�����Ŏw�肵���X�e�[�W��ǂݍ���
        }

        //���g���C(���X�^�[�g)5
        if (Input.GetKeyDown(KeyCode.B))
        {
            GenerateBlocksStageRestart(5);//�����Ŏw�肵���X�e�[�W�����g���C(���X�^�[�g)����
        }


    }
}
