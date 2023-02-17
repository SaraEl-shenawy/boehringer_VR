using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSequence : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Chapter 2")
        {
            StartCoroutine(DialoguePlayer.instance.PlayDialogueAudios(DialoguePlayer.instance.dockDialogue, DialoguePlayer.instance.OnDockDialogueEnded));
            return;
        }
        if (SceneManager.GetActiveScene().name == "Chapter 3")
        {
            AudioManager.instance.Play("Im So Tired");
            //user start moving to kitchen
            return;
        }
    }
}
