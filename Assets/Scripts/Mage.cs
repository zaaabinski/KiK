using UnityEngine;

public class Mage : Participant
{
    internal Mage(ParticipantScriptable pS) :base(pS)
    {

    }
    internal override int BasicAttack(Participant FigtherReceivingDamage)
    {
        dmg = multiplierMainStat * this.wisdom + multiplierOtherStat * this.spd + Random.Range(-((int)(this.wisdom / 2)), (int)(this.wisdom / 2))+ Enemy_is_Warrior_or_Rouge(FigtherReceivingDamage);
        return dmg;
    }
    internal override int StrongAttack(Participant FigtherReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.wisdom + multiplierOtherStat * this.spd) + Random.Range(-((int)(this.wisdom / 2)), (int)(this.wisdom / 2)) + Enemy_is_Warrior_or_Rouge(FigtherReceivingDamage);
        return dmg;
    }

    internal override int ScreamAttack(Participant FigtherReceivingDamage)
    {
        dmg = multiplierOtherStat * this.charisma + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) + Enemy_is_Warrior_or_Rouge(FigtherReceivingDamage);
        return dmg;
    }
    int Enemy_is_Warrior_or_Rouge(Participant FighterReceivingDmage)
    {
        if (FighterReceivingDmage is Warrior || FighterReceivingDmage is Rouge)
        {
            return 5;
        }
        return 0;
    }
}
