using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MudaCena : MonoBehaviour
{
    public float delay = 20;
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }
    
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(3);
    }
}
