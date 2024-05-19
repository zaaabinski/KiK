using UnityEngine;

public class Rouge : Participant
{
   internal Rouge(ParticipantScriptable pS):base(pS)
   {
      
   }
   internal override int BasicAttack()
   {
        dmg = multiplierMainStat * this.agility + multiplierOtherStat * this.spd;
        return base.BasicAttack();
   }
    internal override int StrongAttack()
    {
        dmg = 2 * (multiplierMainStat * this.agility + multiplierOtherStat * this.spd);
        return base.StrongAttack();
    }

    internal override int ScreamAttack()
    {
        dmg = multiplierOtherStat * this.charisma;
        return base.ScreamAttack();
    }
}
