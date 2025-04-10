using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject UITab;
    [SerializeField] private Transform parent;

    public void NewFish(Fish fish)
    {
        GameObject newTab = Instantiate(UITab, parent);
        newTab.transform.Find("FishName").GetComponent<TMP_Text>().text = (fish.FishName);
        newTab.transform.Find("FishImage").GetComponent<Image>().sprite = (fish.FishSprite);
    }

    public void RemoveFish(Fish fish)
    {
        for (int index = 0; index < parent.transform.childCount; index++)
        { 
            if((parent.transform.GetChild(index).Find("FishName").GetComponent<TMP_Text>().text == fish.FishName) && 
                (parent.transform.GetChild(index).gameObject.activeSelf))
            {
                print("i'm removing this Freak'in fish! " + fish.FishName);
                parent.transform.GetChild(index).gameObject.SetActive(false);
                Destroy(parent.transform.GetChild(index).gameObject);
                break;
            }
        }
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
