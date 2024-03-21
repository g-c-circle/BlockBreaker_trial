using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainSoundScript : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider seSlider;


    public bool DontDestroyEnabled = true;
    public static MainSoundScript instance;
    // Start is called before the first frame update
    void Start()
    {
        //�V�[�����ς���Ă��I�u�W�F�N�g���c��
        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(this);
        }
        //�X���C�_�[����������特�ʂ��ω�����
        bgmSlider.onValueChanged.AddListener((value) =>
        {
            Debug.Log("BGM Slider Value: " + value);
            value = Mathf.Clamp01(value);
            //�ω�����̂�-80~0�܂ł̊�
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            audioMixer.SetFloat("BGM", decibel);
        });

        //�X���C�_�[����������特�ʂ��ω�����
        seSlider.onValueChanged.AddListener((value) =>
        {
            Debug.Log("SE Slider Value: " + value);
            value = Mathf.Clamp01(value);
            //�ω�����̂�-80~0�܂ł̊�
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            audioMixer.SetFloat("SE", decibel);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        CheckInstance();
    }

    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
