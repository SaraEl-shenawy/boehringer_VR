using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialoguePlayer : MonoBehaviour
{
    public AudioSource dialogueSource;

    public GameObject backPack;
    public GameObject userObject;
    public GameObject femaleCharacter;
    //public GameObject maleCharacter;
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
    }
    public IEnumerator PlayDialogueAudios(Sound[] _currentDialogue, UnityAction OnDockDialogueEnd)
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < _currentDialogue.Length; i++)
        {
            if (!_currentDialogue[i].isMale)
            {
                femaleCharacter.GetComponent<Animator>().Play(_currentDialogue[i].animationClipName);
            }
            //else
            //{
            //    maleCharacter.GetComponent<Animator>().StartPlayback();
            //}

            AudioManager.instance.Play(_currentDialogue[i].name);
            while (_currentDialogue[i].soundSource.GetComponent<AudioSource>().isPlaying)
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
        userObject.AddComponent<Rigidbody>();
        userObject.GetComponent<Collider>().enabled = true;
        userObject.GetComponent<Rigidbody>().useGravity = true;

    }
}




