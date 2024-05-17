using JetBrains.Annotations;
using UnityEngine;

public  class Participant
{
    internal static int pID=-1;
    internal int id;
    internal string name;
    internal string abilityName;
    internal Sprite sprite;
    internal int hp;
    internal int strength;
    internal int agility;
    internal int spd;
    internal int wisdom;
    internal int charisma;
    internal int critChance;

    internal Participant()
    {
        Debug.Log("No values in");
    }

    internal Participant(ParticipantScriptable obj)
    {
        pID ++;
        this.id = pID;
        this.name = obj.name;
        this.sprite = obj.pSprite;
        this.abilityName = obj.pAbilityName;
        this.hp=obj.pHP;
        this.strength = obj.pStrength;
        this.agility = obj.pAgility;
        this.wisdom = obj.pWisdom;
        this.spd = obj.pSpeed;
        this.charisma=obj.pCharisma;
        this.critChance=obj.pCritChance;
    }
}
