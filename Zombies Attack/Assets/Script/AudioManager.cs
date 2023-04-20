using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip []audioClip; 
    public AudioSource audioSource;

    public int i;

    // Update is called once per frame
    void Update()
    {
        if (audioClip[i].length == audioSource.time) 
        {
            i++;
            audioSource.clip = audioClip[i];
            audioSource.Play();
        }
    }
}
