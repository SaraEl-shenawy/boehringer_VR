using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialoguePlayer : MonoBehaviour
{
    public GameObject box;
    public GameObject userObject;
    public GameObject femaleCharacter;
    public GameObject maleCharacter;
    public GameObject doctorCharacter;
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
    public IEnumerator PlayDialogueAudios(Sound[] _currentDialogue, UnityAction OnDialogueEnd, int _dialogueIndex)
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < _currentDialogue.Length; i++)
        {
            if (_currentDialogue[i].npcType == NPCTypeEnum.male)
            {
                maleCharacter.GetComponent<Animator>().Play(_currentDialogue[i].animationClipName);
            }
            if (_currentDialogue[i].npcType == NPCTypeEnum.female)
            {
                femaleCharacter.GetComponent<Animator>().Play(_currentDialogue[i].animationClipName);
            }
            if (_currentDialogue[i].npcType == NPCTypeEnum.doctor)
            {
                doctorCharacter.GetComponent<Animator>().Play(_currentDialogue[i].animationClipName);
            }

            AudioManager.instance.Play(_currentDialogue[i].name, _dialogueIndex);
            while (_currentDialogue[i].soundSource.GetComponent<AudioSource>().isPlaying)
            {
                yield return null;
            }
        }
        if (OnDialogueEnd != null)
        {
            OnDialogueEnd();
            OnDialogueEnd = null;
        }
    }
    public void OnDockDialogueEnded()
    {
        // pickup action
        box.GetComponent<Collider>().enabled = true;
        userObject.AddComponent<Rigidbody>();
        userObject.GetComponent<Collider>().enabled = true;
        userObject.GetComponent<Rigidbody>().useGravity = true;
    }
    public void OnClinicDialogueEnded()
    {

    }
}




