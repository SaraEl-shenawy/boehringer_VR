using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public Sound[] dockDialogue;
    public Sound[] outdoorHouseDialogue;
    public Sound[] firstClinicDialogue;
    public Sound[] secondClinicDialogue;

    float clipLength;

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
                s.clipLength = s.clip.length;
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
        foreach (Sound s in firstClinicDialogue)
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
        foreach (Sound s in secondClinicDialogue)
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
    public float Play(string _targetName, Sound[] _audioArray)
    {
        foreach (var item in _audioArray)
        {
            if (item.name == _targetName)
            {
                item.soundSource.GetComponent<AudioSource>().clip = item.clip;
                item.soundSource.GetComponent<AudioSource>().Play();
                clipLength = item.clipLength;
            }
        }
        foreach (var item in sounds)
        {
            if (item.name == _targetName)
            {
                item.soundSource.GetComponent<AudioSource>().clip = item.clip;
                item.soundSource.GetComponent<AudioSource>().Play();
                clipLength = item.clipLength;
            }
        }
        foreach (var item in dockDialogue)
        {
            if (item.name == _targetName)
            {
                item.soundSource.GetComponent<AudioSource>().clip = item.clip;
                item.soundSource.GetComponent<AudioSource>().Play();
                clipLength = item.clipLength;
            }
        }
        foreach (var item in outdoorHouseDialogue)
        {
            if (item.name == _targetName)
            {
                item.soundSource.GetComponent<AudioSource>().clip = item.clip;
                item.soundSource.GetComponent<AudioSource>().Play();
                clipLength = item.clipLength;
            }
        }
        foreach (var item in firstClinicDialogue)
        {
            if (item.name == _targetName)
            {
                item.soundSource.GetComponent<AudioSource>().clip = item.clip;
                item.soundSource.GetComponent<AudioSource>().Play();
                clipLength = item.clipLength;
            }
        }
        foreach (var item in secondClinicDialogue)
        {
            if (item.name == _targetName)
            {
                item.soundSource.GetComponent<AudioSource>().clip = item.clip;
                item.soundSource.GetComponent<AudioSource>().Play();
                clipLength = item.clipLength;
            }
        }
        return clipLength;
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
