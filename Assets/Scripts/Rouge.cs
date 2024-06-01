using Unity.VisualScripting;
using UnityEngine;

public class Rouge : Participant
{
    internal Rouge(ParticipantScriptable pS) : base(pS)
    {
    }

    //all the functions bellow override basic functions from participant class, they calculate dmg and return its value
    protected override int BasicAttack(Participant fighterReceivingDamage)
    {
        dmg = multiplierMainStat * this.agility + multiplierOtherStat * this.spd +
              Random.Range(-((int)(this.agility / 2)), (int)(this.agility / 2)) +
              Enemy_is_Mage(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    protected override int StrongAttack(Participant fighterReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.agility + multiplierOtherStat * this.spd) +
              Random.Range(-((int)(this.agility / 2)), (int)(this.agility / 2)) +
              Enemy_is_Mage(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    protected override int ScreamAttack(Participant fighterReceivingDamage)
    {
        dmg = multiplierOtherStat * this.charisma +
              Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) +
              Enemy_is_Mage(fighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        fighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    protected override int SpecialAbility(Participant fighterReceivingDamage)
    {
        dmg = 3 * (multiplierMainStat * this.agility + multiplierOtherStat * this.spd) +
              Random.Range(-((int)(this.agility / 2)), (int)(this.agility / 2)) +
              Enemy_is_Mage(fighterReceivingDamage) + Is_Favourite_Map();
        Move(fighterReceivingDamage);
        return dmg;
    }

    //check if enemy is a class that takes more dmg
    int Enemy_is_Mage(Participant fighterReceivingDamage)
    {
        if (fighterReceivingDamage is Mage)
        {
            return 5;
        }

        return 0;
    }
}