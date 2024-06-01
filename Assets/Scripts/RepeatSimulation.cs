using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RepeatSimulation : MonoBehaviour
{
    internal static int loopCounter = 0;
    internal static int howManyLoops = 0;
    internal static AudioSource musicSource;
    //[SerializeField] private AudioClip musicClip;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
        StartPlayingMusic();
        musicSource.volume = 1;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            loopCounter = 0;
        }
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