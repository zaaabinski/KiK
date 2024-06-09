using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.IO;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class Tournament : MonoBehaviour
{
    private Duel duelScript;

    [SerializeField] private Image winnerImage;
    [SerializeField] private GameObject[] currentRound;
    [SerializeField] private Image[] imageRoundList;
    private int round = 0;

    [SerializeField] private List<ParticipantScriptable> warriorScriptable = new List<ParticipantScriptable>();
    [SerializeField] private List<ParticipantScriptable> mageScriptable = new List<ParticipantScriptable>();
    [SerializeField] private List<ParticipantScriptable> rougeScriptable = new List<ParticipantScriptable>();
    [SerializeField] private List<ParticipantScriptable> bardScriptable = new List<ParticipantScriptable>();

    private List<Participant> particpantList = new List<Participant>();
    private List<Participant> tournamentList = new List<Participant>();

    [SerializeField] private List<int> idList = new List<int>();
    [SerializeField] private List<int> idToDelte = new List<int>();

    [SerializeField] private List<Sprite> maklowicz = new List<Sprite>();
    [SerializeField] private Image tamGdzieWspanialyCzlowiekRezyduje;

    [SerializeField] private TextMeshProUGUI progresstext;
    [SerializeField] private TextMeshProUGUI simcounterText;

    private void Awake()
    {
        //get refference to duel script
        duelScript = GetComponent<Duel>();
        Debug.Log(ButtonsScript.mapName);
        progresstext.text = "\n\nSymulacja trwa";
    }

    void Start()
    {
        //set all starting parameters, use all functions
        //Debug.Log("Sim: " + RepeatSimulation.howManyLoops);
        if (RepeatSimulation.loopCounter < RepeatSimulation.howManyLoops)
        {
            Participant.pID = -1;
            round = 0;
            tournamentList.Clear();
            CreateParticpants();
            MaklowiczMood();
            RandomizeParticpantsId();
            GetImages(currentRound[round]);
            StartRound();
            StartCoroutine(WaitOnDemand());
        }
    }

    Participant secondPlace;
    void StartRound()
    {
        // clear idToDelete table each round to make sure the ids dont overlap
        idToDelte.Clear();
        // get ids of both fighters that have a round togheter and make them duel
        //refil their hp and add their IDs to the table which is used later
        for (int i = 0; i < tournamentList.Count; i += 2)
        {
            int deletedID = duelScript.DuelOfTheFates(tournamentList[i], tournamentList[i + 1]);
            if (tournamentList[i].id != deletedID)
            {
                ColdBeerToRefillYourWillToFight(tournamentList[i]);
                SaveToFile(i + 1, tournamentList[i]);
            }
            else
            {
                ColdBeerToRefillYourWillToFight(tournamentList[i + 1]);
                SaveToFile(i, tournamentList[i + 1]);
            }
            if(round==3)
            {
                for(int j=0;j< tournamentList.Count;j++)
                {
                    if (tournamentList[j].id==deletedID)
                    {
                        secondPlace = tournamentList[j];
                    }    
                }
            }
            idToDelte.Add(deletedID);
        }

        // go through whole list of idtodelete and delete particpants whose id match
        for (int j = 0; j < idToDelte.Count; j++)
        {
            for (int i = tournamentList.Count - 1; i >= 0; i--)
            {
                if (idToDelte[j] == tournamentList[i].id)
                {
                    tournamentList.RemoveAt(i);
                    idList.RemoveAt(i);
                    break;
                }
            }
        }

        //if not finale start another round
        if (round < 3)
        {
            round++;
            GetImages(currentRound[round]);
            StartRound();
        }
        //if finale end simulation and show winner
        else if (round == 3)
        {
            //Debug.Log(tournamentList[0].name + " Wins!");
            winnerImage.sprite = tournamentList[0].sprite;
            SaveWinnerToFile(secondPlace);
        }
    }

    //refill fighters hp after the round is complete
    void ColdBeerToRefillYourWillToFight(Participant BraveGladiator)
    {
        BraveGladiator.hp = BraveGladiator.maxHP;
    }

    void RandomizeParticpantsId()
    {
        //while id list isnt full get random id number
        bool canAdd = true;
        while (idList.Count < 16)
        {
            canAdd = true;
            int rand = Random.Range(0, 16);
            for (int i = 0; i < idList.Count; i++)
            {
                if (idList[i] == rand)
                {
                    canAdd = false;
                    break;
                }
            }

            if (canAdd)
            {
                idList.Add(rand);
            }
        }

        //add object that has id corresponding to id list
        for (int i = 0; i < idList.Count; i++)
        {
            for (int j = 0; j < particpantList.Count; j++)
            {
                if (particpantList[j].id == idList[i])
                {
                    tournamentList.Add(particpantList[j]);
                    break;
                }
            }
        }
    }

    void GetImages(GameObject currentRound)
    {
        //get children of round game object, children have image component that is swaped for fighter sprite
        imageRoundList = new Image[tournamentList.Count];
        imageRoundList = currentRound.GetComponentsInChildren<Image>();

        for (int i = 0; i < tournamentList.Count; i++)
        {
            for (int j = 0; j < idList.Count; j++)
            {
                if (idList[j] == tournamentList[i].id)
                {
                    imageRoundList[i].sprite = tournamentList[j].sprite;
                }
            }
        }
    }

    //creates all objects
    void CreateParticpants()
    {
        for (int i = 0; i < 4; i++)
        {
            particpantList.Add(new Warrior(warriorScriptable[i]));
            particpantList.Add(new Mage(mageScriptable[i]));
            particpantList.Add(new Rouge(rougeScriptable[i]));
            particpantList.Add(new Bard(bardScriptable[i]));
        }
    }


    void SaveWinnerToFile(Participant secondPlace)
    {
        //save winner to .txt file
        var fileLocation = "WinnersFile.txt";
        using StreamWriter writer = new(fileLocation, append: true);
        if (File.Exists(fileLocation))
        {
            if (new FileInfo(fileLocation).Length == 0)
            {
                writer.WriteLine(
                    "Id postaci;Imie postaci;Klasa postaci;Otrzymane obrazenia;Zadane obrazenia;U¿yte ataki podstawowe;U¿yte silne ataki;U¿yte ataki krzykiem;U¿yte ataki specjalne;Ile spud³owano;Mapa;Z kim wygra³?;Z jak¹ klasa?") ;
            }

            writer.WriteLine(idList[0] + ";" + tournamentList[0].name + ";" + tournamentList[0].GetType() + ";" +
                             tournamentList[0].receivedDamage + ";" + tournamentList[0].dealtDamage + ";" +
                             tournamentList[0].usedNormalAttacks + ";" + tournamentList[0].usedStrongAttacks + ";" +
                             tournamentList[0].usedScreamAttacks + ";" + tournamentList[0].usedSpecialAttacks + ";" +
                             tournamentList[0].missedAttacks + ";" + ButtonsScript.mapName + ";" + secondPlace.name + ";" + secondPlace.GetType());
        }
        secondPlace.name = "Godny kuboty";
        SaveToFile(0, secondPlace);
    }

    void SaveWarriorsToFile(int i, Participant whomLosedTo)
    {
        //save warriors to .txt file
        var fileLocation = "WarriorsFile.txt";
        using StreamWriter writer = new(fileLocation, append: true);
        if (File.Exists(fileLocation))
        {
            if (new FileInfo(fileLocation).Length == 0)
            {
                writer.WriteLine(
                    "Id postaci;Imie postaci;Otrzymane obrazenia;Zadane obrazenia;U¿yte ataki podstawowe;U¿yte silne ataki;U¿yte ataki krzykiem;U¿yte ataki specjalne;Ile spud³owano;Mapa;Runda;Z kim przegral;Z jak¹ klasa?");
            }

            writer.WriteLine(idList[i] + ";" + tournamentList[i].name + ";" + tournamentList[i].receivedDamage + ";" +
                             tournamentList[i].dealtDamage + ";" + tournamentList[0].usedNormalAttacks + ";" +
                             tournamentList[0].usedStrongAttacks + ";" + tournamentList[0].usedScreamAttacks + ";" +
                             tournamentList[0].usedSpecialAttacks + ";" + tournamentList[0].missedAttacks + ";" +
                             ButtonsScript.mapName + ";" + (round + 1) + ";" + whomLosedTo.name + ";" + whomLosedTo.GetType().Name);
        }
    }

    void SaveMagesToFile(int i, Participant whomLosedTo)
    {
        //save mages to .txt file
        var fileLocation = "MagesFile.txt";
        using StreamWriter writer = new(fileLocation, append: true);
        if (File.Exists(fileLocation))
        {
            if (new FileInfo(fileLocation).Length == 0)
            {
                writer.WriteLine(
                    "Id postaci;Imie postaci;Otrzymane obrazenia;Zadane obrazenia;U¿yte ataki podstawowe;U¿yte silne ataki;U¿yte ataki krzykiem;U¿yte ataki specjalne;Ile spud³owano;Mapa;Runda;Z kim przegral;Z jak¹ klasa?");
            }

            writer.WriteLine(idList[i] + ";" + tournamentList[i].name + ";" + tournamentList[i].receivedDamage + ";" +
                             tournamentList[i].dealtDamage + ";" + tournamentList[0].usedNormalAttacks + ";" +
                             tournamentList[0].usedStrongAttacks + ";" + tournamentList[0].usedScreamAttacks + ";" +
                             tournamentList[0].usedSpecialAttacks + ";" + tournamentList[0].missedAttacks + ";" +
                             ButtonsScript.mapName + ";" + (round + 1) + ";" + whomLosedTo.name + ";" + whomLosedTo.GetType().Name);
        }
    }

    void SaveRoguesToFile(int i, Participant whomLosedTo)
    {
        //save rouges to .txt file
        var fileLocation = "RougesFile.txt";
        using StreamWriter writer = new(fileLocation, append: true);
        if (File.Exists(fileLocation))
        {
            if (new FileInfo(fileLocation).Length == 0)
            {
                writer.WriteLine(
                    "Id postaci;Imie postaci;Otrzymane obrazenia;Zadane obrazenia;U¿yte ataki podstawowe;U¿yte silne ataki;U¿yte ataki krzykiem;U¿yte ataki specjalne;Ile spud³owano;Mapa;Runda;Z kim przegral;Z jak¹ klasa?");
            }

            writer.WriteLine(idList[i] + ";" + tournamentList[i].name + ";" + tournamentList[i].receivedDamage + ";" +
                             tournamentList[i].dealtDamage + ";" + tournamentList[0].usedNormalAttacks + ";" +
                             tournamentList[0].usedStrongAttacks + ";" + tournamentList[0].usedScreamAttacks + ";" +
                             tournamentList[0].usedSpecialAttacks + ";" + tournamentList[0].missedAttacks + ";" +
                             ButtonsScript.mapName + ";" + (round + 1) + ";" + whomLosedTo.name + ";" + whomLosedTo.GetType().Name);
        }
    }

    void SaveBardToFile(int i, Participant whomLosedTo)
    {
        //save bard to .txt file
        var fileLocation = "BardsFile.txt";

        using StreamWriter writer = new(fileLocation, append: true);
        if (File.Exists(fileLocation))
        {
            if (new FileInfo(fileLocation).Length == 0)
            {
                writer.WriteLine(
                    "Id postaci;Imie postaci;Otrzymane obrazenia;Zadane obrazenia;U¿yte ataki podstawowe;U¿yte silne ataki;U¿yte ataki krzykiem;U¿yte ataki specjalne;Ile spud³owano;Mapa;Runda;Z kim przegral;Z jak¹ klasa?");
            }

            writer.WriteLine(idList[i] + ";" + tournamentList[i].name + ";" + tournamentList[i].receivedDamage + ";" +
                             tournamentList[i].dealtDamage + ";" + tournamentList[0].usedNormalAttacks + ";" +
                             tournamentList[0].usedStrongAttacks + ";" + tournamentList[0].usedScreamAttacks + ";" +
                             tournamentList[0].usedSpecialAttacks + ";" + tournamentList[0].missedAttacks + ";"+
                             ButtonsScript.mapName + ";" + (round + 1) + ";" + whomLosedTo.name + ";" + whomLosedTo.GetType().Name);
        }
    }

    void SaveToFile(int i, Participant participant)
    {
        if (tournamentList[i] is Warrior)
        {
            SaveWarriorsToFile(i, participant);
        }
        else if (tournamentList[i] is Mage)
        {
            SaveMagesToFile(i, participant);
        }
        else if (tournamentList[i] is Rouge)
        {
            SaveRoguesToFile(i, participant);
        }
        else
        {
            SaveBardToFile(i, participant);
        }
    }


    //this functions is very complicated as it picks the best photo of the most perfect human beeing to oversee the whole tournament
    void MaklowiczMood()
    {
        int rand = Random.Range(0, 6);
        tamGdzieWspanialyCzlowiekRezyduje.sprite = maklowicz[rand];
    }

    IEnumerator WaitOnDemand()
    {
        RepeatSimulation.loopCounter++;
        if (RepeatSimulation.loopCounter < RepeatSimulation.howManyLoops)
        {
            yield return new WaitForSeconds(0);
            SceneManager.LoadScene(2);
            simcounterText.text = RepeatSimulation.loopCounter.ToString();
        }
        else
        {
            simcounterText.text = RepeatSimulation.loopCounter.ToString();
            progresstext.text = "\n\nKoniec symulacji";
        }
    }
}