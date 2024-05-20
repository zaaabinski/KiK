using UnityEngine;

public class Warrior : Participant
{
   internal Warrior(ParticipantScriptable pS) : base(pS)
   {

   }

    internal override int BasicAttack()
    {
        dmg = multiplierMainStat * this.strength + multiplierOtherStat * this.spd + Random.Range(-((int)(this.strength / 2)), (int)(this.strength / 2));
        return dmg;
    }

    internal override int StrongAttack()
    {
        dmg = 2 * (multiplierMainStat * this.strength + multiplierOtherStat * this.spd)+ Random.Range(-((int)(this.strength / 2)), (int)(this.strength / 2));
        return dmg;
    }

    internal override int ScreamAttack()
    {
        dmg = multiplierOtherStat * this.charisma+ Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2));
        return dmg;
    }

}
