using UnityEngine;

public class Mage : Participant
{
    internal Mage(ParticipantScriptable pS) :base(pS)
    {
        Debug.Log("Utworzono czarodzieja");
    }
}
