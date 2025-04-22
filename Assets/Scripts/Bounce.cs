using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
