using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLife : MonoBehaviour
{
    public int health;

    public Transform energyDrop;
    public GameObject energy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AsteroidTakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Instantiate(energy, energyDrop.position, energyDrop.rotation);
            Destruct();
        }
    }

    private void Destruct()
    {
        Destroy(gameObject);
    }
}
