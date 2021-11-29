using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    public float rateOfFire;
    float nextRangedAttackTime = 0f;
    public Transform ShotSpawnPoint;
    public GameObject shot;
    public GameObject som;

    void Update()
    {
        if (Time.time >= nextRangedAttackTime)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && PauseManager.isPaused == false)
            {
                Shooting();
                nextRangedAttackTime = Time.time + 1f / rateOfFire;
            } else if (Input.GetKeyDown(KeyCode.Mouse0) && PauseManager.isPaused == true){}
        }
    }

    void Shooting()
    {
        som.GetComponent<AudioSource>().Play();
        Instantiate(shot, ShotSpawnPoint.position, ShotSpawnPoint.rotation);
    }
}