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