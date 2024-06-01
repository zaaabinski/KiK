using UnityEngine;
using Random = System.Random;

public class Duel : MonoBehaviour
{
    internal int DuelOfTheFates(Participant manOne, Participant manTwo)
    {
        Participant[] fighter = new Participant[2];
        //check which fighter speed is higher and set him in table at index 0 so it moves first

        Random random = new Random();
        int whoIsFaster = random.Next(0, manOne.spd + manTwo.spd + 1);

        if (whoIsFaster < manOne.spd)
        {
            fighter[0] = manOne;
            fighter[1] = manTwo;
        }
        else
        {
            fighter[0] = manTwo;
            fighter[1] = manOne;
        }

        //when any participants hp drops bellow or is equal to 0 return id of defeated fighter
        while (true)
        {
            if (fighter[0] is Mage mage1 && mage1.burnEnemy > 0)
            {
                fighter[1].hp -= mage1.burnEnemy;
                mage1.burnEnemy = 0;
            }

            fighter[0].Move(fighter[1]);
            if (fighter[1].hp <= 0)
            {
                if (fighter[1] is Warrior warrior && warrior.isOnAdrenaline)
                {
                    warrior.isOnAdrenaline = false;
                    fighter[1].hp = 1;
                }
                else
                {
                    return fighter[1].id;
                }
            }

            if (fighter[1] is Mage mage2 && mage2.burnEnemy > 0)
            {
                fighter[0].hp -= mage2.burnEnemy;
                mage2.burnEnemy = 0;
            }

            if (fighter[1] is Warrior warrior2)
            {
                warrior2.isOnAdrenaline = false;
            }

            fighter[1].Move(fighter[0]);
            if (fighter[0].hp <= 0)
            {
                if (fighter[0] is Warrior warrior && warrior.isOnAdrenaline)
                {
                    warrior.isOnAdrenaline = false;
                    fighter[0].hp = 1;
                }
                else
                {
                    return fighter[0].id;
                }
            }

            if (fighter[0] is Warrior warrior3)
            {
                warrior3.isOnAdrenaline = false;
            }
        }
    }
}