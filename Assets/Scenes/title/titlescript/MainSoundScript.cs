using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainSoundScript : MonoBehaviour
{
    [SerializeField] AudioMixer AudioMixer;
    [SerializeField] AudioSource BgmAudioSource;
    [SerializeField] AudioSource SeAudioSource;
    [SerializeField] Slider BgmSlider;
    [SerializeField] Slider SeSlider;


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
        BgmSlider.onValueChanged.AddListener((value) =>
        {
            Debug.Log("BGM Slider Value: " + value);
            value = Mathf.Clamp01(value);
            //�ω�����̂�-80~0�܂ł̊�
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            AudioMixer.SetFloat("BGM", decibel);
        });

        //�X���C�_�[����������特�ʂ��ω�����
        SeSlider.onValueChanged.AddListener((value) =>
        {
            Debug.Log("SE Slider Value: " + value);
            value = Mathf.Clamp01(value);
            //�ω�����̂�-80~0�܂ł̊�
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            AudioMixer.SetFloat("SE", decibel);
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
