using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] singleAudios;

    public Sound[] dockDialogue;
    public Sound[] outdoorHouseDialogue;
    public Sound[] firstClinicDialogue;
    public Sound[] secondClinicDialogue;
    public Sound[] firstBasketballDialogue;
    public Sound[] secondBasketballDialogue;

    Dictionary<int, Sound[]> dialoguesDictionary = new Dictionary<int, Sound[]>();

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
        dialoguesDictionary = new Dictionary<int, Sound[]>()
        {
            { 0, sounds},
            { 1, singleAudios},
            { 2, dockDialogue},
            { 3, outdoorHouseDialogue},
            { 4, firstClinicDialogue},
            { 5, secondClinicDialogue},
            { 6, firstBasketballDialogue},
            { 7, secondBasketballDialogue}
        };
        SetDialogueAudioSettings(sounds.ToList());
        SetDialogueAudioSettings(singleAudios.ToList());
        SetDialogueAudioSettings(dockDialogue.ToList());
        SetDialogueAudioSettings(outdoorHouseDialogue.ToList());
        SetDialogueAudioSettings(firstClinicDialogue.ToList());
        SetDialogueAudioSettings(secondClinicDialogue.ToList());
        SetDialogueAudioSettings(firstBasketballDialogue.ToList());
        SetDialogueAudioSettings(secondBasketballDialogue.ToList());

        SetDialogueAudio();
        #region oldSetSettings
        //DontDestroyOnLoad(this.gameObject);
        //foreach (Sound s in sounds)
        //{
        //    if (s.soundSource.GetComponent<AudioSource>() == null)
        //    {
        //        s.source = s.soundSource.AddComponent<AudioSource>();
        //        s.source.spatialBlend = 1f;
        //        s.source.clip = s.clip;

        //        s.source.volume = s.volume;
        //        s.source.pitch = s.pitch;
        //        s.source.loop = s.loop;
        //        s.clipLength = s.clip.length;
        //    }
        //}
        //foreach (Sound s in dockDialogue)
        //{
        //    if (s.soundSource.GetComponent<AudioSource>() == null)
        //    {
        //        s.source = s.soundSource.AddComponent<AudioSource>();
        //        s.source.spatialBlend = 1f;
        //        s.source.clip = s.clip;

        //        s.source.volume = s.volume;
        //        s.source.pitch = s.pitch;
        //        s.source.loop = s.loop;
        //    }
        //}
        //foreach (Sound s in outdoorHouseDialogue)
        //{
        //    if (s.soundSource.GetComponent<AudioSource>() == null)
        //    {
        //        s.source = s.soundSource.AddComponent<AudioSource>();
        //        s.source.spatialBlend = 1f;
        //        s.source.clip = s.clip;

        //        s.source.volume = s.volume;
        //        s.source.pitch = s.pitch;
        //        s.source.loop = s.loop;
        //    }
        //}
        //foreach (Sound s in firstClinicDialogue)
        //{
        //    if (s.soundSource.GetComponent<AudioSource>() == null)
        //    {
        //        s.source = s.soundSource.AddComponent<AudioSource>();
        //        s.source.spatialBlend = 1f;
        //        s.source.clip = s.clip;

        //        s.source.volume = s.volume;
        //        s.source.pitch = s.pitch;
        //        s.source.loop = s.loop;
        //    }
        //}
        //foreach (Sound s in secondClinicDialogue)
        //{
        //    if (s.soundSource.GetComponent<AudioSource>() == null)
        //    {
        //        s.source = s.soundSource.AddComponent<AudioSource>();
        //        s.source.spatialBlend = 1f;
        //        s.source.clip = s.clip;

        //        s.source.volume = s.volume;
        //        s.source.pitch = s.pitch;
        //        s.source.loop = s.loop;
        //    }
        //}
        //foreach (Sound s in firstBasketballDialogue)
        //{
        //    if (s.soundSource.GetComponent<AudioSource>() == null)
        //    {
        //        s.source = s.soundSource.AddComponent<AudioSource>();
        //        s.source.spatialBlend = 1f;
        //        s.source.clip = s.clip;

        //        s.source.volume = s.volume;
        //        s.source.pitch = s.pitch;
        //        s.source.loop = s.loop;
        //    }
        //}
        #endregion
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
        #region OldSettings
        //foreach (var item in sounds)
        //{
        //    if (item.name == _targetName)
        //    {
        //        item.soundSource.GetComponent<AudioSource>().clip = item.clip;
        //        item.soundSource.GetComponent<AudioSource>().Play();
        //        clipLength = item.clipLength;
        //    }
        //}
        //foreach (var item in dockDialogue)
        //{
        //    if (item.name == _targetName)
        //    {
        //        item.soundSource.GetComponent<AudioSource>().clip = item.clip;
        //        item.soundSource.GetComponent<AudioSource>().Play();
        //        clipLength = item.clipLength;
        //    }
        //}
        //foreach (var item in outdoorHouseDialogue)
        //{
        //    if (item.name == _targetName)
        //    {
        //        item.soundSource.GetComponent<AudioSource>().clip = item.clip;
        //        item.soundSource.GetComponent<AudioSource>().Play();
        //        clipLength = item.clipLength;
        //    }
        //}
        //foreach (var item in firstClinicDialogue)
        //{
        //    if (item.name == _targetName)
        //    {
        //        item.soundSource.GetComponent<AudioSource>().clip = item.clip;
        //        item.soundSource.GetComponent<AudioSource>().Play();
        //        clipLength = item.clipLength;
        //    }
        //}
        //foreach (var item in secondClinicDialogue)
        //{
        //    if (item.name == _targetName)
        //    {
        //        item.soundSource.GetComponent<AudioSource>().clip = item.clip;
        //        item.soundSource.GetComponent<AudioSource>().Play();
        //        clipLength = item.clipLength;
        //    }
        //}
        #endregion
        return clipLength;
    }
    public float Play(string _targetName, int DialogueId)
    {
        //foreach (var item in _audioArray)
        //{
        //    if (item.name == _targetName)
        //    {
        //        item.soundSource.GetComponent<AudioSource>().clip = item.clip;
        //        item.soundSource.GetComponent<AudioSource>().Play();
        //        clipLength = item.clipLength;
        //    }
        //}
        var audioToPlay = dialoguesDictionary[DialogueId].ToList().FirstOrDefault(a => a.name == _targetName);
        audioToPlay.soundSource.GetComponent<AudioSource>().Play();

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
    private void SetDialogueAudioSettings(List<Sound> sounds)
    {
        foreach (Sound s in sounds)
        {
            if (s.source == null)
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
    private void SetDialogueAudio()
    {
        dockDialogue[0].clip = ProfileSelection.instance.characterProfile.Talk_2_1;
        dockDialogue[1].clip = ProfileSelection.instance.characterProfile.Talk_2_2;
        dockDialogue[2].clip = ProfileSelection.instance.characterProfile.Talk_2_3;
        //time to go
        singleAudios[0].clip = ProfileSelection.instance.characterProfile.Talk_2_4;
        singleAudios[1].clip = ProfileSelection.instance.characterProfile.Talk_3_1;
        singleAudios[2].clip = ProfileSelection.instance.characterProfile.Talk_3_2;
        singleAudios[3].clip = ProfileSelection.instance.characterProfile.Talk_3_3;
        singleAudios[4].clip = ProfileSelection.instance.characterProfile.Talk_3_4;
        singleAudios[5].clip = ProfileSelection.instance.characterProfile.Talk_4_1;
    }
}
