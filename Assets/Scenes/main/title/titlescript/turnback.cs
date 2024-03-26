using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class turnback : MonoBehaviour
{
    [SerializeField] GameObject Settingpanel;
    [SerializeField] GameObject Titlepanel;
    [SerializeField] GameObject Stageselectpanel;
    [SerializeField] private AudioClip b1;
    [SerializeField] AudioSource seAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnButton()
    {
        Settingpanel.SetActive(false);
        Titlepanel.SetActive(true);
        Stageselectpanel.SetActive(false);
        seAudioSource.PlayOneShot(b1);
    }


}
