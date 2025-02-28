using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class ItemDictionary : MonoBehaviour
{
    void Start()
    { 
        Dictionary<string, int> CollectableItems = new Dictionary<string, int>();
        CollectableItems.Add("Item1", 0);
        CollectableItems.Add("Item2", 0);
        CollectableItems.Add("Item3", 0);
        CollectableItems.Add("Item4", 0);
        CollectableItems.Add("Item5", 0);

        Debug.Log(CollectableItems["Item1"]);

    }

}
