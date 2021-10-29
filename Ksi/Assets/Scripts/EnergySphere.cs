using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySphere : MonoBehaviour
{
    ShipController shipController;
    public float speed;
    public Transform followPoint;

    private bool follow = false;

    private Rigidbody2D rgdb;


    // Start is called before the first frame update
    void Start()
    {
        rgdb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            Follow();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("SpaceShip"))
        {
            followPoint = collider.gameObject.transform.Find("EnergyFollow").transform;
            follow = true;
            //aqui inicia a coleta de pontos
            
        }

    }

   

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, followPoint.position, speed * Time.deltaTime);
    }
}