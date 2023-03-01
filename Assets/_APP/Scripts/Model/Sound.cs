using UnityEngine.Audio;
using UnityEngine;
using System;

[Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;
    [Range(0.1f,3.0f)]
    public float pitch;
    public float clipLength;

    public bool loop;
    public bool isMale;
    public bool isFemale;
    public bool isDoctor;
    public string animationClipName;
    public GameObject soundSource;

    [HideInInspector]
    public AudioSource source;
}
