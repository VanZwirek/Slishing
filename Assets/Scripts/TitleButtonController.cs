/*****************************************************************************
// File Name : TitleButtonController.cs
// Author : Van A. Zwirek
// Creation Date : Febuary 12, 2025
//
// Brief Description : just is used to get the player into the game from the title
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TitleButtonController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("OpenWorld");
    }
}
