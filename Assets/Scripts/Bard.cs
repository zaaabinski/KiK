using UnityEngine;

public class Bard : Participant
{
   internal Bard(ParticipantScriptable pS):base(pS)
   {

   }
   internal override int BasicAttack()
   {
        dmg = multiplierMainStat * this.charisma + multiplierOtherStat * this.spd + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2));
        return dmg;
   }
    internal override int StrongAttack()
    {
        dmg = 2 * (multiplierMainStat * this.charisma + multiplierOtherStat * this.spd)+ Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2));
        return dmg;
    }

    internal override int ScreamAttack()
    {
        dmg = multiplierMainStat * this.charisma + Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2));
        return dmg;
    }
}
