using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private List<Sprite> MapList = new List<Sprite>();
    [SerializeField] private Image MapImage;
    [SerializeField] private TextMeshProUGUI textPlace;
    private int mapIndex;

    [SerializeField] internal List<AudioClip> ChangeSceneSounds = new List<AudioClip>();
    [SerializeField] internal List<AudioClip> LeaveGameSounds = new List<AudioClip>();

    [SerializeField] private AudioSource CSSource;
    [SerializeField] private AudioSource QASource;

    public static string mapName="";

    [SerializeField] private TextMeshProUGUI ReminderText;

    [SerializeField] TMP_InputField simNumber;

    [SerializeField] internal Button StartSimButton;

    public void Start()
    {
        
        //check if scene is the map selection
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            CheckIfMapScene();
        }
        
    }
    
    private void CheckIfMapScene()
    {
        //set basic values for map chosing
        mapIndex = 0;
        MapImage.sprite = MapList[mapIndex];
        textPlace.text = "\n\n" + MapList[mapIndex].name;
        StartSimButton.interactable = true;
    }

    public void ChangeScene()
    {
        StartCoroutine(ReallySophisticatedAndComplicatedAlghorytyhmForDelayingAsMuchTimeAsPossible(1));
    }

    public void StartSim()
    {

        mapName = MapImage.sprite.name;
        if (simNumber.text.Equals(""))
        {
            StartCoroutine(ReminderToWriteNumber());
        }
        else
        {
            StartSimButton.interactable=false;
            RepeatSimulation.howManyLoops = int.Parse(simNumber.text);
            StartCoroutine(ReallySophisticatedAndComplicatedAlghorytyhmForDelayingAsMuchTimeAsPossible(2));
            
        }
         
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
        //load next map by index right
        if (mapIndex + 1 >= MapList.Count)
        {
            mapIndex = 0;
            MapImage.sprite = MapList[mapIndex];
            textPlace.text = "\n\n" + MapImage.sprite.name;
        }
        else
        {
            mapIndex += 1;
            MapImage.sprite = MapList[mapIndex];
            textPlace.text = "\n\n" + MapImage.sprite.name;
        }
    }

    public void ChangeMapLeft()
    {
        //load next map by index left
        if (mapIndex - 1 < 0)
        {
            mapIndex = MapList.Count - 1;
            MapImage.sprite = MapList[mapIndex];
            textPlace.text = "\n\n" + MapImage.sprite.name;
        }
        else
        {
            mapIndex -= 1;
            MapImage.sprite = MapList[mapIndex];
            textPlace.text = "\n\n" + MapImage.sprite.name;
        }
    }

    IEnumerator Teleporting()
    {
        //loads scene with index 0 after playing sound
        QASource.clip = LeaveGameSounds[1];
        QASource.Play();
        yield return new WaitForSeconds(LeaveGameSounds[1].length + 0.2f);
        SceneManager.LoadScene(0);
        RepeatSimulation.musicSource.Stop();
    }

    IEnumerator ReallySophisticatedAndComplicatedAlghorytyhmForDelayingAsMuchTimeAsPossible(int i)
    {
        //loads tournament scene
        int rand = Random.Range(0, ChangeSceneSounds.Count);
        CSSource.clip = ChangeSceneSounds[rand];
        CSSource.Play();
        yield return new WaitForSeconds(ChangeSceneSounds[rand].length + 0.15f);
        SceneManager.LoadScene(i);
    }

    IEnumerator MomentBeforeYouRunAwayToYourMother()
    {
        //waits till sound is over then quit application
        int rand = Random.Range(0, LeaveGameSounds.Count);
        QASource.clip = LeaveGameSounds[rand];
        QASource.Play();
        yield return new WaitForSeconds(LeaveGameSounds[rand].length + 0.2f);
        Application.Quit();
        Debug.Log("NAURA");
    }


    IEnumerator ReminderToWriteNumber()
    {
        ReminderText.text = "\n\nMusisz wpisac jakas liczbe";
        yield return new WaitForSeconds(2f);
        ReminderText.text = "";
    }
}
