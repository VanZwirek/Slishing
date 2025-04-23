/*****************************************************************************
// File Name : Quests.cs
// Author : Van A. Zwirek
// Creation Date : Febuary 12, 2025
//
// Brief Description : this is just a scriptable object thing
*****************************************************************************/
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
