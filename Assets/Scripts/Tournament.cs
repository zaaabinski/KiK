using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Linq;

public class Tournament : MonoBehaviour
{
    private Duel duelScript;

    [SerializeField] private Image winnerImage;
    [SerializeField] private GameObject[] currentRound;
    private Image[] imageRoundList;
    private int round = 0;

    [SerializeField] private List<ParticipantScriptable> warriorScricptable = new List<ParticipantScriptable>();
    [SerializeField] private List<ParticipantScriptable> mageScriptable = new List<ParticipantScriptable>();
    [SerializeField] private List<ParticipantScriptable> rougeScriptable = new List<ParticipantScriptable>();
    [SerializeField] private List<ParticipantScriptable> bardScriptable = new List<ParticipantScriptable>();

    private List<Participant> particpantList = new List<Participant>();
    private List<Participant> tournamentList = new List<Participant>();

    [SerializeField] private List<int> idList = new List<int>();
    [SerializeField] private List<int> idToDelte = new List<int>();

    [SerializeField] private List<Sprite> maklowicz = new List<Sprite>();
    [SerializeField] private Image TamGdzieWspanialyCzlowiekRezyduje;

    private void Awake()
    {
        duelScript = GetComponent<Duel>();
    }

    void Start()
    {
        CreateParticpants();
        MaklowiczMood();
        RandomizeParticpantsId();
        GetImages(currentRound[round]);
        StartRound();
    }

    void StartRound()
    {
        idToDelte.Clear();
        for (int i = 0; i < tournamentList.Count; i += 2)
        {
            int deletedID = duelScript.DuelOfTheFates(tournamentList[i], tournamentList[i + 1]);
            idToDelte.Add(deletedID);
        }
        
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

        if (round < 3)
        {
            round++;
            GetImages(currentRound[round]);
            StartRound();
        }
        else if (round == 3)
        {
            Debug.Log(tournamentList[0].name + " Wins!");
            winnerImage.sprite = tournamentList[0].sprite;
        }
    }

    void RandomizeParticpantsId()
    {
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
        Debug.Log(tournamentList.Count);
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

    void CreateParticpants()
    {
        for (int i = 0; i < 4; i++)
        {
            particpantList.Add(new Warrior(warriorScricptable[i]));
            particpantList.Add(new Mage(mageScriptable[i]));
            particpantList.Add(new Rouge(rougeScriptable[i]));
            particpantList.Add(new Bard(bardScriptable[i]));
        }
    }

    void MaklowiczMood()
    {
        int rand = Random.Range(0, 6);
        TamGdzieWspanialyCzlowiekRezyduje.sprite = maklowicz[rand];
    }
}