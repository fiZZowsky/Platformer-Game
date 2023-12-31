using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Button soundButton;
    void Start()
    {
        volumeSlider.gameObject.SetActive(false);

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }

        Load();
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        soundButton.gameObject.GetComponent<SoundButtonController>().manageButtonIcon();
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
