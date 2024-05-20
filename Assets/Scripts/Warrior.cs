using UnityEngine;

public class Warrior : Participant
{
   internal Warrior(ParticipantScriptable pS) : base(pS)
   {

   }

    internal override int BasicAttack(Participant FighterReceivingDamage)
    {
        dmg = multiplierMainStat * this.strength + multiplierOtherStat * this.spd + Random.Range(-((int)(this.strength / 2)), (int)(this.strength / 2))+Enemy_is_Bard_or_Mage(FighterReceivingDamage);
        return dmg;
    }

    internal override int StrongAttack(Participant FighterReceivingDamage)
    {
        dmg = 2 * (multiplierMainStat * this.strength + multiplierOtherStat * this.spd)+ Random.Range(-((int)(this.strength / 2)), (int)(this.strength / 2)) + Enemy_is_Bard_or_Mage(FighterReceivingDamage);
        return dmg;
    }

    internal override int ScreamAttack(Participant FighterReceivingDamage)
    {
        dmg = multiplierOtherStat * this.charisma+ Random.Range(-((int)(this.charisma / 2)), (int)(this.charisma / 2)) + Enemy_is_Bard_or_Mage(FighterReceivingDamage);
        return dmg;
    }

    int Enemy_is_Bard_or_Mage(Participant FighterReceivingDamage)
    {
        if (FighterReceivingDamage is Bard || FighterReceivingDamage is Mage)
        {
            return 5;
        }
        return 0;
    }

}
