using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Tournament : MonoBehaviour
{
    [SerializeField] private List<ParticipantScriptable> warriorScricptable=new List<ParticipantScriptable>();
    [SerializeField] private List<Warrior> WarriorsList=new List<Warrior>(); 
    [SerializeField] private List<Image> imgList=new List<Image>();
    void Start()
    {
        CreateWarriorInstance();   
    }
    
    void CreateWarriorInstance()
    {
        for (int i=0;i<warriorScricptable.Count;i++)
        {
           WarriorsList.Add(new Warrior(warriorScricptable[i]));
           GameObject warriorObject = new GameObject("Warrior" + i);
            
           imgList[i].sprite = WarriorsList[i].sprite;

            
        }
    }
}