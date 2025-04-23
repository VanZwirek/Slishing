/*****************************************************************************
// File Name : QuestBoardController.cs
// Author : Van A. Zwirek
// Creation Date : Febuary 12, 2025
//
// Brief Description : adds the UI elements to the quest board
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestBoardController : MonoBehaviour
{
    [SerializeField] private GameObject UITab;
    [SerializeField] private Transform parent;

    public void newQuest(Quests quest)
    {
        Debug.Log("Quest added to board");
        GameObject newTab = Instantiate(UITab, parent);
        newTab.transform.Find("QuestName").GetComponent<TMP_Text>().text = (quest.QuestTitle);
        newTab.transform.Find("QuestDesc").GetComponent<TMP_Text>().text = (quest.QuestDescription);
        quest.UITab = newTab;
    }

    public void RemoveQuest(Quests quest)
    {
        if (quest.UITab != null)
        {
            Destroy(quest.UITab);
        }
    }
}
