using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour
{
    [SerializeField] Image SoundOn;
    [SerializeField] Image SoundOff;
    [SerializeField] VolumeManager volumeManager;
    private bool isMute = false;
    public bool IsMute
    {
        get
        {
            return isMute;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("isMute"))
        {
            PlayerPrefs.SetInt("isMute", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();

        if (isMute)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        
    }

    private void UpdateButtonIcon()
    {
        if (isMute)
        {
            SoundOn.enabled = false;
            SoundOff.enabled = true;
        }
        else
        {
            SoundOn.enabled = true;
            SoundOff.enabled = false;
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
            AudioListener.volume = volumeManager.Volume;
        }
        Save();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Load()
    {
        isMute = PlayerPrefs.GetInt("isMute") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("isMute", isMute ? 1 : 0);
    }
}
