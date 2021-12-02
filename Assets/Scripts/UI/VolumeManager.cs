using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Image SoundOn;
    [SerializeField] Image SoundOff;
    private bool isMute = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            Load();
        }
    }

    public void OnButtonPress()
    {
        if (isMute == false)
        {
            isMute = true;
            SoundOff.enabled = true;
            SoundOn.enabled = false;
            AudioListener.volume = 0;
        }
        else
        {
            isMute = false; 
            SoundOff.enabled = false;
            SoundOn.enabled = true;
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
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
