using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject Hotbar;
    public GameObject Inventory_Interface;
    public GameObject Crafting_Interface;

    public List<string> Inventory_Items = new List<string>();

    public bool open_inventory = false;

    private void Start()
    {
        Inventory_Interface.SetActive(false);
        Crafting_Interface.SetActive(false);
    }
    void Update()
    {
        //when tab is pressed, call up inventory interface and crafting interface
        //when tab is pressed again, recall the interfaces
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            open_inventory = !open_inventory;
        }

        if (open_inventory)
        {
            Inventory_Interface.SetActive(true);
            Crafting_Interface.SetActive(true);
        }
        else
        {
            Inventory_Interface.SetActive(false); ;
            Crafting_Interface.SetActive(false);
        }
        
        //sort items into slots in hotbar/inventory

        if(Inventory_Items.Count!= 0)
        {
            foreach (string item in Inventory_Items)
            {

            }
        }
    }

    public void AddItemInventory(GameObject item, int number)
    {
        Inventory_Items.Add(item.name);
        Destroy(item);
    }
}
