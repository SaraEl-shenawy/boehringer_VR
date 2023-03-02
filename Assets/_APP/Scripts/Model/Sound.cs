using UnityEngine.Audio;
using UnityEngine;
using System;

public enum NPCTypeEnum { male, female, doctor };//Male->0, Female->1, Doctor->2

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
    // enum
    public NPCTypeEnum npcType;
    
    public string animationClipName;
    public GameObject soundSource;

    [HideInInspector]
    public AudioSource source;
}
