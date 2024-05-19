using UnityEngine;

public class Mage : Participant
{
    internal Mage(ParticipantScriptable pS) :base(pS)
    {

    }
    internal override int BasicAttack()
    {
        dmg = multiplierMainStat * this.wisdom + multiplierOtherStat * this.spd;
        return base.BasicAttack();
    }
    internal override int StrongAttack()
    {
        dmg = 2 * (multiplierMainStat * this.wisdom + multiplierOtherStat * this.spd);
        return base.StrongAttack();
    }

    internal override int ScreamAttack()
    {
        dmg = multiplierOtherStat * this.charisma;
        return base.ScreamAttack();
    }
}
