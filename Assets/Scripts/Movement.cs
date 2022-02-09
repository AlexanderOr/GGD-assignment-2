using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical") * speed));
    }
}
