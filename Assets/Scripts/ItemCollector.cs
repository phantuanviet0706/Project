using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int points = 0;

    [SerializeField] public TextMeshProUGUI pointsText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruits"))
        {
            //collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            points++;
            Debug.Log("Chery: "+points);
            pointsText.SetText("Fruits Collected: " + points);
        }
    }
}
