using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

    public float rateOfFire;
    float nextRangedAttackTime = 0f;

    public Transform ShotSpawnPoint;
    public GameObject shot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextRangedAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shooting();
                nextRangedAttackTime = Time.time + 1f / rateOfFire;
            }
        }
    }

    void Shooting()
    {
        Instantiate(shot, ShotSpawnPoint.position, ShotSpawnPoint.rotation);
    }
}