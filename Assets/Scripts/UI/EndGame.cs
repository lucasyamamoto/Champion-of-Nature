using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private CharacterHP playerHP;
    [SerializeField] private GameObject menu, resumeButton, gameOver;
    public AudioClip track;
    public AudioSource song;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP.Health == 0 && !dead)
        {
            dead = true;
            resumeButton.SetActive(false);
            song.Stop();
            song.clip = track;
            Time.timeScale = 0f;
            song.Play();
            menu.SetActive(true);
            gameOver.SetActive(true);
        }
    }
}
