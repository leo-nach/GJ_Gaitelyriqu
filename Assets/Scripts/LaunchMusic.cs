using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMusic : MonoBehaviour
{
    public AudioClip Music;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = Music;
            audioSource.Play();         
        }
        
        /*if (Radiodetente)
        {
            audiosource.clip = FinDuGame;
            audioSource.Play();
        }*/
    }
}
