using UnityEngine;

public class Warrior : Participant
{
    internal Warrior(ParticipantScriptable pS) : base(pS)
    {

    }
    //all the funcions bellow override basic functions from participant class, they calculate dmg and return its value
    internal override int BasicAttack(Participant FighterReceivingDamage)
    {
        dmg = multiplierMainStat * this.strength + multiplierOtherStat * this.spd + Random.Range(-((int)(this.strength / 2)), (int)(this.strength / 2)) + Enemy_is_Bard(FighterReceivingDamage)+Is_Favourite_Map();
        this.dealtDamage += dmg;
        FighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    internal override int StrongAttack(Participant FighterReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.strength + multiplierOtherStat * this.spd) + Random.Range(-((int)(this.strength / 2)), (int)(this.strength / 2)) + Enemy_is_Bard(FighterReceivingDamage)+ Is_Favourite_Map();
        this.dealtDamage += dmg;
        FighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }

    internal override int ScreamAttack(Participant FighterReceivingDamage)
    {
        dmg = multiplierOtherStat * this.charisma + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) + Enemy_is_Bard(FighterReceivingDamage)+ Is_Favourite_Map();
        this.dealtDamage += dmg;
        FighterReceivingDamage.receivedDamage += dmg;
        return dmg;
    }
    //check if enemy is a class that takes more dmg
    int Enemy_is_Bard(Participant FighterReceivingDamage)
    {
        if (FighterReceivingDamage is Bard)
        {
            return 5;
        }
        return 0;
    }
}
