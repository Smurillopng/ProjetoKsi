using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destruct();
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {

        if (hit.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

        if (hit.CompareTag("SpaceShip"))
        {
             
            Destroy(gameObject);
        }

    }

    private void Destruct()
    {

        Destroy(gameObject, 2f);
    }
}
