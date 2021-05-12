using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private Renderer render;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, speed);
        if (!render.isVisible) 
        {
            gameObject.SetActive(false);
        }
    }

}
