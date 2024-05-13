using UnityEngine;

public class Warrior : Participant
{
   internal Warrior(ParticipantScriptable pS) : base(pS)
    {
        Debug.Log("Created warrior");
    }
}
