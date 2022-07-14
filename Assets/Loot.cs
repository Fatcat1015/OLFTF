using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (BoxCollider2D))]

public class Loot : MonoBehaviour
{
    BoxCollider2D self_collider;
    public bool lootable;
    public bool looting;
    public GameObject slotprefab;
    public GameObject slot;

    [SerializeField] private SlotData data;

    void Start()
    {
        self_collider = GetComponent<BoxCollider2D>();
        self_collider.isTrigger = true;
        lootable = false;
        slot = Instantiate(slotprefab, transform.position, transform.rotation) as GameObject;
        slot.transform.SetParent(transform);

        for (int i = 0; i < data.LootSlots.Count; i++)
        {
            GameObject loot_item = Instantiate(data.LootSlots[i], transform.position + new Vector3(i, 0, 0), transform.rotation) as GameObject;
            //attribute number to item
            loot_item.transform.SetParent(slot.transform);    
        }

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
        else
        {
            looting = false;
        }


        if (looting)
        {
            //generate loot slots prefab
            if(!slot.activeSelf)
            {
                slot.SetActive(true);
            }
            //after looting, change data.
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
            ResetData();
        }
    }

    private void ResetData()
    {
        /*
        data.if_searched = true;
        data.temp_LootSlots.Clear();
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
}
