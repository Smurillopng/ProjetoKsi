using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreS4 : MonoBehaviour
{
    public int scoreShip4;
    public Text scoreText;

    public static ScoreS4 instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void ScoreUpdate()
    {
        scoreShip4++;
        scoreText.text = scoreShip4.ToString();
    }
}
