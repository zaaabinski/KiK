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

    internal int receivedDamage;
    internal int dealtDamage;
    internal string favouriteMap;

    internal int usedNormalAttacks;
    internal int usedStrongAttacks;
    internal int usedScreamAttacks;
    internal int usedSpecialAttacks;
    internal int missedAttacks;

    internal int multiplierMainStat=2;
    internal int multiplierOtherStat=1;

    internal Participant()
    {
        Debug.Log("No values in");
    }
    //sets values based on scriptble objects
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
        this.receivedDamage = obj.receivedDamage;
        this.dealtDamage = obj.dealtDamage;
        this.favouriteMap = obj.favouriteMap;
        this.usedNormalAttacks = 0;
        this.usedStrongAttacks = 0; 
        this.usedScreamAttacks = 0;
        this.usedSpecialAttacks = 0;
        this.missedAttacks = 0;
    }

    internal void Move(Participant FigtherReceivingDamage)
    {
        //each move get random values for which abbility to use and if the abbility hits
        int rand=Random.Range(0, 101);

        int hitChance = Random.Range(0, 101);

        int dealtDamage;

        if (rand>0&&rand <51)
        {
            //use basic attack
            if (hitChance <= this.agility * 5)
            {
                dealtDamage = BasicAttack(FigtherReceivingDamage);
                //Debug.Log("Basic " + this.name + " HP: " + this.hp + " Damage " + dealtDamage);
                this.usedNormalAttacks++;
                FigtherReceivingDamage.hp -= dealtDamage;
            }
            else
            {
                //Debug.Log("Miss! " + this.name + " HP: " + this.hp);
                this.missedAttacks++;
            }
        }
        else if (rand<75)
        {
            //use strong attack
            if (hitChance <= this.agility * 4)
            {
                dealtDamage= StrongAttack(FigtherReceivingDamage);
                //Debug.Log("Strong "+ this.name + " HP: " + this.hp + " Damage " + dealtDamage);
                this.usedStrongAttacks++;
                FigtherReceivingDamage.hp -= dealtDamage;
            }
            else
            {
                //Debug.Log("Miss! " + this.name + " HP: " + this.hp);
                this.missedAttacks++;
            }
        }
        else if(rand<85)
        {
            //use scream attack
            if (hitChance <= this.agility * 5)
            {
                dealtDamage= ScreamAttack(FigtherReceivingDamage);
                //Debug.Log("Scream "+ this.name + " HP: "+this.hp+ " Damage " + dealtDamage);
                this.usedScreamAttacks++;
                FigtherReceivingDamage.hp -= dealtDamage;
            }
            else
            {
                //Debug.Log("Miss! " + this.name + " HP: " + this.hp);
                this.missedAttacks++;
            }
        }
        else
        {
            //this section will be done later XD
            //Debug.Log("Special "+ this.name + " HP: " + this.hp);
            this.usedSpecialAttacks++;
            FigtherReceivingDamage.hp -= SpecialAbility();
        }
    }

    //functions that are used by fighters
    internal abstract int BasicAttack(Participant FighterReceivingDamage);
    internal abstract int StrongAttack(Participant FighterReceivingDamage);

    internal abstract int ScreamAttack(Participant FighterReceivingDamage);

    internal virtual int SpecialAbility()
    {
        return 0;
    }

    public int Is_Favourite_Map()
    {
        if (this.favouriteMap==ButtonsScript.mapName)
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }

}
