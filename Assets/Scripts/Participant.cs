using UnityEngine;

public abstract class Participant
{
    internal static int pID = -1;
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

    internal int multiplierMainStat = 2;
    internal int multiplierOtherStat = 1;

    internal Participant()
    {
        Debug.Log("No values in");
    }

    //sets values based on scriptable objects
    internal Participant(ParticipantScriptable obj)
    {
        pID++;
        this.id = pID;
        this.name = obj.name;
        this.sprite = obj.pSprite;
        this.abilityName = obj.pAbilityName;
        this.hp = obj.pMaxHp;
        this.maxHP = obj.pMaxHp;
        this.strength = obj.pStrength;
        this.agility = obj.pAgility;
        this.wisdom = obj.pWisdom;
        this.spd = obj.pSpeed;
        this.charisma = obj.pCharisma;
        this.critChance = obj.pCritChance;
        this.receivedDamage = 0;
        this.dealtDamage = 0;
        this.favouriteMap = obj.favouriteMap;
        this.usedNormalAttacks = 0;
        this.usedStrongAttacks = 0;
        this.usedScreamAttacks = 0;
        this.usedSpecialAttacks = 0;
        this.missedAttacks = 0;
    }

    internal void Move(Participant fighterReceivingDamage)
    {
        //each move get random values for which ability to use and if the ability hits
        int rand = Random.Range(0, 101);

        int hitChance = Random.Range(0, 101);

        int dealtDamage;

        if (rand > 0 && rand < 51)
        {
            //use basic attack
            if (hitChance <= this.agility * 5)
            {
                dealtDamage = BasicAttack(fighterReceivingDamage);
                this.usedNormalAttacks++;
                fighterReceivingDamage.hp -= dealtDamage;
            }
            else
            {
                this.missedAttacks++;
            }
        }
        else if (rand < 75)
        {
            //use strong attack
            if (hitChance <= this.agility * 4)
            {
                dealtDamage = StrongAttack(fighterReceivingDamage);
                this.usedStrongAttacks++;
                fighterReceivingDamage.hp -= dealtDamage;
            }
            else
            {
                this.missedAttacks++;
            }
        }
        else if (rand < 85)
        {
            //use scream attack
            if (hitChance <= this.agility * 5)
            {
                dealtDamage = ScreamAttack(fighterReceivingDamage);
                this.usedScreamAttacks++;
                fighterReceivingDamage.hp -= dealtDamage;
            }
            else
            {
                this.missedAttacks++;
            }
        }
        else
        {
            this.usedSpecialAttacks++;
            fighterReceivingDamage.hp -= SpecialAbility(fighterReceivingDamage);
        }
    }

    //functions that are used by fighters
    protected int DamageCalculation(int mainStat, int secondStat, int strongAgainst, int mapDmg, Participant fighterReceivingDamage)
    {
        dmg = multiplierMainStat * mainStat + multiplierOtherStat * secondStat +
              Random.Range(-((int)(mainStat / 2)), (int)(mainStat / 2)) +
              +strongAgainst + mapDmg;
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    protected abstract int BasicAttack(Participant fighterReceivingDamage);
    protected abstract int StrongAttack(Participant fighterReceivingDamage);

    protected abstract int ScreamAttack(Participant fighterReceivingDamage);

    protected abstract int SpecialAbility(Participant fighterReceivingDamage);

    protected int IsFavouriteMap()
    {
        if (this.favouriteMap == ButtonsScript.mapName)
        {
            return 5;
        }
        else
        {
            return 0;
        }
    }
}