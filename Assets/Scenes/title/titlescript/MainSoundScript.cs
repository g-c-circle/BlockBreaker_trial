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
        //シーンが変わってもオブジェクトが残る
        if (DontDestroyEnabled)
        {
            DontDestroyOnLoad(this);
        }
        //スライダーをさわったら音量が変化する
        BgmSlider.onValueChanged.AddListener((value) =>
        {
            Debug.Log("BGM Slider Value: " + value);
            value = Mathf.Clamp01(value);
            //変化するのは-80~0までの間
            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            AudioMixer.SetFloat("BGM", decibel);
        });

        //スライダーをさわったら音量が変化する
        SeSlider.onValueChanged.AddListener((value) =>
        {
            Debug.Log("SE Slider Value: " + value);
            value = Mathf.Clamp01(value);
            //変化するのは-80~0までの間
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
