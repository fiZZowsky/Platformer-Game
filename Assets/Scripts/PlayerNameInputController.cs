using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameInputController : MonoBehaviour
{
    public TMP_InputField playerNameField;
  

    void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerName"))
        {
            PlayerPrefs.SetString("PlayerName", "Player1");
        }

        Load();
    }

    public void changePlayerName()
    {
        PlayerPrefs.SetString("PlayerName", playerNameField.text);
    }

    private void Load()
    {
        playerNameField.text = PlayerPrefs.GetString("PlayerName");
    }



}
