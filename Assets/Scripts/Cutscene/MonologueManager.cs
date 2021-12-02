using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonologueManager : MonoBehaviour
{
    [SerializeField] Text speechBalloon;
    [SerializeField] List<GameObject> images;
    private bool corroutine;
    private int indexMonologue, indexImage, i;
    private string[] monologue = {
        "Hello, there! My name is Mikhail and now I'm going to tell you a story, so get really comfortable and pay attention!",
        "Every year, the Council of Mages opens its doors to welcome new apprentices. As many want this opportunity, eventually this selection process became corrupted and skewed.",
        "Also, as each school of magic has a seat limit, people with a lot of potential, but with a less privileged origin, ended up never learning magic.",
        "So, over time, the quality of mages and their reputation declined. To combat this decay, the Council decided to create a selective process: the Champion of Nature!",
        "Taking place every three years, its beginning is simple: every neophyte learns Eldritch Edge, a basic melee combat spell that conjures a blade made of pure arcane energy.",
        "Afterwards, participants are loaned the powers of two of the four elements through enchanted bracelets with spells from the chosen schools.",
        "The powers are: Aquaslide (water dash), Stoneshield (shield made of, well, stones), Firedart (fireball attack - innovative, isn't it?) and Windstep (double jump).",
        "Finally, the competitors are thrown into The Tower: a dungeon full of enemies controlled by the Council. Don't be afraid to kill them, because they are not real people... I guess."
    };

    // Skip to main menu
    public void skip()
    {
        StopAllCoroutines();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Continue monologue
    public void next()
    {
        if (indexMonologue < monologue.Length)
        {
            if (!corroutine)
            {
                if (indexMonologue >= 5 && indexMonologue <= 6)
                    images[indexImage++].SetActive(false);

                corroutine = true;
                StartCoroutine(wait(.03f));
            }
            else
            {
                StopAllCoroutines();
                speechBalloon.text = monologue[indexMonologue];

                if (indexMonologue >= 4 && indexMonologue <= 5)
                    images[indexImage].SetActive(true);
                indexMonologue++;
                corroutine = false;
            }
        }
    }

    // Write letter by letter
    private IEnumerator wait(float waitTime)
    {
        for (i = 0, speechBalloon.text = ""; i < monologue[indexMonologue].Length; i++)
        {
            speechBalloon.text += monologue[indexMonologue][i];
            yield return new WaitForSeconds(waitTime);
        }

        if (indexMonologue >= 4 && indexMonologue <= 5)
            images[indexImage].SetActive(true);
        indexMonologue++;
        corroutine = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        corroutine = false;
        indexMonologue = indexImage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
