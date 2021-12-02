using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    [SerializeField] private Toggle aquaslide, stoneshield, firedart, windstep;
    [SerializeField] private SkillObserver skillObserver;
    // Start the game
    public void Play()
    {
        if (Convert.ToByte(aquaslide.isOn) + Convert.ToByte(stoneshield.isOn) + Convert.ToByte(firedart.isOn) + Convert.ToByte(windstep.isOn) == 2){
            skillObserver.SkillSetter();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Close the game
    public void Quit()
    {
        /*
        // In Unity Editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        */

        // In real game
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
