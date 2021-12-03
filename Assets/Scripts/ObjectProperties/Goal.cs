using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    [SerializeField] Text message;
    [SerializeField] private GameObject menu, resumeButton, gameOver;
    public AudioClip track;
    public AudioSource song;

    // Show win menu
    private void OnCollisionEnter2D(Collision2D collision)
    {
        resumeButton.SetActive(false);
        message.color = new Color(0, 0, 127);
        message.text = "<b>CONGRATULATIONS</b>";
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
