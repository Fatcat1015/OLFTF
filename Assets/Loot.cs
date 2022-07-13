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
        slot = null;
    }

    void FixedUpdate()
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
            if(transform.childCount == 0)
            {
                slot = Instantiate(slotprefab, transform.position, transform.rotation);
                slot.transform.SetParent(transform);

                //according to data, generate loot
                for (int i = 0; i < data.LootSlots.Count; i++)
                {
                    GameObject loot_item = Instantiate(data.LootSlots[i],transform.position + new Vector3(i,0,0), transform.rotation);
                    //attribute number to item
                    loot_item.transform.SetParent(slot.transform);
                }
            }
            //after looting, change data.
        }
        else
        {
            Destroy(slot);
            slot = null;
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
}
