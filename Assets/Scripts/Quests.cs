using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CreateAssetMenu(fileName = "Quests", menuName = "Quests")]

public class Quests : ScriptableObject
{
    public string QuestTitle;
    [TextArea]public string QuestDescription;
    [HideInInspector] public GameObject UITab;


}
