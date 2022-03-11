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
    public int score;
    public GameObject bullet, explosion;
    public AudioSource explosionSound;

    public bool canShoot;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        explosionSound = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {

        if (canShoot)
        {
            InvokeRepeating("Shoot", firerate, firerate);
        }
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
            collision.gameObject.GetComponent<MainUI>().LifeLoss();
            Die();
        }
    }

    void Die()
    {
        explosionSound.Play();
        Instantiate(explosion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        Destroy(gameObject);
    }
    
    public void Damage()
    {
        health--;
        if(health == 0)
        {
            Die();
        }
    }

    void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
    }

}
