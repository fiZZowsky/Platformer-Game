using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUI : MonoBehaviour
{
    [SerializeField] Joystick joystick;

    void Start()
    {
        if (Application.isMobilePlatform)
        {
            joystick.gameObject.SetActive(true);
        }
        else
        {
            joystick.gameObject.SetActive(false);
        }
    }
}