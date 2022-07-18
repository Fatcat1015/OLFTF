using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject Hotbar;
    public GameObject Inventory_Interface;
    public GameObject Crafting_Interface;
    public int maximum_carrying;

    public int Hotbar_max;

    public List<GameObject> Inventory_Items = new List<GameObject>();

    public bool open_inventory = false;

    private void Start()
    {
        Inventory_Items.Clear();
        maximum_carrying = 10;
        Hotbar_max = 2;
        Inventory_Interface.SetActive(false);
        Crafting_Interface.SetActive(false);
        Hotbar.SetActive(true);
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
            Inventory_Interface.SetActive(false); 
            Crafting_Interface.SetActive(false);
        }
        
        //sort items into slots in hotbar/inventory

        foreach(Transform child in Inventory_Interface.transform)
        {

        }
    }

    public void AddItemInventory(GameObject item)
    {
        if(Inventory_Items.Count < maximum_carrying )
        {
            Inventory_Items.Add(item);
            if (Hotbar.transform.childCount < Hotbar_max)
            {
                item.transform.SetParent(Hotbar.transform);
                item.GetComponent<RectTransform>().position = Hotbar.transform.position;
            }
            else
            {
                item.transform.SetParent(Inventory_Interface.transform);
                item.GetComponent<RectTransform>().position = Inventory_Interface.transform.position;
            }
            
        }
        else
        {
            Debug.Log("can not fit into inventory");
            Debug.Log(Inventory_Items.Count);
            Debug.Log(maximum_carrying);
        }
        SortInventory();
    }

    public void SortInventory()
    {
        for (int i = 0; i<Hotbar.transform.childCount; i++)
        {
            Hotbar.transform.GetChild(i).transform.position = new Vector2(Hotbar.transform.position.x + 5*i -100, Hotbar.transform.position.y);
        }

        for (int i = 0; i < Inventory_Interface.transform.childCount; i++)
        {
            Inventory_Interface.transform.GetChild(i).transform.position = new Vector2(Inventory_Interface.transform.position.x + 5 * i - 100, Inventory_Interface.transform.position.y);
        }
    }
}
