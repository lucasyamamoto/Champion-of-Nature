using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
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
        Application.LoadLevel(1);
        Time.timeScale = 1f;
    }

    // Return to main menu
    public void Quit()
    {
        Application.LoadLevel(0);
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
