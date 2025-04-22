using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public List<Fish> FishList;

    public Fish getFish()
    {
        int i = Random.Range(0, FishList.Count);
        return FishList[i];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            Debug.Log("i hit da watuh");
            collision.gameObject.GetComponent<Rigidbody>().velocity = collision.contacts[0].normal * 100;
        }
    }
}
