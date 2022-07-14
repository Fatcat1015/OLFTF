using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_UI : MonoBehaviour
{
    Vector3 cursorlocation;
    SpriteRenderer cursor;
    GameObject loot;
    void Start()
    {
        cursor = GetComponent<SpriteRenderer>();
        loot = null;
    }

    void Update()
    {
        cursorlocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorlocation.x, cursorlocation.y, transform.position.z);

        if (Input.GetMouseButton(0))
        {
            cursor.color = Color.red;

            if(loot!= null)
            {
                //Destroy(loot);
            }
        }
        else
        {
            cursor.color = Color.white;
        }
    }

    public void Clicked()
    {
        cursor.color = Color.red;
    }

    public void Unclick()
    {
        cursor.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Loot"))
        {
            loot = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Loot"))
        {
            loot = null;
        }
    }
}
