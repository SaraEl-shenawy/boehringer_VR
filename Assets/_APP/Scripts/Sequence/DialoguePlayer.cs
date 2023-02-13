using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayer : MonoBehaviour
{
    public Sound[] dockDialogue;
    public Sound[] outdoorHouseDialogue;
    public AudioSource dialogueSource;

    private void Start()
    {
        StartCoroutine(PlayDialogueAudios(dockDialogue));
    }
    IEnumerator PlayDialogueAudios(Sound[] _currentDialogue)
    {
        yield return null;

        for (int i = 0; i < _currentDialogue.Length; i++)
        {
            dialogueSource.clip = _currentDialogue[i].clip;

            dialogueSource.Play();
            while (dialogueSource.isPlaying)
            {
                yield return null;
            }
        }
    }
}




