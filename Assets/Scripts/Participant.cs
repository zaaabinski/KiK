using UnityEngine;

public abstract class Participant
{

    internal static int pID=-1;
    internal int id;
    internal string name;
    internal string abilityName;
    internal Sprite sprite;
    internal int dmg;
    internal int hp;
    internal int maxHP;
    internal int strength;
    internal int agility;
    internal int spd;
    internal int wisdom;
    internal int charisma;
    internal int critChance;
    
    internal int multiplierMainStat=2;
    internal int multiplierOtherStat=1;

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
        this.hp=obj.pMaxHP;
        this.maxHP = obj.pMaxHP;
        this.strength = obj.pStrength;
        this.agility = obj.pAgility;
        this.wisdom = obj.pWisdom;
        this.spd = obj.pSpeed;
        this.charisma=obj.pCharisma;
        this.critChance=obj.pCritChance;
    }

    internal void Move(Participant FigtherReceivingDamage)
    {
        int rand=Random.Range(0, 101);

        int hitChance = Random.Range(0, 101);

        int dealtDamage;

        if (rand>0&&rand <51)
        {
            if (hitChance <= this.agility * 5)
            {
                dealtDamage = BasicAttack(FigtherReceivingDamage);
                Debug.Log("Basic "+this.name + " HP: " + this.hp + " Damage " + dealtDamage);
                FigtherReceivingDamage.hp= dealtDamage;
            }
            Debug.Log("Miss! " + this.name);
        }
        else if (rand<75)
        {
            if (hitChance <= this.agility * 4)
            {
                dealtDamage= StrongAttack(FigtherReceivingDamage);
                Debug.Log("Strong "+ this.name + " HP: " + this.hp + " Damage " + dealtDamage);
                FigtherReceivingDamage.hp = dealtDamage;
            }
            Debug.Log("Miss! " + this.name);
        }
        else if(rand<85)
        {
            if (hitChance <= this.agility * 5)
            {
                dealtDamage= ScreamAttack(FigtherReceivingDamage);
                Debug.Log("Scream "+ this.name + " HP: "+this.hp+ " Damage " + dealtDamage);
                FigtherReceivingDamage.hp = dealtDamage;
            }
            Debug.Log("Miss! " + this.name);
        }
        else
        {
            Debug.Log("Special "+ this.name + " HP: " + this.hp);
            FigtherReceivingDamage.hp = SpecialAbility();
        }
    }

    internal abstract int BasicAttack(Participant FighterReceivingDamage);
    internal abstract int StrongAttack(Participant FighterReceivingDamage);

    internal abstract int ScreamAttack(Participant FighterReceivingDamage);

    internal virtual int SpecialAbility()
    {
        return 0;
    }
}
