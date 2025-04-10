using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemeraFollow : MonoBehaviour
{
    [SerializeField] GameObject anchor;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp
            (transform.position, anchor.transform.position, speed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp
            (transform.rotation, anchor.transform.rotation, rotationSpeed * Time.deltaTime);
    }
}