using UnityEngine;

public class Rouge : Participant
{
   internal Rouge(ParticipantScriptable pS):base(pS)
   {
      
   }
   internal override int BasicAttack()
   {
        dmg = multiplierMainStat * this.agility + multiplierOtherStat * this.spd+ Random.Range(-((int)(this.agility / 2)), (int)(this.agility / 2));
        return base.BasicAttack();
   }
    internal override int StrongAttack()
    {
        dmg = 2 * (multiplierMainStat * this.agility + multiplierOtherStat * this.spd)+ Random.Range(-((int)(this.agility / 2)), (int)(this.agility / 2));
        return base.StrongAttack();
    }

    internal override int ScreamAttack()
    {
        dmg = multiplierOtherStat * this.charisma + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2));
        return base.ScreamAttack();
    }
}
