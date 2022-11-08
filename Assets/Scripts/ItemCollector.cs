using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int points = 0;

    [SerializeField] private Text pointsText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruits"))
        {
            //collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            points++;
            Debug.Log("Chery: "+points);
            //pointsText.text = "Fruits Collected: " + points;
        }
    }
}
