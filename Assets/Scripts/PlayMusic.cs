using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private AudioSource musicSource;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartPlayingMusic() 
    {
        musicSource.Play();
    }

    public void StopPlayingMusic() 
    {
        musicSource.Stop();
    }
}
