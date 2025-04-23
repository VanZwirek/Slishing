/*****************************************************************************
// File Name : WaterController.cs
// Author : Van A. Zwirek
// Creation Date : Febuary 12, 2025
//
// Brief Description : gives fish from the list in the water objects into the player's inventory
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public List<Fish> FishList;

    public Fish getFish()
    {
        int i = Random.Range(0, FishList.Count);
        return FishList[i];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Debug.Log("i hit da watuh");
            collision.gameObject.GetComponent<Rigidbody>().velocity = collision.contacts[0].normal * 100;
        }
    }
}
