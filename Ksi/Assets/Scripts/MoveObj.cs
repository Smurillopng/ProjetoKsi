using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    public float vel = 10.0f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-vel, 0);
    }
    void Update()
    {
        // Roda o sprite
        transform.Rotate(new Vector3(0, 0, 90 * Time.deltaTime));
        if (transform.position.x < -50 || transform.position.x > +60) //|| transform.position.y < -25 || transform.position.y > 35
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject)
            rb.isKinematic = false;
        //Debug.Log("Bateu!");
    }
}
