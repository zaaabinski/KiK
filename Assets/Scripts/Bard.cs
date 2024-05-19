using UnityEngine;

public class Bard : Participant
{
   internal Bard(ParticipantScriptable pS):base(pS)
   {

   }
   internal override int BasicAttack()
   {
        dmg = multiplierMainStat * this.charisma + multiplierOtherStat * this.spd;
        return base.BasicAttack();
   }
    internal override int StrongAttack()
    {
        dmg = 2 * (multiplierMainStat * this.charisma + multiplierOtherStat * this.spd);
        return base.StrongAttack();
    }

    internal override int ScreamAttack()
    {
        dmg = multiplierMainStat * this.charisma;
        return base.ScreamAttack();
    }
}
