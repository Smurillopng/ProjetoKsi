using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreS3 : MonoBehaviour
{
    public int scoreShip3;
    public Text scoreText;

    public static ScoreS3 instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void ScoreUpdate()
    {
        scoreShip3++;
        scoreText.text = scoreShip3.ToString();
    }
}
