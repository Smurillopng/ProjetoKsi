using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MudaCena : MonoBehaviour
{
    public float delay;
    public int timerc;
    public Text countDown;
    void Start()
    {
        InvokeRepeating("DecreaseTimer", 1.0f, 1.0f);
        StartCoroutine(LoadLevelAfterDelay(delay));
    }
    
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Leaderboard");
    }

    void DecreaseTimer()
    {
        if (timerc > 0)
        {
            timerc -= 1;
        }
    }

    void Update()
    {
        countDown.text = timerc.ToString();
    }
}
