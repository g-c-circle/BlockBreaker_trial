using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockscript : MonoBehaviour
{
    public GameObject BlockObject;
    // Start is called before the first frame update
    void Start()
    {
        int i, j;
        for (i = -10; i < 20; i = i+5)
        {
            for (j = 0; j < -20; j = j-5)
            {
                Instantiate(BlockObject, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
        
    }

    //�u���b�N���{�[���ɐG�ꂽ��쓮����֐�
    private void OnCollisionEnter(Collision collision)//(�u���b�N��)�����ɐG�ꂽ��
    {
        if(collision.gameObject.name == "debug(sphere)")//�����A�G�ꂽ���̂��{�[����������
        {
            Destroy(gameObject);//�u���b�N(�������g)���폜����
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
