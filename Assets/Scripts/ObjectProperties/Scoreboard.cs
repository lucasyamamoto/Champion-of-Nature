using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private Score score;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        score.Restart();
        text = GetComponent<Text>();
        text.text = $"{score.CurrentScore}";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{score.CurrentScore}";
    }
}
