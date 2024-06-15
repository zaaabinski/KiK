public class Mage : Participant
{
    internal Mage(ParticipantScriptable pS) : base(pS)
    {
    }

    public int burnEnemy = 0;

    //all the functions bellow override basic functions from participant class, they calculate dmg and return its value
    protected override int BasicAttack(Participant fighterReceivingDamage)
    {
        int classAdvantage = EnemyIsWarrior(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = DamageCalculation(this.agility,this.spd, classAdvantage, mapAdvantage, fighterReceivingDamage);
        return dmg;
    }

    protected override int StrongAttack(Participant fighterReceivingDamage)
    {
        int classAdvantage = EnemyIsWarrior(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = 2 * DamageCalculation(this.agility,this.spd, classAdvantage, mapAdvantage, fighterReceivingDamage);
        return dmg;
    }

    protected override int ScreamAttack(Participant fighterReceivingDamage)
    {
        int classAdvantage = EnemyIsWarrior(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = 2 * DamageCalculation(this.agility,0, classAdvantage, mapAdvantage, fighterReceivingDamage);
        return dmg;
    }

    protected override int SpecialAbility(Participant fighterReceivingDamage)
    {
        int classAdvantage = EnemyIsWarrior(fighterReceivingDamage);
        int mapAdvantage = IsFavouriteMap();
        dmg = 2 * DamageCalculation(this.agility,this.spd, classAdvantage, mapAdvantage, fighterReceivingDamage);
        burnEnemy = 20;
        return dmg;
    }

    //check if enemy is a class that takes more dmg
    int EnemyIsWarrior(Participant fighterReceivingDamage)
    {
        if (fighterReceivingDamage is Warrior)
        {
            return 5;
        }

        return 0;
    }
}