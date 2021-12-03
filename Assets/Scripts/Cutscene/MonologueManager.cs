using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonologueManager : MonoBehaviour
{
    [SerializeField] Text speechBalloon;
    [SerializeField] List<GameObject> images;
    [SerializeField] Button nextButton;
    [SerializeField] GameObject skipButton;
    private Coroutine coroutine;
    private bool writing;
    private int indexMonologue, indexImage, i;
    private string[] monologue = {
        "Hello, there! My name is Mikhail and now I'm going to tell you a story, so get really comfortable and pay attention because this tutorial won't be shown again!",
        "Every year, the Council of Mages opens its doors to welcome new apprentices (that's you). As many want this opportunity, slowly the selection process became corrupted and skewed...",
        "Also, as each school of magic has a seat limit, people with a lot of potential, but with a less privileged origin, ended up never learning magic (I hope that's not you)...",
        "So, over time, the quality of mages and their reputation declined. To combat this decay, the Council decided to create a selective process: the Champion of Nature (aka game's name)...",
        "Taking place every three years, its beginning is simple: every neophyte (again, you) learns Eldritch Edge, a melee combat spell that conjures a blade made of pure arcane energy...",
        "Afterwards, participants are loaned the powers of two of the four elements (guess which ones) through enchanted bracelets with spells from the chosen schools...",
        "The powers are: Aquaslide (water dash, weeeh), Stoneshield (shield made of, well, stones), Firedart (fireball attack - innovative, eh?) and Windstep (double jump - suck it, Physics)...",
        "Finally, the competitors are thrown into The Tower: a dungeon full of enemies controlled by the Council. Don't be afraid to kill them, because they are not real people... I guess...",
        "Whoever manages to reach the end is admitted. Easy, right? To survive, you'll have to use your head (and your hands. In fact, mostly your hands), so memorize this scroll:",
        "That's all, Folks! Good luck, young apprentice (I could say Padawan, but copyrights forbid me)!"
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
            if (!writing)
            {
                if (indexMonologue >= 5 && indexMonologue <= 9)
                    images[indexImage++].SetActive(false);

                writing = true;
                coroutine = StartCoroutine(wait(.03f));
            }
            else
            {
                StopCoroutine(coroutine);
                speechBalloon.text = monologue[indexMonologue];

                printImage();
            }
        }
        else
            skip();
    }

    // Write letter by letter
    private IEnumerator wait(float waitTime)
    {
        for (i = 0, speechBalloon.text = ""; i < monologue[indexMonologue].Length; i++)
        {
            speechBalloon.text += monologue[indexMonologue][i];
            yield return new WaitForSeconds(waitTime);
        }

        printImage();
    }

    // Print a image
    private void printImage()
    {
        if (indexMonologue >= 4 && indexMonologue <= 8)
        {
            images[indexImage].SetActive(true);
            indexMonologue++;
        }
        else if (++indexMonologue == monologue.Length)
        {
            skipButton.SetActive(false);
            nextButton.GetComponentInChildren<Text>().text = "<b>CONTINUE</b>";
        }

        writing = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        writing = false;
        indexMonologue = indexImage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
