/*****************************************************************************
// File Name : Bounce.Cs
// Author : Van A. Zwirek
// Creation Date : April 21, 2025
//
// Brief Description : this one just bounces you back when you hit the water / whatever it's attached too
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private void OnCollisionStay (Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Debug.Log("i hit da watuh");
            collision.gameObject.GetComponent<Rigidbody>().velocity = collision.contacts[0].normal * 75 * -1;
            Debug.DrawRay(collision.transform.position, collision.contacts[0].normal * 100 * -1);
        }
    }
}
