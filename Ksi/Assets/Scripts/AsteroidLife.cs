using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AsteroidLife : MonoBehaviour
{
    public int health;

    public Transform energyDrop;
    public GameObject energy;
    public AudioClip destroiSom;
    public float volumeAsteroid; 
    public void AsteroidTakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Instantiate(energy, energyDrop.position, energyDrop.rotation);
            AudioSource.PlayClipAtPoint(destroiSom, this.gameObject.transform.position, volumeAsteroid);
            Destruct();
        }
    }

    private void Destruct()
    {   
        AudioSource.PlayClipAtPoint(destroiSom, this.gameObject.transform.position, volumeAsteroid);
        Destroy(gameObject);
    }
}
