public class Bard : Participant
{
    internal Bard(ParticipantScriptable pS) : base(pS)
    {
    }

    private int dmgBoost = 0;

    //all the functions bellow override basic functions from participant class, they calculate dmg and return its value
    protected override int BasicAttack(Participant fighterReceivingDamage)
    {
        int classAdvantage = EnemyIsRouge(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = DamageCalculation(this.agility,this.spd, classAdvantage, mapAdvantage, fighterReceivingDamage);
        if (dmgBoost == 0) return dmg;
        int temp = dmgBoost;
        dmgBoost = 0;
        return dmg + temp;
    }

    protected override int StrongAttack(Participant fighterReceivingDamage)
    {
        int classAdvantage = EnemyIsRouge(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = 2 * DamageCalculation(this.agility, this.spd,classAdvantage, mapAdvantage, fighterReceivingDamage);
        if (dmgBoost == 0) return dmg;
        int temp = dmgBoost;
        dmgBoost = 0;
        return dmg + temp;
    }

    protected override int ScreamAttack(Participant fighterReceivingDamage)
    {
        int classAdvantage = EnemyIsRouge(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = 2 * DamageCalculation(this.agility,0, classAdvantage, mapAdvantage, fighterReceivingDamage);
        if (dmgBoost == 0) return dmg;
        int temp = dmgBoost;
        dmgBoost = 0;
        return dmg + temp;
    }

    protected override int SpecialAbility(Participant fighterReceivingDamage)
    {
        dmgBoost = 15;
        int classAdvantage = EnemyIsRouge(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = dmgBoost + 3 * DamageCalculation(this.agility,this.spd, classAdvantage, mapAdvantage, fighterReceivingDamage);
        return dmg;
    }

    //check if enemy is a class that takes more dmg
    int EnemyIsRouge(Participant fighterReceivingDamage)
    {
        if (fighterReceivingDamage is Rouge)
        {
            return 5;
        }

        return 0;
    }
}