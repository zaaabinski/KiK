using UnityEngine;

public class Mage : Participant
{
    internal Mage(ParticipantScriptable pS) :base(pS)
    {

    }
    //all the funcions bellow override basic functions from participant class, they calculate dmg and return its value
    internal override int BasicAttack(Participant FighterReceivingDamage)
    {
        dmg = multiplierMainStat * this.wisdom + multiplierOtherStat * this.spd + Random.Range(-((int)(this.wisdom / 2)), (int)(this.wisdom / 2))+ Enemy_is_Warrior(FighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        FighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    internal override int StrongAttack(Participant FighterReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.wisdom + multiplierOtherStat * this.spd) + Random.Range(-((int)(this.wisdom / 2)), (int)(this.wisdom / 2)) + Enemy_is_Warrior(FighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        FighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    internal override int ScreamAttack(Participant FighterReceivingDamage)
    {
        dmg = multiplierOtherStat * this.charisma + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) + Enemy_is_Warrior(FighterReceivingDamage) + Is_Favourite_Map();
        this.dealtDamage += dmg;
        FighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }
    //check if enemy is a class that takes more dmg
    int Enemy_is_Warrior(Participant FighterReceivingDmage)
    {
        if (FighterReceivingDmage is Warrior)
        {
            return 5;
        }
        return 0;
    }
}
