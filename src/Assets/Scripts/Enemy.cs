using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Renderer render;

    [SerializeField]
    private AudioClip explosionClip;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -GameManager.gameManager.enemiesSpeed);
        if(!render.isVisible && transform.position.y < 0) 
        {
            PlayerController player = GameManager.gameManager.player.GetComponent<PlayerController>();
            player.TakeDamage();
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.audioManager.PlayClip(explosionClip);
        if (collision.gameObject.tag == "Player") 
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage();
            gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "Bullet") 
        {
            collision.gameObject.SetActive(false);
            GameManager.gameManager.AddPoints(100);
            gameObject.SetActive(false);
        }
    }
}
