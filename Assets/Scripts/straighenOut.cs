/*****************************************************************************
// File Name : straightenOut.cs
// Author : Van A. Zwirek
// Creation Date : Febuary 12, 2025
//
// Brief Description : this is for the physics of the player, making the cube and sphere move to the center so its not 
// flailing everywhere
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class straighenOut : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime);
    }
}
