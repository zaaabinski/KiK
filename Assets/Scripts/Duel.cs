using UnityEngine;

public class Duel : MonoBehaviour
{
    internal int DuelOfTheFates(Participant ManOne, Participant ManTwo)
    {
        Participant[] Fighter = new Participant[2];
        //check which figher speed is higher and set him in table at index 0 so it moves first
        if (ManOne.spd > ManTwo.spd)
        {
            Fighter[0] = ManOne;
            Fighter[1] = ManTwo;
        }
        else
        {
            Fighter[0] = ManTwo;
            Fighter[1] = ManOne;
        }
        //when any particpants hp drops bellow or is equal to 0 return id of deafted fighter
        while (true)
        {
            Fighter[0].Move(Fighter[1]);
            if (Fighter[1].hp <= 0)
            {
                return Fighter[1].id;
            }
            Fighter[1].Move(Fighter[0]); 
            if (Fighter[0].hp <= 0)
            {
                return Fighter[0].id;
            }
        }
    }
}
