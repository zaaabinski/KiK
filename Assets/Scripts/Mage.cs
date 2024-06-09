using UnityEngine;

public class Mage : Participant
{
    internal Mage(ParticipantScriptable pS) : base(pS)
    {
        
    }
    public int burnEnemy = 0;

    //all the functions bellow override basic functions from participant class, they calculate dmg and return its value
    protected override int BasicAttack(Participant fighterReceivingDamage)
    {
        dmg = multiplierMainStat * this.wisdom + multiplierOtherStat * this.spd +
              Random.Range(-((int)(this.wisdom / 2)), (int)(this.wisdom / 2)) +
              Enemy_is_Warrior(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    protected override int StrongAttack(Participant fighterReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.wisdom + multiplierOtherStat * this.spd) +
              Random.Range(-((int)(this.wisdom / 2)), (int)(this.wisdom / 2)) +
              Enemy_is_Warrior(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    protected override int ScreamAttack(Participant fighterReceivingDamage)
    {
        dmg = multiplierOtherStat * this.charisma +
              Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) +
              Enemy_is_Warrior(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    protected override int SpecialAbility(Participant fighterReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.wisdom + multiplierOtherStat * this.spd) +
              Random.Range(-((int)(this.wisdom / 2)), (int)(this.wisdom / 2)) +
              Enemy_is_Warrior(fighterReceivingDamage) + Is_Favourite_Map();
        burnEnemy = 20;
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    //check if enemy is a class that takes more dmg
    int Enemy_is_Warrior(Participant fighterReceivingDamage)
    {
        if (fighterReceivingDamage is Warrior)
        {
            return 5;
        }

        return 0;
    }
}