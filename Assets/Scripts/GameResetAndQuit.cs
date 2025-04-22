using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameResetAndQuit : MonoBehaviour
{
    [SerializeField] private InputActionMap actionMap;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputAction Restart;
    [SerializeField] private InputAction Quit;

    private void Start()
    {
        playerInput.currentActionMap.Enable();

        Restart = playerInput.currentActionMap.FindAction("Reset");
        Quit = playerInput.currentActionMap.FindAction("Quit");

        Restart.performed += Restart_performed;
        Quit.performed += Quit_performed;
    }
    
    private void Restart_performed(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene("MainScene");
    }

    private void Quit_performed(InputAction.CallbackContext obj)
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
    
    public void GameQuit()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
