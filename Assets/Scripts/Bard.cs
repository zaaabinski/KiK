using UnityEngine;

public class Bard : Participant
{
    internal Bard(ParticipantScriptable pS) : base(pS)
    {

    }
    internal override int BasicAttack(Participant FigtherReceivingDamage)
    {
        dmg = multiplierMainStat * this.charisma + multiplierOtherStat * this.spd + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) + Enemy_is_Rouge_or_Warrior(FigtherReceivingDamage);
        return dmg;
    }
    internal override int StrongAttack(Participant FigtherReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.charisma + multiplierOtherStat * this.spd) + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) + Enemy_is_Rouge_or_Warrior(FigtherReceivingDamage);
        return dmg;
    }

    internal override int ScreamAttack(Participant FigtherReceivingDamage)
    {
        dmg = multiplierMainStat * this.charisma + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) + Enemy_is_Rouge_or_Warrior(FigtherReceivingDamage);
        return dmg;
    }

    int Enemy_is_Rouge_or_Warrior(Participant FighterReceivingDmage)
    {
        if (FighterReceivingDmage is Rouge || FighterReceivingDmage is Warrior)
        {
            return 5;
        }
        return 0;
    }
}
