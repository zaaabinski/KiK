using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Tournament : MonoBehaviour
{
    [SerializeField] private List<ParticipantScriptable> warriorScricptable=new List<ParticipantScriptable>();
    [SerializeField] private List<Warrior> WarriorsList=new List<Warrior>(); 
    [SerializeField] private List<Image> imgListW=new List<Image>();

    [SerializeField] private List<ParticipantScriptable> mageScriptable = new List<ParticipantScriptable>();
    [SerializeField] private List<Mage> MagesList = new List<Mage>();
    [SerializeField] private List<Image> imgListM = new List<Image>();

    [SerializeField] private List<ParticipantScriptable> rougeScriptable=new List<ParticipantScriptable>();
    [SerializeField] private List<Rouge> RougesList = new List<Rouge>();
    [SerializeField] private List<Image> imgListR = new List<Image>();

    [SerializeField] private List<ParticipantScriptable> bardScriptable = new List<ParticipantScriptable>();
    [SerializeField] private List<Bard> BardsList = new List<Bard>();
    [SerializeField] private List<Image> imgListB = new List<Image>();

    void Start()
    {
        CreateWarriorInstance();
        CreateMageInstance();
    }
    
    void CreateWarriorInstance()
    {
        for (int i=0;i<warriorScricptable.Count;i++)
        {
           WarriorsList.Add(new Warrior(warriorScricptable[i]));
           GameObject warriorObject = new GameObject("Warrior" + i);
           imgListW[i].sprite = WarriorsList[i].sprite;
        }
    }

    void CreateMageInstance()
    {
        for (int i=0;i<mageScriptable.Count;i++)
        {
            MagesList.Add(new Mage(mageScriptable[i]));
            GameObject mageObject = new GameObject("Mage" + i);
            imgListM[i].sprite = MagesList[i].sprite;
        }
    }

    void CreateRougeInstance()
    {
        for (int i = 0; i < rougeScriptable.Count; i++)
        {
            RougesList.Add(new Rouge(rougeScriptable[i]));
            GameObject rougeObject = new GameObject("Rouge" + i);
            imgListR[i].sprite = RougesList[i].sprite;
        }
    }

    void CreateBardInstance()
    {
        for (int i = 0; i < rougeScriptable.Count; i++)
        {
            BardsList.Add(new Bard(bardScriptable[i]));
            GameObject bardObject = new GameObject("Bard" + i);
            imgListB[i].sprite = BardsList[i].sprite;
        }
    }

}