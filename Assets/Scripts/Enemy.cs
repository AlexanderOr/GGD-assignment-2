using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    public float health;
    public float xSpeed;
    public float ySpeed;
    public float firerate;

    public bool canShoot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed * -1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Movement>().Damage();
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    
    void Damage()
    {
        health--;
        if(health == 0)
        {
            Die();
        }
    }
}