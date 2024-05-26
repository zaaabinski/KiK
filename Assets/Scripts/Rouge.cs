using UnityEngine;

public class Rouge : Participant
{
    internal Rouge(ParticipantScriptable pS) : base(pS)
    {

    }

    internal override int BasicAttack(Participant FigtherReceivingDamage)
    {
        dmg = multiplierMainStat * this.agility + multiplierOtherStat * this.spd + Random.Range(-((int)(this.agility / 2)), (int)(this.agility / 2)) + Enemy_is_Mage_or_Bard(FigtherReceivingDamage);
        return dmg;
    }

    internal override int StrongAttack(Participant FigtherReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.agility + multiplierOtherStat * this.spd) + Random.Range(-((int)(this.agility / 2)), (int)(this.agility / 2)) + Enemy_is_Mage_or_Bard(FigtherReceivingDamage);
        return dmg;
    }

    internal override int ScreamAttack(Participant FigtherReceivingDamage)
    {
        dmg = multiplierOtherStat * this.charisma + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) + Enemy_is_Mage_or_Bard(FigtherReceivingDamage);
        return dmg;
    }

    int Enemy_is_Mage_or_Bard(Participant FighterReceivingDamage)
    {
        if (FighterReceivingDamage is Mage || FighterReceivingDamage is Bard)
        {
            return 5;
        }
        return 0;
    }
}
