using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{

    public void CharacterMove()
    {

    }
    public void CharacterTalking(AnimationClip _animationClip, AudioClip _audioClip)
    {
        StartCoroutine(TalkingAnimation(_animationClip, _audioClip));
    }
    IEnumerator TalkingAnimation(AnimationClip _animationClip, AudioClip _audioClip)
    {
        //AnimationClipSettings clipSettings = AnimationUtility.GetAnimationClipSettings(_animationClip);
        //clipSettings.loopTime = true;
        //_animationClip.wrapMode = WrapMode.Loop; 
        yield return new WaitForSeconds(_audioClip.length);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WifeArea")
        {
            StartCoroutine(DialoguePlayer.instance.PlayDialogueAudios(AudioManager.instance.outdoorHouseDialogue, null));
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "House")
        {
            this.gameObject.GetComponentInChildren<Animator>().enabled = true;
            // switch scene to interior 
        }
    }
}
