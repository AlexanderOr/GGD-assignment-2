using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    int health = 3;
    public GameObject bullet;
    GameObject a;
    int delay;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        a = transform.Find("a").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical") * speed));

        if (Input.GetKey(KeyCode.Space) && delay > 15)
        {
            Shoot();
        }

        delay++;
    }

    void Shoot()
    {
        delay = 0;
        Instantiate(bullet, a.transform.position, Quaternion.identity);

    }

    public void Damage()
    {
        health--;
        if (health == 0)
        {
            Destroy(gameObject);
        }
            
    }
}
