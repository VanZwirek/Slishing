/*****************************************************************************
// File Name : CameraFollow.cs
// Author : Van A. Zwirek
// Creation Date : Febuary 12, 2025
//
// Brief Description : makes the camera follow around the player, and uses Lerp to make it smooth
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemeraFollow : MonoBehaviour
{
    public GameObject anchor;
    public float speed;
    public float rotationSpeed;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp
            (transform.position, anchor.transform.position, speed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp
            (transform.rotation, anchor.transform.rotation, rotationSpeed * Time.deltaTime);
    }

    public void SetAnchor(GameObject i)
    {
        anchor = i;
    }
}