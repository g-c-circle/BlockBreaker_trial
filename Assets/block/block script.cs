using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject BlockObject;
    private Vector3 initialSize = new Vector3(3f, 1f, 1f); // �����̑傫��
    private Vector3 currentSize; // ���݂̑傫��
    public Color blockColor = Color.white; // �u���b�N�̐F
    public Vector3 blockRotation = new Vector3(0f, 0f, 0f); // �u���b�N�̊p�x

    // Start is called before the first frame update
    void Start()
    {
        currentSize = initialSize;//���݂̑傫���ɏ����l��ݒ�
        GenerateBlocks();//�u���b�N����
    }

    // �u���b�N�����̊֐�
    void GenerateBlocks()
    {
        int x, y;
        for (x = -10; x < 15; x += 5)
        {
            for (y = 20; y > 0; y -= 5)
            {
                GameObject block = Instantiate(BlockObject, new Vector3(x, y, 0), Quaternion.Euler(blockRotation));
                block.transform.localScale = currentSize;

                // �u���b�N�̐F��ݒ�
                Renderer renderer = block.GetComponent<Renderer>();
                if (renderer != null)
                {
                    Material material = new Material(renderer.material);
                    material.color = blockColor;
                    renderer.material = material;
                }
            }
        }
    }

    // �u���b�N���{�[���ɐG�ꂽ��쓮����֐�
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "debug(sphere)")//�����{�[���ɐG�ꂽ��
        {
            Destroy(gameObject);//�u���b�N�폜
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ�班���傫������
        if (Input.GetKeyDown(KeyCode.Space))//�����X�y�[�X�L�[�������ꂽ��
        {
            blockColor = new Color(Random.value, Random.value, Random.value);//�F�ϐ���ύX(�����_��)
            currentSize += new Vector3(0.1f, 0.1f, 0.1f);//�傫���ϐ���ύX(�����傫��)
            blockRotation = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));//�p�x�ϐ���ύX(�����_��)
            GenerateBlocks(); // �u���b�N���Đ������ĐV�����傫���𔽉f
        }
    }
}
