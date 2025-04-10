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

    //trying to remove the quest from the UI, but it's having problems. get it fixed at TA time?
    public void RemoveQuest(Quests quest)
    {
        if (quest.UITab != null)
        {
            Destroy(quest.UITab);
        }
    }
}
