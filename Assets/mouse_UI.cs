using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_UI : MonoBehaviour
{
    Vector3 cursorlocation;
    SpriteRenderer cursor;
    void Start()
    {
        cursor = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        cursorlocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorlocation.x, cursorlocation.y, transform.position.z);

        if (Input.GetMouseButton(0))
        {
            cursor.color = Color.red;
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
}
