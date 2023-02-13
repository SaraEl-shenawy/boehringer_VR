using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialoguePlayer : MonoBehaviour
{
    public Sound[] dockDialogue;
    public Sound[] outdoorHouseDialogue;
    public AudioSource dialogueSource;

    public GameObject backPack;
    public static DialoguePlayer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        StartCoroutine(PlayDialogueAudios(dockDialogue, OnDockDialogueEnded));
    }
    public IEnumerator PlayDialogueAudios(Sound[] _currentDialogue, UnityAction OnDockDialogueEnd)
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
        if (OnDockDialogueEnd != null)
        {
            OnDockDialogueEnd();
            OnDockDialogueEnd = null;
        }
    }
    public void OnDockDialogueEnded()
    {
        // pickup action
        backPack.SetActive(true);
    }
}




