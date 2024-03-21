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
        //シーンが変わってもオブジェクトが残る
        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(this);
        }
        //スライダーをさわったら音量が変化する
        bgmSlider.onValueChanged.AddListener((value) =>
        {
            Debug.Log("BGM Slider Value: " + value);
            value = Mathf.Clamp01(value);
            //変化するのは-80~0までの間
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            audioMixer.SetFloat("BGM", decibel);
        });

        //スライダーをさわったら音量が変化する
        seSlider.onValueChanged.AddListener((value) =>
        {
            Debug.Log("SE Slider Value: " + value);
            value = Mathf.Clamp01(value);
            //変化するのは-80~0までの間
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
