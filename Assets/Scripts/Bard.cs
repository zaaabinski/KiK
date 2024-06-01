using UnityEngine;

public class Bard : Participant
{
    internal Bard(ParticipantScriptable pS) : base(pS)
    {
        
    }
    private int dmgBoost = 0;

    //all the functions bellow override basic functions from participant class, they calculate dmg and return its value
    protected override int BasicAttack(Participant fighterReceivingDamage)
    {
        dmg = multiplierMainStat * this.charisma + multiplierOtherStat * this.spd +
              Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) +
              Enemy_is_Rouge(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        if (dmgBoost != 0)
        {
            int temp = dmgBoost;
            dmgBoost = 0;
            return dmg + temp;
        }
        else
            return dmg;
    }

    protected override int StrongAttack(Participant fighterReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.charisma + multiplierOtherStat * this.spd) +
              Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) +
              Enemy_is_Rouge(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        if (dmgBoost != 0)
        {
            int temp = dmgBoost;
            dmgBoost = 0;
            return dmg + temp;
        }
        else
            return dmg;
    }

    protected override int ScreamAttack(Participant fighterReceivingDamage)
    {
        dmg = multiplierMainStat * this.charisma + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) +
              Enemy_is_Rouge(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        if (dmgBoost != 0)
        {
            int temp = dmgBoost;
            dmgBoost = 0;
            return dmg + temp;
        }
        else
            return dmg;
    }

    protected override int SpecialAbility(Participant fighterReceivingDamage)
    {
        dmgBoost = 15;
        dmg = dmgBoost + 3 * (multiplierMainStat * this.charisma + multiplierOtherStat * this.spd) +
              Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) +
              Enemy_is_Rouge(fighterReceivingDamage) + Is_Favourite_Map();
        return dmg;
    }

    //check if enemy is a class that takes more dmg
    int Enemy_is_Rouge(Participant fighterReceivingDamage)
    {
        if (fighterReceivingDamage is Rouge)
        {
            return 5;
        }

        return 0;
    }
}