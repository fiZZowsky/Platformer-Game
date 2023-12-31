using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameTextController : MonoBehaviour
{

    public Text playerName;

    void Start()
    {
        playerName.text = "Player Name: " + PlayerPrefs.GetString("PlayerName");
    }

 
}
