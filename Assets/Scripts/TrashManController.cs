using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashManController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private InventoryController inventoryController;
    public UnityEvent areYouSure;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            areYouSure.Invoke();
        }
    }

    public void garbageDay()
    {
        playerController = player.GetComponent<PlayerController>();
        for (int i = 0; i < playerController.Inventory.Count; i++)
        {
            if (playerController.Inventory[i].IsTreasure == false)
            { 
                inventoryController.RemoveFish(playerController.Inventory[i]);
                playerController.Inventory.RemoveAt(i);
                i--;
            }
        }
    }
}