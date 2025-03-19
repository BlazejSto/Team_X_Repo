using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemDictionary : MonoBehaviour
{
    void Start()
    { 
        Dictionary<string, int> CollectableItems = new Dictionary<string, int>();
        CollectableItems.Add("BiggerItem", 0);
        CollectableItems.Add("DoubleItem", 0);
        CollectableItems.Add("FasterItem", 0);
        CollectableItems.Add("PiercingItem", 0);
        CollectableItems.Add("CoolMeterItem", 0);

        //Debug.Log(CollectableItems["Item1"]);

    }

}
