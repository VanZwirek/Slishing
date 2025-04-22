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
