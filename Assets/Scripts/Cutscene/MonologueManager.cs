using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueManager : MonoBehaviour
{
    [SerializeField] Text speechBalloon;
    private int index;
    private string[] monologue = {
        "Hello, there! My name is Mikhail and now I'm going to tell you a story, so get really comfortable and pay attention!",
        "Every year, the Council of Mages opens its doors to welcome new apprentices. As many want this opportunity, eventually this selection process became corrupted and skewed. So, over time, the quality of mages and their reputation declined.",
        "Also, as each school of magic has a seat limit, people with a lot of potential ended up never learning magic, simply because they were less privileged."
    };

    public void speak()
    {
        if (index < monologue.Length)
            speechBalloon.text = monologue[index++];
    }

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
