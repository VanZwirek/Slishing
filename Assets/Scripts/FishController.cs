/*****************************************************************************
// File Name : FishController.cs
// Author : Van A. Zwirek
// Creation Date : Febuary 12, 2025
//
// Brief Description : this is for something i was using in the alpha stuff, and i cant seem to remove it? it just comes back :/
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FishController : MonoBehaviour
{
    [SerializeField] private float speed;


    private void FixedUpdate()
    {
        float y = transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(0, y + Time.deltaTime * -1 + speed, 0);
    }
}