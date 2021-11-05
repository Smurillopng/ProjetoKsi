using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreS1 : MonoBehaviour
{

    public int scoreShip1;
    public Text scoreText;

    public static ScoreS1 instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void ScoreUpdate()
    {
        scoreShip1++;
        scoreText.text = scoreShip1.ToString();
    }
}
