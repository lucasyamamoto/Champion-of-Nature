using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private CharacterHP playerHP;
    [SerializeField] private GameObject menu, resumeButton, gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP.Health == 0)
        {
            resumeButton.SetActive(false);
            menu.SetActive(true);
            gameOver.SetActive(true);
        }
    }
}
