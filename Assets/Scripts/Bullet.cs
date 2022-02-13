using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    int direction = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    public void ChangeDirection()
    {
        direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,12 * direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(direction == 1)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Enemy>().Damage();
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Movement>().Damage();
                Destroy(gameObject);
            }
        }
        
    }
}
