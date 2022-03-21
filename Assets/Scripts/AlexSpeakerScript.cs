using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexSpeakerScript : MonoBehaviour
{
    [SerializeField] private AudioClip [] music;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool canSwitchMusic = false;
    [SerializeField] private int randomMusicNumber;
    [SerializeField] private GameObject skipPrompt;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        randomMusicNumber = Random.Range(0, music.Length);
        audioSource.clip = music[randomMusicNumber];
        audioSource.Play();
        skipPrompt.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(canSwitchMusic & Input.GetKeyDown(KeyCode.Space))
        {
            randomMusicNumber = Random.Range(0, music.Length);
            audioSource.clip = music[randomMusicNumber];
            audioSource.Play();
        }
    }


    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            canSwitchMusic = true;
            skipPrompt.GetComponent<CanvasGroup>().alpha = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
       if(other.tag == "Player")
       {
            canSwitchMusic = false;
            skipPrompt.GetComponent<CanvasGroup>().alpha = 0;
       } 
    }
}
