using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class DemoManager : MonoBehaviour
{
    [SerializeField]
    private VideoClip oldManClip;
    [SerializeField]
    private GameObject canvasRestart;
    float currentSourceLength;
    void Start()
    {
        VideoManager.instance.PlayVideo(oldManClip);
        StartCoroutine(StopVideo());
    }

    IEnumerator StopVideo()
    {
        yield return new WaitForSeconds(6f);
        VideoManager.instance.PauseVideo();
        AudioManager.instance.Play("MaleBreathing");

        for (int i = 0; i < AudioManager.instance.sounds.Length; i++)
        {
            if (AudioManager.instance.sounds[i].name == "MaleBreathing")
            {
                currentSourceLength = AudioManager.instance.sounds[i].clip.length;
                StartCoroutine(OnAudioDone(currentSourceLength));
            }
        }
    }
    IEnumerator OnAudioDone(float _audioTime)
    {
        yield return new WaitForSeconds(_audioTime + 1f);
        VideoManager.instance.PlayVideo(oldManClip);
        canvasRestart.SetActive(true);
    }
}
