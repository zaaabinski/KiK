public class Rouge : Participant
{
    internal Rouge(ParticipantScriptable pS) : base(pS)
    {
    }

    //all the functions bellow override basic functions from participant class, they calculate dmg and return its value
    protected override int BasicAttack(Participant fighterReceivingDamage)
    {
        int classAdvantage = EnemyIsMage(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = DamageCalculation(this.agility,this.spd, classAdvantage,mapAdvantage,fighterReceivingDamage);
        return dmg;
    }

    protected override int StrongAttack(Participant fighterReceivingDamage)
    {
        int classAdvantage = EnemyIsMage(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = 2 * DamageCalculation(this.agility,this.spd, classAdvantage, mapAdvantage, fighterReceivingDamage);
        return dmg;
    }

    protected override int ScreamAttack(Participant fighterReceivingDamage)
    {
        int classAdvantage = EnemyIsMage(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = 2 * DamageCalculation(this.agility,0, classAdvantage, mapAdvantage, fighterReceivingDamage);
        return dmg;
    }

    protected override int SpecialAbility(Participant fighterReceivingDamage)
    {
        int classAdvantage = EnemyIsMage(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = 2 * DamageCalculation(this.agility, this.spd,classAdvantage, mapAdvantage, fighterReceivingDamage);
        Move(fighterReceivingDamage);
        return dmg;
    }

    //check if enemy is a class that takes more dmg
    int EnemyIsMage(Participant fighterReceivingDamage)
    {
        if (fighterReceivingDamage is Mage)
        {
            return 5;
        }
        return 0;
    }
}