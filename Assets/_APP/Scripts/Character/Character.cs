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
}
