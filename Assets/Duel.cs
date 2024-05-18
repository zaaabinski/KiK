using UnityEngine;

public class Duel : MonoBehaviour
{
    internal int DuelOfTheFates(Participant ManOne, Participant ManTwo)
    {
        Participant[] Fighter = new Participant[2];

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

        while (true)
        {
            Fighter[1].hp -= 2;
            if (Fighter[1].hp <= 0)
            {
                return Fighter[1].id;
            }
            Fighter[0].hp -= 5;
            if (Fighter[0].hp <= 0)
            {
                return Fighter[0].id;
            }
        }
    }
}
