using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterProfile", menuName = "ScriptableObjects/CharacterProfile", order = 3)]
public class CharacterProfileSO : ScriptableObject
{
    #region SeaSideDialogue
    [Header("CharaterType")]
    public CharacterType characterType;
    [Header("Dock Dialogue")]
    public AudioClip Talk_2_1;
    public AudioClip Talk_2_2;
    public AudioClip Talk_2_3;
    [Header("Time To Go Audio")]
    public AudioClip Talk_2_4;
    [Header("Outdoor Beach Dialogue")]
    public AudioClip Talk_2_5;
    public AudioClip Talk_2_6;
    public AudioClip Talk_2_7;
    [Header("So Tired Audio")]
    public AudioClip Talk_3_1;
    [Header("The kitchen is so filthy Audio")]
    public AudioClip Talk_3_2;
    [Header("My fingers feel numb Audio")]
    public AudioClip Talk_3_3;
    [Header("I Feel Down Audio")]
    public AudioClip Talk_3_4;
    [Header("Shortness OF Breath Doctor Audio")]
    public AudioClip Talk_4_1;
    [Header("First Clinic Dialogue")]
    public AudioClip Talk_4_2;
    public AudioClip Talk_4_3;
    [Header("Second Clinic Dialogue")]
    public AudioClip Talk_4_4;
    public AudioClip Talk_4_6;
    public AudioClip Talk_4_7;
    [Header("House Kitchen Dialogue")]
    public AudioClip Talk_5_1;
    public AudioClip Talk_5_2;
    public AudioClip Talk_5_3;
    public AudioClip Talk_5_4;
    [Header("First Basketball Dialogue")]
    public AudioClip Talk_6_1;
    public AudioClip Talk_6_2;
    public AudioClip Talk_6_3;
    [Header("Second Basketball Dialogue")]
    public AudioClip Talk_6_4;
    public AudioClip Talk_6_5;
    public AudioClip Talk_6_6;
    public AudioClip Talk_6_7;
    public AudioClip Talk_6_8;
    public AudioClip Talk_6_9;
    public AudioClip Talk_6_10;

    //[Header("Character Data")]
    //public Mesh characterMesh;
    //public Animator animator;

    #endregion
}
