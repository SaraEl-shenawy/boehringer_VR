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
            AudioManager.instance.Play("Water", AudioManager.instance.sounds);
            StartCoroutine(DialoguePlayer.instance.PlayDialogueAudios(AudioManager.instance.dockDialogue, DialoguePlayer.instance.OnDockDialogueEnded));
            return;
        }
        if (SceneManager.GetActiveScene().name == "Chapter 3")
        {
            AudioManager.instance.Play("Im So Tired", AudioManager.instance.sounds);
            checkUserAudioSource = true;
            //user start moving to kitchen
            return;
        }
        if (SceneManager.GetActiveScene().name == "Clinic")
        {
            AudioManager.instance.Play("Shortness of breath", AudioManager.instance.sounds);
            StartCoroutine(OnDoctorAudioEnd(AudioManager.instance.Play("Shortness of breath", AudioManager.instance.sounds)));
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

    IEnumerator OnDoctorAudioEnd(float clipTime)
    {
        yield return new WaitForSeconds(clipTime);
        UIManager.instance.ActivateFirstYesPanel();
    }
}

