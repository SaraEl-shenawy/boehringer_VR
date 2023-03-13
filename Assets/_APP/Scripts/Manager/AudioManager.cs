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
    public Sound[] thirdClinicDialogue;
    public Sound[] kitchenDialogue;
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
        SetDialogueAudio();
        SetAudiosNPCType();
        SetNPCAnimationName();

        dialoguesDictionary = new Dictionary<int, Sound[]>()
        {
            { 0, sounds},
            { 1, singleAudios},
            { 2, dockDialogue},
            { 3, outdoorHouseDialogue},
            { 4, firstClinicDialogue},
            { 5, secondClinicDialogue},
            { 6, thirdClinicDialogue},
            { 7, kitchenDialogue},
            { 8, firstBasketballDialogue},
            { 9, secondBasketballDialogue}
        };
        SetDialogueAudioSettings(sounds.ToList());
        SetDialogueAudioSettings(singleAudios.ToList());
        SetDialogueAudioSettings(dockDialogue.ToList());
        SetDialogueAudioSettings(outdoorHouseDialogue.ToList());
        SetDialogueAudioSettings(firstClinicDialogue.ToList());
        SetDialogueAudioSettings(secondClinicDialogue.ToList());
        SetDialogueAudioSettings(thirdClinicDialogue.ToList());
        SetDialogueAudioSettings(kitchenDialogue.ToList());
        SetDialogueAudioSettings(firstBasketballDialogue.ToList());
        SetDialogueAudioSettings(secondBasketballDialogue.ToList());

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

    public float Play(string _targetName, int DialogueId)
    {
        var audioToPlay = dialoguesDictionary[DialogueId].ToList().FirstOrDefault(a => a.name == _targetName);
        audioToPlay.soundSource.GetComponent<AudioSource>().clip = audioToPlay.clip;
        audioToPlay.soundSource.GetComponent<AudioSource>().Play();
        clipLength = audioToPlay.clipLength;

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
            if (s.npcType == NPCTypeEnum.female)
            {
                s.soundSource = DialoguePlayer.instance.femaleCharacter;
            }
            else if (s.npcType == NPCTypeEnum.male)
            {
                s.soundSource = DialoguePlayer.instance.maleCharacter;
            }
            //else if (s.npcType == NPCTypeEnum.doctor)
            //{
            //    s.soundSource = DialoguePlayer.instance.doctorCharacter;
            //}
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
    private void SetDialogueAudio()
    { //ch 2
        if (dockDialogue.Length != 0)
        {
            dockDialogue[0].clip = ProfileSelection.instance.characterProfile.Talk_2_1.characterTalk;
            dockDialogue[1].clip = ProfileSelection.instance.characterProfile.Talk_2_2.characterTalk;
            dockDialogue[2].clip = ProfileSelection.instance.characterProfile.Talk_2_3.characterTalk;
        }
        //time to go

        if (outdoorHouseDialogue.Length != 0)
        {
            //Outdoor Beach Dialogue
            outdoorHouseDialogue[0].clip = ProfileSelection.instance.characterProfile.Talk_2_5.characterTalk;
            outdoorHouseDialogue[1].clip = ProfileSelection.instance.characterProfile.Talk_2_6.characterTalk;
            outdoorHouseDialogue[2].clip = ProfileSelection.instance.characterProfile.Talk_2_7.characterTalk;
        }
        if (singleAudios.Length != 0)
        {
            //ch 3
            singleAudios[0].clip = ProfileSelection.instance.characterProfile.Talk_2_4.characterTalk;
            singleAudios[1].clip = ProfileSelection.instance.characterProfile.Talk_3_1.characterTalk;
            singleAudios[2].clip = ProfileSelection.instance.characterProfile.Talk_3_2.characterTalk;
            singleAudios[3].clip = ProfileSelection.instance.characterProfile.Talk_3_3.characterTalk;
            singleAudios[4].clip = ProfileSelection.instance.characterProfile.Talk_3_4.characterTalk;
        }
        if (firstClinicDialogue.Length != 0)
        {
            //First Clinic
            firstClinicDialogue[0].clip = ProfileSelection.instance.characterProfile.Talk_4_0.characterTalk;
            firstClinicDialogue[1].clip = ProfileSelection.instance.characterProfile.Talk_4_1.characterTalk;
        }
        if (secondClinicDialogue.Length != 0)
        {
            //Second Clinic
            secondClinicDialogue[0].clip = ProfileSelection.instance.characterProfile.Talk_4_2.characterTalk;
            secondClinicDialogue[1].clip = ProfileSelection.instance.characterProfile.Talk_4_3.characterTalk;
        }
        if (thirdClinicDialogue.Length != 0)
        {
            //Second Clinic
            thirdClinicDialogue[0].clip = ProfileSelection.instance.characterProfile.Talk_4_4.characterTalk;
            thirdClinicDialogue[1].clip = ProfileSelection.instance.characterProfile.Talk_4_6.characterTalk;
            thirdClinicDialogue[2].clip = ProfileSelection.instance.characterProfile.Talk_4_7.characterTalk;
        }
        if (kitchenDialogue.Length != 0)
        {
            kitchenDialogue[0].clip = ProfileSelection.instance.characterProfile.Talk_5_1.characterTalk;
            kitchenDialogue[1].clip = ProfileSelection.instance.characterProfile.Talk_5_2.characterTalk;
            kitchenDialogue[2].clip = ProfileSelection.instance.characterProfile.Talk_5_3.characterTalk;
            kitchenDialogue[3].clip = ProfileSelection.instance.characterProfile.Talk_5_4.characterTalk;
        }
        if (firstBasketballDialogue.Length != 0)
        {
            //First Basketball
            firstBasketballDialogue[0].clip = ProfileSelection.instance.characterProfile.Talk_6_1.characterTalk;
            firstBasketballDialogue[1].clip = ProfileSelection.instance.characterProfile.Talk_6_2.characterTalk;
            firstBasketballDialogue[2].clip = ProfileSelection.instance.characterProfile.Talk_6_3.characterTalk;
        }
        if (secondBasketballDialogue.Length != 0)
        {
            //Second Basketball
            secondBasketballDialogue[0].clip = ProfileSelection.instance.characterProfile.Talk_6_4.characterTalk;
            secondBasketballDialogue[1].clip = ProfileSelection.instance.characterProfile.Talk_6_5.characterTalk;
            secondBasketballDialogue[2].clip = ProfileSelection.instance.characterProfile.Talk_6_6.characterTalk;
            secondBasketballDialogue[3].clip = ProfileSelection.instance.characterProfile.Talk_6_7.characterTalk;
            secondBasketballDialogue[4].clip = ProfileSelection.instance.characterProfile.Talk_6_8.characterTalk;
            secondBasketballDialogue[5].clip = ProfileSelection.instance.characterProfile.Talk_6_9.characterTalk;
            secondBasketballDialogue[6].clip = ProfileSelection.instance.characterProfile.Talk_6_10.characterTalk;
        }
    }
    private void SetAudiosNPCType()
    { //ch 2
        if (dockDialogue.Length != 0)
        {
            dockDialogue[0].npcType = ProfileSelection.instance.characterProfile.Talk_2_1.npcType;
            dockDialogue[1].npcType = ProfileSelection.instance.characterProfile.Talk_2_2.npcType;
            dockDialogue[2].npcType = ProfileSelection.instance.characterProfile.Talk_2_3.npcType;
        }
        if (outdoorHouseDialogue.Length != 0)
        {
            //Outdoor Beach Dialogue
            outdoorHouseDialogue[0].npcType = ProfileSelection.instance.characterProfile.Talk_2_5.npcType;
            outdoorHouseDialogue[1].npcType = ProfileSelection.instance.characterProfile.Talk_2_6.npcType;
            outdoorHouseDialogue[2].npcType = ProfileSelection.instance.characterProfile.Talk_2_7.npcType;
        }
        if (singleAudios.Length != 0)
        {
            //time to go    
            singleAudios[0].npcType = ProfileSelection.instance.characterProfile.Talk_2_4.npcType;
            singleAudios[1].npcType = ProfileSelection.instance.characterProfile.Talk_3_1.npcType;
            singleAudios[2].npcType = ProfileSelection.instance.characterProfile.Talk_3_2.npcType;
            singleAudios[3].npcType = ProfileSelection.instance.characterProfile.Talk_3_3.npcType;
            singleAudios[4].npcType = ProfileSelection.instance.characterProfile.Talk_3_4.npcType;
        }
        if (firstClinicDialogue.Length != 0)
        {
            //First Clinic
            firstClinicDialogue[0].npcType = ProfileSelection.instance.characterProfile.Talk_4_0.npcType;
            firstClinicDialogue[1].npcType = ProfileSelection.instance.characterProfile.Talk_4_1.npcType;
        }
        if (secondClinicDialogue.Length != 0)
        {
            //Second Clinic
            secondClinicDialogue[0].npcType = ProfileSelection.instance.characterProfile.Talk_4_2.npcType;
            secondClinicDialogue[1].npcType = ProfileSelection.instance.characterProfile.Talk_4_3.npcType;
        }
        if (thirdClinicDialogue.Length != 0)
        {
            //Second Clinic
            thirdClinicDialogue[0].npcType = ProfileSelection.instance.characterProfile.Talk_4_4.npcType;
            thirdClinicDialogue[1].npcType = ProfileSelection.instance.characterProfile.Talk_4_6.npcType;
            thirdClinicDialogue[2].npcType = ProfileSelection.instance.characterProfile.Talk_4_7.npcType;
        }
        if (kitchenDialogue.Length != 0)
        {
            kitchenDialogue[0].npcType = ProfileSelection.instance.characterProfile.Talk_5_1.npcType;
            kitchenDialogue[1].npcType = ProfileSelection.instance.characterProfile.Talk_5_2.npcType;
            kitchenDialogue[2].npcType = ProfileSelection.instance.characterProfile.Talk_5_3.npcType;
            kitchenDialogue[3].npcType = ProfileSelection.instance.characterProfile.Talk_5_4.npcType;
        }
        if (firstBasketballDialogue.Length != 0)
        {
            //First Basketball
            firstBasketballDialogue[0].npcType = ProfileSelection.instance.characterProfile.Talk_6_1.npcType;
            firstBasketballDialogue[1].npcType = ProfileSelection.instance.characterProfile.Talk_6_2.npcType;
            firstBasketballDialogue[2].npcType = ProfileSelection.instance.characterProfile.Talk_6_3.npcType;
        }
        if (secondBasketballDialogue.Length != 0)
        {
            //Second Basketball
            secondBasketballDialogue[0].npcType = ProfileSelection.instance.characterProfile.Talk_6_4.npcType;
            secondBasketballDialogue[1].npcType = ProfileSelection.instance.characterProfile.Talk_6_5.npcType;
            secondBasketballDialogue[2].npcType = ProfileSelection.instance.characterProfile.Talk_6_6.npcType;
            secondBasketballDialogue[3].npcType = ProfileSelection.instance.characterProfile.Talk_6_7.npcType;
            secondBasketballDialogue[4].npcType = ProfileSelection.instance.characterProfile.Talk_6_8.npcType;
            secondBasketballDialogue[5].npcType = ProfileSelection.instance.characterProfile.Talk_6_9.npcType;
            secondBasketballDialogue[6].npcType = ProfileSelection.instance.characterProfile.Talk_6_10.npcType;
        }
    }

    private void SetNPCAnimationName()
    { //ch 2
        if (dockDialogue.Length != 0)
        {
            dockDialogue[0].animationClipName = ProfileSelection.instance.characterProfile.Talk_2_1.animationClipName;
            dockDialogue[1].animationClipName = ProfileSelection.instance.characterProfile.Talk_2_2.animationClipName;
            dockDialogue[2].animationClipName = ProfileSelection.instance.characterProfile.Talk_2_3.animationClipName;
        }
        if (outdoorHouseDialogue.Length != 0)
        {
            //Outdoor Beach Dialogue
            outdoorHouseDialogue[0].animationClipName = ProfileSelection.instance.characterProfile.Talk_2_5.animationClipName;
            outdoorHouseDialogue[1].animationClipName = ProfileSelection.instance.characterProfile.Talk_2_6.animationClipName;
            outdoorHouseDialogue[2].animationClipName = ProfileSelection.instance.characterProfile.Talk_2_7.animationClipName;
        }
        if (singleAudios.Length != 0)
        {
            //time to go    
            singleAudios[0].animationClipName = ProfileSelection.instance.characterProfile.Talk_2_4.animationClipName;
            singleAudios[1].animationClipName = ProfileSelection.instance.characterProfile.Talk_3_1.animationClipName;
            singleAudios[2].animationClipName = ProfileSelection.instance.characterProfile.Talk_3_2.animationClipName;
            singleAudios[3].animationClipName = ProfileSelection.instance.characterProfile.Talk_3_3.animationClipName;
            singleAudios[4].animationClipName = ProfileSelection.instance.characterProfile.Talk_3_4.animationClipName;
        }
        if (firstClinicDialogue.Length != 0)
        {
            //First Clinic
            firstClinicDialogue[0].animationClipName = ProfileSelection.instance.characterProfile.Talk_4_0.animationClipName;
            firstClinicDialogue[1].animationClipName = ProfileSelection.instance.characterProfile.Talk_4_1.animationClipName;
        }
        if (secondClinicDialogue.Length != 0)
        {
            //Second Clinic
            secondClinicDialogue[0].animationClipName = ProfileSelection.instance.characterProfile.Talk_4_2.animationClipName;
            secondClinicDialogue[1].animationClipName = ProfileSelection.instance.characterProfile.Talk_4_3.animationClipName;
        }
        if (thirdClinicDialogue.Length != 0)
        {
            //Second Clinic
            thirdClinicDialogue[0].animationClipName = ProfileSelection.instance.characterProfile.Talk_4_4.animationClipName;
            thirdClinicDialogue[1].animationClipName = ProfileSelection.instance.characterProfile.Talk_4_6.animationClipName;
            thirdClinicDialogue[2].animationClipName = ProfileSelection.instance.characterProfile.Talk_4_7.animationClipName;
        }
        if (kitchenDialogue.Length != 0)
        {
            kitchenDialogue[0].animationClipName = ProfileSelection.instance.characterProfile.Talk_5_1.animationClipName;
            kitchenDialogue[1].animationClipName = ProfileSelection.instance.characterProfile.Talk_5_2.animationClipName;
            kitchenDialogue[2].animationClipName = ProfileSelection.instance.characterProfile.Talk_5_3.animationClipName;
            kitchenDialogue[3].animationClipName = ProfileSelection.instance.characterProfile.Talk_5_4.animationClipName;
        }
        if (firstBasketballDialogue.Length != 0)
        {
            //First Basketball
            firstBasketballDialogue[0].animationClipName = ProfileSelection.instance.characterProfile.Talk_6_1.animationClipName;
            firstBasketballDialogue[1].animationClipName = ProfileSelection.instance.characterProfile.Talk_6_2.animationClipName;
            firstBasketballDialogue[2].animationClipName = ProfileSelection.instance.characterProfile.Talk_6_3.animationClipName;
        }
        if (secondBasketballDialogue.Length != 0)
        {
            //Second Basketball
            secondBasketballDialogue[0].animationClipName = ProfileSelection.instance.characterProfile.Talk_6_4.animationClipName;
            secondBasketballDialogue[1].animationClipName = ProfileSelection.instance.characterProfile.Talk_6_5.animationClipName;
            secondBasketballDialogue[2].animationClipName = ProfileSelection.instance.characterProfile.Talk_6_6.animationClipName;
            secondBasketballDialogue[3].animationClipName = ProfileSelection.instance.characterProfile.Talk_6_7.animationClipName;
            secondBasketballDialogue[4].animationClipName = ProfileSelection.instance.characterProfile.Talk_6_8.animationClipName;
            secondBasketballDialogue[5].animationClipName = ProfileSelection.instance.characterProfile.Talk_6_9.animationClipName;
            secondBasketballDialogue[6].animationClipName = ProfileSelection.instance.characterProfile.Talk_6_10.animationClipName;
        }
    }

}
