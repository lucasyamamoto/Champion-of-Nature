using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] VolumeButton volumeButton;

    public float Volume
    {
        get { return volumeSlider.value; }
        }

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

    // Update is called once per frame
    public void ChangeVolume()
    {
        if (!volumeButton.IsMute)
            AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        
        if(volumeButton && volumeButton.IsMute ){

            volumeSlider.value = 0;
        }
         else if(volumeSlider){
            volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
