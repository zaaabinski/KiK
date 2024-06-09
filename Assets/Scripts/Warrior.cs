using UnityEngine;

public class Warrior : Participant
{
    internal Warrior(ParticipantScriptable pS) : base(pS)
    {
        
    }
    public bool isOnAdrenaline = false;

    //all the functions bellow override basic functions from participant class, they calculate dmg and return its value
    protected override int BasicAttack(Participant fighterReceivingDamage)
    {
        dmg = multiplierMainStat * this.strength + multiplierOtherStat * this.spd +
              Random.Range(-((int)(this.strength / 2)), (int)(this.strength / 2)) +
              Enemy_is_Bard(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    protected override int StrongAttack(Participant fighterReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.strength + multiplierOtherStat * this.spd) +
              Random.Range(-((int)(this.strength / 2)), (int)(this.strength / 2)) +
              Enemy_is_Bard(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    protected override int ScreamAttack(Participant fighterReceivingDamage)
    {
        dmg = multiplierOtherStat * this.charisma +
              Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) +
              Enemy_is_Bard(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    protected override int SpecialAbility(Participant fighterReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.strength + multiplierOtherStat * this.spd) +
              Random.Range(-((int)(this.strength / 2)), (int)(this.strength / 2)) +
              Enemy_is_Bard(fighterReceivingDamage) + Is_Favourite_Map();
        isOnAdrenaline = true;
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    //check if enemy is a class that takes more dmg
    int Enemy_is_Bard(Participant fighterReceivingDamage)
    {
        if (fighterReceivingDamage is Bard)
        {
            return 5;
        }

        return 0;
    }
}