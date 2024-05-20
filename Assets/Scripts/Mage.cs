using UnityEngine;

public class Mage : Participant
{
    internal Mage(ParticipantScriptable pS) :base(pS)
    {

    }
    internal override int BasicAttack()
    {
        dmg = multiplierMainStat * this.wisdom + multiplierOtherStat * this.spd + Random.Range(-((int)(this.wisdom / 2)), (int)(this.wisdom / 2));
        return dmg;
    }
    internal override int StrongAttack()
    {
        dmg = 2 * (multiplierMainStat * this.wisdom + multiplierOtherStat * this.spd) + Random.Range(-((int)(this.wisdom / 2)), (int)(this.wisdom / 2));
        return dmg;
    }

    internal override int ScreamAttack()
    {
        dmg = multiplierOtherStat * this.charisma + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2));
        return dmg;
    }   
}
