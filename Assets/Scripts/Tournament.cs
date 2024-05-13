using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Tournament : MonoBehaviour
{
    [SerializeField] private List<ParticipantScriptable> scriptableObject;
    [SerializeField] private Image check;
    void Start()
    {
        Warrior shrek = new Warrior(scriptableObject[0]);
        check.sprite = shrek.sprite;
    }
}
