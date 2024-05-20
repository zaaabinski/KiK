using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private List<Sprite> MapList= new List<Sprite>();
    [SerializeField] private Image MapImage;
    public static int mapIndex = 0;

    [SerializeField] internal List<AudioClip> ChangeSceneSounds = new List<AudioClip>();
    [SerializeField] internal List<AudioClip> LeaveGameSounds = new List<AudioClip>();

    [SerializeField] private AudioSource CSSource;
    [SerializeField] private AudioSource QASource;


    public void ChangeScene()
    {
        StartCoroutine(ReallySophisticatedAndComplicatedAlghorytyhmForDelayingAsMuchTimeAsPossible());
    }

    public void QuitGame()
    {
        StartCoroutine(MomentBeforeYouRunAwayToYourMother());
    }

    public void BackToMenu()
    {
        StartCoroutine(Teleporting());
    }

    public void ChangeMapRight()
    {
        Debug.Log((++mapIndex) % MapList.Count);
        MapImage.sprite = MapList[(mapIndex)%MapList.Count];
        
    }
    public void ChangeMapLeft()
    {
        Debug.Log((Mathf.Abs(--mapIndex)) % MapList.Count);
        MapImage.sprite = MapList[(Mathf.Abs(mapIndex))%MapList.Count];
    }

    IEnumerator Teleporting()
    {
        QASource.clip = LeaveGameSounds[1];
        QASource.Play();
        yield return new WaitForSeconds(LeaveGameSounds[1].length+0.2f);
        SceneManager.LoadScene(0);
    }

    IEnumerator ReallySophisticatedAndComplicatedAlghorytyhmForDelayingAsMuchTimeAsPossible()
    {
        int rand=Random.Range(0,ChangeSceneSounds.Count);
        CSSource.clip= ChangeSceneSounds[rand];
        CSSource.Play();
        yield return new WaitForSeconds(ChangeSceneSounds[rand].length+0.2f);
        SceneManager.LoadScene(1);
    }

    IEnumerator MomentBeforeYouRunAwayToYourMother()
    {
        int rand = Random.Range(0, LeaveGameSounds.Count);
        QASource.clip = LeaveGameSounds[rand];
        QASource.Play();
        yield return new WaitForSeconds(LeaveGameSounds[rand].length+0.2f);
        Application.Quit();
        Debug.Log("NAURA");
    }

    

}
