using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileUI : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] Button jumpButton;

    void Start()
    {
        if (Application.isMobilePlatform)
        {
            joystick.gameObject.SetActive(true);
            jumpButton.gameObject.SetActive(true);
        }
        else
        {
            joystick.gameObject.SetActive(false);
            jumpButton.gameObject.SetActive(false);
        }
    }
}