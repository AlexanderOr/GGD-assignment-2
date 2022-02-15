using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    int health = 3;
    public GameObject bullet,explosion,loseUI;
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
        StartCoroutine(Blink());
        if (health == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }
            
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
}
