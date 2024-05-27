using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Participant", order = 1)]
public class ParticipantScriptable : ScriptableObject
{
    public string pName;
    public string pAbilityName;
    public Sprite pSprite;
    public int pMaxHP;
    public int pStrength;
    public int pAgility;
    public int pSpeed;
    public int pWisdom;
    public int pCharisma;
    public int pCritChance;
    public int receivedDamage;
    public int dealtDamage;
    public string favouriteMap;
}
