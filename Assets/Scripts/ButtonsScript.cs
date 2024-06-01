using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonsScript : MonoBehaviour
{
    [SerializeField] private List<Sprite> mapList = new List<Sprite>();
    [SerializeField] private Image mapImage;
    [SerializeField] private TextMeshProUGUI textPlace;
    private int mapIndex;

    [SerializeField] internal List<AudioClip> changeSceneSounds = new List<AudioClip>();
    [SerializeField] internal List<AudioClip> leaveGameSounds = new List<AudioClip>();

    [SerializeField] private AudioSource csSource;
    [SerializeField] private AudioSource qsSource;

    public static string mapName = "";

    [SerializeField] private TextMeshProUGUI reminderText;

    [SerializeField] TMP_InputField simNumber;

    [SerializeField] internal Button startSimButton;

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
        //set basic values for map choosing
        mapIndex = 0;
        mapImage.sprite = mapList[mapIndex];
        textPlace.text = "\n\n" + mapList[mapIndex].name;
        startSimButton.interactable = true;
    }

    public void ChangeScene()
    {
        StartCoroutine(ReallySophisticatedAndComplicatedAlghorytyhmForDelayingAsMuchTimeAsPossible(1));
    }

    public void StartSim()
    {
        mapName = mapImage.sprite.name;
        if (simNumber.text.Equals(""))
        {
            StartCoroutine(ReminderToWriteNumber());
        }
        else
        {
            startSimButton.interactable = false;
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
        if (mapIndex + 1 >= mapList.Count)
        {
            mapIndex = 0;
            mapImage.sprite = mapList[mapIndex];
            textPlace.text = "\n\n" + mapImage.sprite.name;
        }
        else
        {
            mapIndex += 1;
            mapImage.sprite = mapList[mapIndex];
            textPlace.text = "\n\n" + mapImage.sprite.name;
        }
    }

    public void ChangeMapLeft()
    {
        //load next map by index left
        if (mapIndex - 1 < 0)
        {
            mapIndex = mapList.Count - 1;
            mapImage.sprite = mapList[mapIndex];
            textPlace.text = "\n\n" + mapImage.sprite.name;
        }
        else
        {
            mapIndex -= 1;
            mapImage.sprite = mapList[mapIndex];
            textPlace.text = "\n\n" + mapImage.sprite.name;
        }
    }

    public void MuteOrUnMute()
    {
        if (RepeatSimulation.musicSource.volume > 0)
        {
            RepeatSimulation.musicSource.volume = 0;
        }
        else
        {
            RepeatSimulation.musicSource.volume = 1;
        }
    }

    IEnumerator Teleporting()
    {
        //loads scene with index 0 after playing sound
        qsSource.clip = leaveGameSounds[1];
        qsSource.Play();
        yield return new WaitForSeconds(leaveGameSounds[1].length + 0.2f);
        SceneManager.LoadScene(0);
        RepeatSimulation.musicSource.Stop();
    }

    IEnumerator ReallySophisticatedAndComplicatedAlghorytyhmForDelayingAsMuchTimeAsPossible(int i)
    {
        //loads tournament scene
        int rand = Random.Range(0, changeSceneSounds.Count);
        csSource.clip = changeSceneSounds[rand];
        csSource.Play();
        yield return new WaitForSeconds(changeSceneSounds[rand].length + 0.15f);
        SceneManager.LoadScene(i);
    }

    IEnumerator MomentBeforeYouRunAwayToYourMother()
    {
        //waits till sound is over then quit application
        int rand = Random.Range(0, leaveGameSounds.Count);
        qsSource.clip = leaveGameSounds[rand];
        qsSource.Play();
        yield return new WaitForSeconds(leaveGameSounds[rand].length + 0.2f);
        Application.Quit();
        Debug.Log("NAURA");
    }

    IEnumerator ReminderToWriteNumber()
    {
        reminderText.text = "\n\nMusisz wpisac jakas liczbe";
        yield return new WaitForSeconds(2f);
        reminderText.text = "";
    }
}