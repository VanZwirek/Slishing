/*****************************************************************************
// File Name : Fish.cs
// Author : Van A. Zwirek
// Creation Date : Febuary 12, 2025
//
// Brief Description : activates the fish scriptable objects
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Fish", menuName =  "Fish")]

public class Fish : ScriptableObject
{
    public string FishName;
    public Sprite FishSprite;
}