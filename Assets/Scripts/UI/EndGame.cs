using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private CharacterHP playerHP;
    [SerializeField] private GameObject menu, resumeButton, gameOver;
    public AudioClip track;
    public AudioSource song;

    // Show defeat menu
    public void GameOver()
    {
        resumeButton.SetActive(false);
        song.Stop();
        song.clip = track;
        Time.timeScale = 0f;
        song.Play();
        menu.SetActive(true);
        gameOver.SetActive(true);
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
