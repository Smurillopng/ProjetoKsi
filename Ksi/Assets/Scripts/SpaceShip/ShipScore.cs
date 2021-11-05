using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScore : MonoBehaviour
{
    public int totalPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreCount(int points)
    {
        totalPoints = totalPoints + points;

        ScoreS1.instance.scoreShip1 = totalPoints;
        ScoreS1.instance.ScoreUpdate();
    }

}
