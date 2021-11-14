using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    public InputField nameField;
    public Text playerNome;
 
    // Player name variable and property to access
    // it from other scripts.
    string playerName;
    public string PlayerName
    {
        get{ return playerName; }
        set{ Debug.Log("You are not allowed to set the player name like that"); }
    }
 
    //Use this on a "Submit" button to set the playerName variable.
    public void SubmitName()
    {
        if(string.IsNullOrEmpty(nameField.text) == false)
        {
            playerName = nameField.text;
            playerNome.text = nameField.text;
        }
    }
}
 
