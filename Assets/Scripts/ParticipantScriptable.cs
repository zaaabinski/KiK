using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Participant", order = 1)]
public class ParticipantScriptable : ScriptableObject
{
    public string pName;
    public string pAbilityName;
    public Sprite pSprite;
    public int strMin;
    public int strMax;
    public int hpMin;
    public int hpMax;
}
