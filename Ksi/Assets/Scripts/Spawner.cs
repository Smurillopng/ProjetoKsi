using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawn = 1.0f;
    void Start()
    {
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy()
    {
        GameObject meteoro = Instantiate(asteroidPrefab) as GameObject;
        meteoro.transform.position = new Vector2(50, Random.Range(-25, 35));
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawn);
            spawnEnemy();
        }
    }
}
