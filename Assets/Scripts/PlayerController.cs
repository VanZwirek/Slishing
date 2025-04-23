using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private InputActionMap ActionMap;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private InputAction FBMove;
    [SerializeField] private InputAction Turn;
    [SerializeField] private InputAction Cast;
    [SerializeField] private InputAction Interact;
    [SerializeField] [ReadOnly] private bool isMoving;
    [SerializeField] [ReadOnly] private bool isTurning;
    [SerializeField] [ReadOnly] private bool isCasting;
    private float moveDirection;
    [SerializeField] private float moveSpeed;
    private float turnDirection;
    [SerializeField] private float turnSpeed;
    private Rigidbody rigidbody;
    [SerializeField] private float jumpValue = 25f;
    [SerializeField] private bool isJumping;
    [SerializeField] private float castRadius;
    [SerializeField] private Vector3 castDistance;
    [SerializeField] private Animator animator;
    public List<Fish> FishOOP;
    [HideInInspector] public string FishName;
    [SerializeField] private LayerMask onlyWater;
    [ReadOnly] public List<Fish> Fishlist;
    [ReadOnly] public List<Fish> Inventory;
    [ReadOnly] public List<Quests> Quests;
    [SerializeField] private InventoryController inventoryController;

    void Start()
    {
        playerInput.currentActionMap.Enable();

        FBMove = playerInput.currentActionMap.FindAction("F/BMovement");
        Turn = playerInput.currentActionMap.FindAction("L/RMovement");
        Cast = playerInput.currentActionMap.FindAction("Cast");
        Interact = playerInput.currentActionMap.FindAction("Interact");
        

        FBMove.started += FBMove_started;
        FBMove.canceled += FBMove_canceled;

        Turn.started += turn_started;
        Turn.canceled += Turn_canceled;

        Cast.started += Cast_started;
        Cast.canceled += Cast_canceled;

        Interact.started += Interact_started;

        isMoving = false;

        rigidbody = GetComponent<Rigidbody>();

        FishName = FishOOP [0].name;
    }

    private void Interact_started(InputAction.CallbackContext obj)
    {
        RectTransform[] rectTransform = FindObjectsOfType<RectTransform>();
        
        foreach (RectTransform i in rectTransform)
        {
            if(i.gameObject.CompareTag("textBox"))
            {
                i.gameObject.SetActive(false);
            }
        }
    }

    private void FBMove_started(InputAction.CallbackContext obj)
    {
        isMoving = true;
        moveDirection = FBMove.ReadValue<float>();
    }
    private void FBMove_canceled(InputAction.CallbackContext obj)
    {
        isMoving = false;
        moveDirection = FBMove.ReadValue<float>();
    }
    private void turn_started(InputAction.CallbackContext context)
    {
        isTurning = true;
        turnDirection = Turn.ReadValue<float>();
    }

    private void Turn_canceled(InputAction.CallbackContext obj)
    {
        isTurning = false;
        turnDirection = Turn.ReadValue<float>();
    }

    private void Cast_started(InputAction.CallbackContext obj)
    {
        Collider[] colliders;
        colliders = (Physics.OverlapBox(transform.forward + transform.position + new Vector3(0, 0, 4), new Vector3
            (1, 6, 9), transform.rotation, onlyWater));

        if (isCasting == false)
        {
            isCasting = true;

            if (colliders.Length != 0)
            {
                Debug.Log("lets go fishing!");

                animator.Play("CastRodAnimation");

                WaterController water = colliders[0].GetComponent<WaterController>();
                if (water != null)
                {
                    Debug.Log("fffffff");
                    StartCoroutine (Fishing(water));
                }
            }
            else
            {
                Debug.Log("i hate fishing");
            }
        }
        else
        {
            animator.Play("IdleAnimation");
            isCasting = false;
        }
    }

    IEnumerator Fishing(WaterController water)
    {
        Debug.Log("FFFFFFFFUUUUUUUUUUUUUUUUUUCCCCCCCCCCCCKKKKKKKKKKK");
        while (isCasting == true)
        {
            Debug.Log("you are fishing in shallow water");

            Fish newFish = water.getFish();
            Inventory.Add(newFish);
            inventoryController.NewFish(newFish);
            yield return new WaitForSeconds(UnityEngine.Random.Range (1f, 3f));
        }

    }

    private void Cast_canceled(InputAction.CallbackContext obj)
    {
        
    }

    private void OnJump()
    {
        if (!isJumping)
        {
            rigidbody.AddForce(new Vector3(0, jumpValue, 0), ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Matrix4x4 rotationMatrix  = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.matrix = rotationMatrix;
        Gizmos.DrawWireCube(transform.forward + new Vector3(0, 0, 4), new Vector3(1, 6, 9));
    }

    private void FixedUpdate()
    {
        if (isMoving == true)
        {
            Vector3 direction = transform.forward * moveSpeed * moveDirection;
            direction.y = rigidbody.velocity.y;
            rigidbody.velocity = direction;
        }

        if (isTurning == true)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * turnDirection);
        }
    }
}