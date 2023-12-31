
using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundButtonController : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Sprite SoundImageOn;
    [SerializeField] private Sprite SoundImageOff;

    private AudioSource backgroundMusic;

    private void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }

    public void manageButtonIcon()
    {
        if(AudioListener.volume <= 0)
        {
            gameObject.GetComponent<Image>().sprite = SoundImageOff;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = SoundImageOn;
        }
    }


    public void SwitchOnOff()
    {
        volumeSlider.gameObject.SetActive(!volumeSlider.gameObject.activeSelf);
    }
       

}
