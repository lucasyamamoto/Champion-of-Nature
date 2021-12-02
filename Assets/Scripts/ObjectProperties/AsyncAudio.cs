using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncAudio : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private bool playOnEnable;
    [SerializeField] private bool playOnDisable;

    void PlayAudio()
    {
        GameObject audioObject = new GameObject();
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();

        new WaitForSecondsRealtime(audioClip.length);
        Destroy(audioObject, 1f);
    }

    void OnEnable()
    {
        if (playOnEnable)
        {
            PlayAudio();
        }
    }

    void OnDisable()
    {
        if (playOnDisable)
        {
            PlayAudio();
        }
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
