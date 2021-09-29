using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawn = 1.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start () {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy(){
        GameObject meteoro = Instantiate(asteroidPrefab) as GameObject;
        meteoro.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-screenBounds.y, screenBounds.y));
    }
    IEnumerator asteroidWave(){
        while(true){
            yield return new WaitForSeconds(respawn);
            spawnEnemy();
        }
    }
}
