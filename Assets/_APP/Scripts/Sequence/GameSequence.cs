using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSequence : MonoBehaviour
{
    bool checkUserAudioSource = false;
    public GameObject characterSource;
    public GameObject kitchenArea;


    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Chapter 2")
        {
            AudioManager.instance.Play("Water");
            StartCoroutine(DialoguePlayer.instance.PlayDialogueAudios(AudioManager.instance.dockDialogue, DialoguePlayer.instance.OnDockDialogueEnded));
            return;
        }
        if (SceneManager.GetActiveScene().name == "Chapter 3")
        {
            AudioManager.instance.Play("Im So Tired");
            checkUserAudioSource = true;
            //user start moving to kitchen
            return;
        }
    }
    private void Update()
    {
        if (checkUserAudioSource)
        {
            if (!characterSource.GetComponent<AudioSource>().isPlaying)
            {
                checkUserAudioSource = false;
                kitchenArea.SetActive(true);
            }
        }
    }
}

