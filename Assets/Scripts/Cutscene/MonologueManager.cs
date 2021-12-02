using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueManager : MonoBehaviour
{
    [SerializeField] Text speechBalloon;
    private int index, i;
    private string[] monologue = {
        "Hello, there! My name is Mikhail and now I'm going to tell you a story, so get really comfortable and pay attention!",
        "Every year, the Council of Mages opens its doors to welcome new apprentices. As many want this opportunity, eventually this selection process became corrupted and skewed.",
        "Also, as each school of magic has a seat limit, people with a lot of potential, but with a less privileged origin, ended up never learning magic.",
        "So, over time, the quality of mages and their reputation declined. To combat this decay, the Council decided to create a selective process: the Champion of Nature!",
        "Taking place every three years, its beginning is simple: every neophyte learns the Eldritch Edge, a simple melee combat spell that conjures a blade made of pure arcane energy.",
        "Afterwards, participants are loaned the powers of two of the four elements through enchanted bracelets with spells from the chosen schools.",
        "The powers are: Aquaslide (water dash), Stoneshield (shield made of, well, stones), Firedart (fireball attack) and Windstep (double jump)."
    };

    // 
    public void speak()
    {
        if (index < monologue.Length)
        {
            StartCoroutine(wait(.05f));
        }
    }

    // 
    private IEnumerator wait(float waitTime)
    {
        for (i = 0, speechBalloon.text = ""; i < monologue[index].Length; i++)
        {
            speechBalloon.text += monologue[index][i];
            yield return new WaitForSeconds(waitTime);
        }
        index++;
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
