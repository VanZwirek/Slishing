/*****************************************************************************
// File Name : NPCController.cs
// Author : Van A. Zwirek
// Creation Date : Febuary 12, 2025
//
// Brief Description : manages things with the NPCs, like checking if youve taken their quest
*****************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<Fish> questItems;
    [SerializeField] private List<Quests> NPCQuest;
    [SerializeField] private List<Fish> questRewards;

    public UnityEvent onQuestStarted;
    public UnityEvent onQuestCompleted;
    private bool hasQuest = false;

    [Obsolete]
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player) && hasQuest == false)
        {
            hasQuest = true;
            StartCoroutine(addQuest());
            onQuestStarted.Invoke();
        }

        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player1))
        {
            if(playerHasItems(player1) == true)
            {
                FindObjectOfType<QuestBoardController>().RemoveQuest(NPCQuest[0]);
                player.Quests.RemoveAt(0);
                onQuestCompleted.Invoke();

                InventoryController i = FindAnyObjectByType<InventoryController>();

                foreach (Fish fish in questRewards)
                {
                    player.Inventory.Add(fish);
                    i.NewFish(fish);
                }
            }
        }
    }

    [Obsolete]
    IEnumerator addQuest()
    {
        FindObjectOfType<QuestBoardController>().newQuest(NPCQuest[0]);
        player.GetComponent<PlayerController>().Quests.Add(NPCQuest[0]);
        gameObject.GetComponentInChildren<ParticleSystem>().startColor = Color.blue;
        yield return null;
    }

    private bool playerHasItems(PlayerController player)
    {
        List<Fish> QuestItemsCopy = new List<Fish>();
        for (int index = 0; index < questItems.Count; index++)
            QuestItemsCopy.Add(questItems[index]);

        for (int invIndex = 0; invIndex < player.Inventory.Count; invIndex++)
        {
            for (int index = 0; index < QuestItemsCopy.Count; index++)
                if (QuestItemsCopy[index] == player.Inventory[invIndex])
                {
                    QuestItemsCopy.RemoveAt(index);
                    break;
                }
        }

        if (QuestItemsCopy.Count <= 0)
        {
            for (int invIndex = 0; invIndex < player.Inventory.Count; invIndex++)
            {
                for (int index = 0; index < questItems.Count; index++)
                    if (questItems[index] == player.Inventory[invIndex])
                    {
                        player.Inventory.RemoveAt(invIndex);
                        FindObjectOfType<InventoryController>().RemoveFish (questItems[index]);
                        questItems.RemoveAt(index);
                        invIndex--;
                        break;
                    }
            }
            return true;
        }
        return false;
    }
}