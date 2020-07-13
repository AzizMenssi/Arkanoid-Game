using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed;
    bool started = false;
    public Transform racket;
    Vector3 startPos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        startPos = transform.position;
    }
    float HitAngle(Vector3 racketPos,float racketWidth)
    {
        return (transform.position.x-racketPos.x)/ racketWidth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!started) return;
        if(collision.gameObject.name == "Player")
        {
            rb.velocity = new Vector2(HitAngle(collision.transform.position,collision.collider.bounds.size.x), 1).normalized * speed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (started) return;

        transform.position = new Vector3(racket.position.x, transform.position.y);
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(1, 1).normalized * speed;
            started = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Death")
        {
            started = false;
            transform.position = startPos;
            rb.velocity = Vector3.zero;
            racket.transform.position = new Vector3(startPos.x, racket.transform.position.y);
            GameManager.health--;
        }
    }
}
