using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    [SerializeField] GameObject Titlepanel;
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

    public void StartingButton()
    {
        Titlepanel.SetActive(false);
        seAudioSource.PlayOneShot(b1);
    }

}
