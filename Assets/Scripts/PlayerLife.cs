using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject[] hearts;
    public int life = 3;

    //[SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(rb.position.y < -5)
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("hit", true);
            if (life >= 1)
            {
                life--;
                Destroy(hearts[life].gameObject);
                if (life == 0)
                {
                    Die();
                }
            }
        }
    }

    private void Die()
    {
        //deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    } 

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
}
