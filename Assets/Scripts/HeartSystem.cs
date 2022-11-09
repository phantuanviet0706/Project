using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life = 3;

    // Update is called once per frame
    void Update()
    {
        if (life >= 1)
        {
            life--;
            Destroy(hearts[life].gameObject);
            if (life == 0)
            {

            }
        }
    }

    public void TakeDamage()
    {

    }
}
