using JetBrains.Annotations;
using UnityEngine;

public abstract class Participant
{
    string name;
    string abilityName;
    Sprite sprite;
    int hp;
    int strength;
    int agility;
    int spd;
    int charisma;
    int critChance;
    int wisdom;

    internal  Participant()
    {
        Debug.Log("No values in");
    }

   internal Participant(ParticipantScriptable obj)
    {
        this.name = obj.name;
        this.sprite = obj.pSprite;
        this.abilityName = obj.pAbilityName;
        this.strength = Random.Range(obj.strMin, obj.strMax);
    }
}
