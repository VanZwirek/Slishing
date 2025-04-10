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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
