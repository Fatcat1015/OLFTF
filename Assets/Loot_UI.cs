using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Loot_UI : MonoBehaviour
{

    public int number_of_loot = 0;

    public void additem()
    {
        FindObjectOfType<Inventory>().AddItemInventory(gameObject);
    }
}
