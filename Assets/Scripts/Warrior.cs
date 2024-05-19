using UnityEngine;

public class Warrior : Participant
{
   internal Warrior(ParticipantScriptable pS) : base(pS)
   {

   }

    internal override int BasicAttack()
    {
        dmg = multiplierMainStat * this.strength + multiplierOtherStat * this.spd;
        return base.BasicAttack();
    }

    internal override int StrongAttack()
    {
        dmg = 2 * (multiplierMainStat * this.strength + multiplierOtherStat * this.spd);
        return base.StrongAttack();
    }

    internal override int ScreamAttack()
    {
        dmg = multiplierOtherStat * this.charisma;
        return base.ScreamAttack();
    }
}
