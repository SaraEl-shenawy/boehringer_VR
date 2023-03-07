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

    //[Header("Character Data")]
    //public Mesh characterMesh;
    //public Animator animator;
    
    #endregion
}
