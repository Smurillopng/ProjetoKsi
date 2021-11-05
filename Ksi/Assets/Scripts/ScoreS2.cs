using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreS2 : MonoBehaviour
{
    public int scoreShip2;
    public Text scoreText;

    public static ScoreS2 instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void ScoreUpdate()
    {
        scoreShip2++;
        scoreText.text = scoreShip2.ToString();
    }
}
