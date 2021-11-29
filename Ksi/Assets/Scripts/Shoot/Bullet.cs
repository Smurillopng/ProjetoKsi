using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public float autoDestroy;
    //public AudioClip somTiro;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.velocity = transform.up * speed;
        Destruct();
    }
    public void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.layer == 10)
        {
            ShipController shipController = hit.GetComponent<ShipController>();
            ShipNPController shipNPController = hit.GetComponent<ShipNPController>();
            {
                if (shipController != null)
                {
                    shipController.ShipTakeDamage(damage);
                }
                if (shipNPController != null)
                {
                    shipNPController.ShipTakeDamage(damage);
                }
            }
            Destroy(gameObject);
        }
        if (hit.CompareTag("Asteroid"))
        {
            AsteroidLife asteroidLife = hit.GetComponent<AsteroidLife>();
            {
                if (asteroidLife != null)
                {
                    Debug.Log("crash2");
                    asteroidLife.AsteroidTakeDamage(damage);
                }
            }
            Destroy(gameObject);
        }
        if (hit.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
    private void Destruct()
    {
        Destroy(gameObject, autoDestroy);
    }
}
