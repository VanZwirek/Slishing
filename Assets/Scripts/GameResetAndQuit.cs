using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        //put code here to close the editor when you click it too
        Application.Quit();
    }

}
