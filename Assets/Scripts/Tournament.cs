using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Tournament : MonoBehaviour
{
    [SerializeField] private Duel duelScript;

    [SerializeField] private GameObject[] currentRound;
    [SerializeField] private Image[] Round;
    private int round = 0;
    [SerializeField] private List<ParticipantScriptable> warriorScricptable = new List<ParticipantScriptable>();
    [SerializeField] private List<ParticipantScriptable> mageScriptable = new List<ParticipantScriptable>();
    [SerializeField] private List<ParticipantScriptable> rougeScriptable = new List<ParticipantScriptable>();
    [SerializeField] private List<ParticipantScriptable> bardScriptable = new List<ParticipantScriptable>();
    [SerializeField] private List<Participant> particpantList = new List<Participant>();
    [SerializeReference] public List<Participant> tournamentList = new List<Participant>();
    [SerializeField] private List<int> idList = new List<int>();

    [SerializeField] private Image TamGdzieWspanialyCzlowiekRezyduje;
    [SerializeField] private List<Sprite> maklowicz = new List<Sprite>();



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
        
        Debug.Log(tournamentList[0].id);
        Debug.Log(idList[0]);
        Debug.Log(tournamentList[1].id);
        Debug.Log(idList[1]);

        int a = duelScript.DuelOfTheFates(tournamentList[0], tournamentList[1]);
        for (int i=0; i<tournamentList.Count; i++) 
        {
            if (tournamentList[i].id==a)
            {
                tournamentList.RemoveAt(i);
                idList.RemoveAt(i);
                Debug.Log(a);
            }
        }
        
    }

    void MaklowiczMood()
    {
        int rand = Random.Range(0, 6);
        TamGdzieWspanialyCzlowiekRezyduje.sprite = maklowicz[rand];
    }

    void NextRound()
    {
        for (int i = 15; i > 0; i -= 2)
        {
            idList.RemoveAt(i);
            tournamentList.RemoveAt(i);
        }
        for (int i = 0; i < 8; i++)
        {
            Debug.Log(tournamentList[i].name);
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
        for(int i = 0;i<16;i++)
        {
            Debug.Log(tournamentList[i].name);
        }
    }


    void GetImages(GameObject currentRound)
    {
        Debug.Log(tournamentList.Count);
        Round = new Image[tournamentList.Count];
        Round = currentRound.GetComponentsInChildren<Image>();
        for (int i = 0; i < tournamentList.Count; i++)
        {
            for (int j = 0; j < idList.Count; j++)
            {
                if (idList[j] == tournamentList[i].id)
                {
                    Round[i].sprite = tournamentList[j].sprite;
                }
            }
        }
       round++;
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
}