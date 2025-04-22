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