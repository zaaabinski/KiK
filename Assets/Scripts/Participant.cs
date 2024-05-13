using JetBrains.Annotations;
using UnityEngine;

public abstract class Participant
{
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
        this.name = obj.name;
        this.sprite = obj.pSprite;
        this.abilityName = obj.pAbilityName;
        this.strength = obj.pStrength;
    }
}
