using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum profileType { male, female };
[CreateAssetMenu(fileName = "ProfileData", menuName = "ScriptableObjects/ProfileData", order = 1)]
public class ProfileSelectionSO : ScriptableObject
{
    public profileType profileType;

}
