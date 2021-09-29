using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{

    public Transform ShotPoint;
    public float rateOfFire;
    float nextRangedAttackTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextRangedAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Shooting();
                nextRangedAttackTime = Time.time + 1f / rateOfFire;
            }
        }
    }

    void Shooting()
    {

    }
}
