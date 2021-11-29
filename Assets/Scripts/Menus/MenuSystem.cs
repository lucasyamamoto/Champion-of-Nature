using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    // Start the game
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    // Show the game options
    public void Options()
    {
        
    }

    // Return to main menu or close the game
    public void Quit()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
        else
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
    }

    // Pause the game
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    // Resume the game
    public void Resume()
    {
        Time.timeScale = 1f;
    }

    // Restart the game
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
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
