using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColoector : MonoBehaviour
{
    private int Point =0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruits"))
        {
            Destroy(collision.gameObject);
        }
    }
}
