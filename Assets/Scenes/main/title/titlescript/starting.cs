using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class starting : MonoBehaviour
{
    [SerializeField] GameObject Titlepanel;
    [SerializeField] private AudioClip b1;
    [SerializeField] GameObject Stageselectpanel;
    [SerializeField] AudioSource seAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void StartButton()
    {
        Titlepanel.SetActive(false);
        Stageselectpanel.SetActive(true);
        seAudioSource.PlayOneShot(b1);
    }

}
