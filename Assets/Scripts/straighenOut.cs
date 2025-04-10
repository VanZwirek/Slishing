using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class straighenOut : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime);
    }
}
