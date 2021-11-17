using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public float autoDestroy;
    public AudioClip somTiro;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Destruct();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.layer == 10)
        {
            ShipController shipController = hit.GetComponent<ShipController>();
            ShipNPController shipNPController = hit.GetComponent<ShipNPController>();
            Debug.Log("crash1");
            {
                if (shipController != null)
                {
                    Debug.Log("crash2");
                    shipController.ShipTakeDamage(damage);
                }
                if (shipNPController != null)
                {
                    Debug.Log("crash3");
                    shipNPController.ShipTakeDamage(damage);
                }
            }
            AudioSource.PlayClipAtPoint(somTiro, this.gameObject.transform.position);
            Destroy(gameObject);
        }

        if (hit.CompareTag("Asteroid"))
        {
            AsteroidLife asteroidLife = hit.GetComponent<AsteroidLife>();
            Debug.Log("crash1");
            {
                if (asteroidLife != null)
                {
                    Debug.Log("crash2");
                    asteroidLife.AsteroidTakeDamage(damage);
                }
            }
            AudioSource.PlayClipAtPoint(somTiro, this.gameObject.transform.position);
            Destroy(gameObject);
        }

        if (hit.gameObject.layer == 8)
        {
            AudioSource.PlayClipAtPoint(somTiro, this.gameObject.transform.position);
            Destroy(gameObject);
        }


    }

    private void Destruct()
    {
        AudioSource.PlayClipAtPoint(somTiro, this.gameObject.transform.position);
        Destroy(gameObject, autoDestroy);
    }
}
