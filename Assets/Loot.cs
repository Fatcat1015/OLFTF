using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (BoxCollider2D))]

public class Loot : MonoBehaviour
{
    BoxCollider2D self_collider;
    public bool lootable;
    public bool looting;
    //public GameObject slotprefab;
    public GameObject slot;
    bool displayedItems = false;


    [SerializeField] private SlotData data;

    void Start()
    {
        data.if_searched = false;
        self_collider = GetComponent<BoxCollider2D>();
        self_collider.isTrigger = true;
        lootable = false;
        

        slot.SetActive(false);
    }

    void Update()
    {

        if (lootable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                looting = true;
            }

        }

        if (looting)
        {
            slot.SetActive(true);
            if (!displayedItems)
            {
                DisplayItems();
            }

            if (!lootable)
            {
                ResetData();
                looting = false;
            }
        }

            
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player_detection"))
        {
            lootable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player_detection"))
        {
            lootable = false;
        }
    }

    private void ResetData()
    {
        data.if_searched = true;
        /*data.temp_LootSlots.Clear();
        data.temp_Loot_num.Clear();
        if (slot.transform.childCount != 0) {
            foreach (Transform child in slot.transform)
            {
                data.temp_LootSlots.Add(slot.transform.GetChild(0).gameObject);
                //data.Loot_num.Add(child.gameObject); add the number of items
            }
        }*/ 
        slot.SetActive(false);
    }

    public void DisplayItems()
    {
        if (data.if_searched)
        {
            if (data.temp_LootSlots.Count != 0)
            {
                for (int i = 0; i < data.temp_LootSlots.Count; i++)
                {
                    GameObject loot_item = Instantiate(data.temp_LootSlots[i]) as GameObject;
                    //attribute number to item
                    loot_item.transform.SetParent(slot.transform);
                    loot_item.GetComponent<RectTransform>().position = new Vector2(slot.transform.position.x + 10 * i, slot.transform.position.y);
                }
            }
        }
        else
        {
            for (int i = 0; i < data.LootSlots.Count; i++)
            {
                GameObject loot_item = Instantiate(data.LootSlots[i]) as GameObject;
                //attribute number to item
                loot_item.transform.SetParent(slot.transform);
                loot_item.GetComponent<RectTransform>().position = new Vector2(slot.transform.position.x + 10 * i, slot.transform.position.y);
            }
        }

        displayedItems = true;

    }
}
