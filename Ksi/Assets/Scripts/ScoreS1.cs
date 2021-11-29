using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreS1 : MonoBehaviour
{

    public int scoreShip1;
    public Text scoreText;
    public int highscore;
    public int lastscore;
    public Text leaderScore;

    public static ScoreS1 instance;

    // Start is called before the first frame update
    void Start()
    {
        scoreShip1 = 0;
        instance = this;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("scoreAtual", lastscore);
    
        if (scoreShip1 > highscore)
        {
            highscore = scoreShip1;
        }
        PlayerPrefs.SetInt("highscore", highscore);
    }

    void OnEnable()
    {
        scoreShip1 = PlayerPrefs.GetInt("scoreAtual");
        highscore  = PlayerPrefs.GetInt("highscore");
        leaderScore.text = highscore.ToString();
        scoreText.text = scoreShip1.ToString();
    }
    // Update is called once per frame
    public void ScoreUpdate()
    {
        scoreShip1++;
        lastscore = scoreShip1;
        scoreText.text = scoreShip1.ToString();
    }
}
