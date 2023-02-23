using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public Sound[] dockDialogue;
    public Sound[] outdoorHouseDialogue;
    public static AudioManager instance;
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

        foreach (Sound s in sounds)
        {
            if (s.soundSource.GetComponent<AudioSource>() == null)
            {
                s.source = s.soundSource.AddComponent<AudioSource>();
                s.source.spatialBlend = 1f;
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }
        foreach (Sound s in dockDialogue)
        {
            if (s.soundSource.GetComponent<AudioSource>() == null)
            {
                s.source = s.soundSource.AddComponent<AudioSource>();
                s.source.spatialBlend = 1f;
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }
        foreach (Sound s in outdoorHouseDialogue)
        {
            if (s.soundSource.GetComponent<AudioSource>() == null)
            {
                s.source = s.soundSource.AddComponent<AudioSource>();
                s.source.spatialBlend = 1f;
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }
    }
    public void Play(string _targetName)
    {
        foreach (var item in sounds)
        {
            if (item.name == _targetName)
            {
                item.soundSource.GetComponent<AudioSource>().clip = item.clip;
                item.soundSource.GetComponent<AudioSource>().Play();
            }
        }
        foreach (var item in dockDialogue)
        {
            if (item.name == _targetName)
            {
                item.soundSource.GetComponent<AudioSource>().clip = item.clip;
                item.soundSource.GetComponent<AudioSource>().Play();
            }
        }
        foreach (var item in outdoorHouseDialogue)
        {
            if (item.name == _targetName)
            {
                item.soundSource.GetComponent<AudioSource>().clip = item.clip;
                item.soundSource.GetComponent<AudioSource>().Play();
            }
        }
    }
    public void Pause(string _targetName)
    {
        foreach (var item in sounds)
        {
            if (item.name == _targetName)
            {
                item.source.Pause();
            }
        }
    }
}
