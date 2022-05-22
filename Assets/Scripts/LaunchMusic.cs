using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMusic : MonoBehaviour
{
    public AudioClip Music;
    public AudioClip EndMusic;
    AudioSource audioSource;
    public static int end = 0;
    static int started_end = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            ObjectsScript.start = 1;
            audioSource.clip = Music;
            audioSource.Play();         
        }
        if (end == 1 && started_end == 0)
        {
            started_end = 1;
            audioSource.clip = EndMusic;
            audioSource.Play();
        }
    }
}
