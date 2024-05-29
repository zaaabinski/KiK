using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RepeatSimulation : MonoBehaviour
{

    internal static int loopCounter=0;
    internal static int howManyLoops=0;
    private static AudioSource musicSource;
    //[SerializeField] private AudioClip musicClip;

    private void Awake()
    {
        musicSource=GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
        StartPlayingMusic();
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
/*    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (loopCounter<howManyLoops)
            {
                WaitOnDemand();
            }
        }
    }

    IEnumerator WaitOnDemand()
    {
        loopCounter++;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
    }*/
