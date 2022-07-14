using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_UI : MonoBehaviour
{

    public int number_of_loot;
    private bool Mouse_hover = false;

    // Update is called once per frame
    void Update()
    {
        if (Mouse_hover)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //add to inventory
                GameObject.Find("Inventory System").GetComponent<Inventory>().AddItemInventory(gameObject, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cursor"))
        {
            Mouse_hover = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cursor"))
        {
            Mouse_hover = false;
        }

    }
}
