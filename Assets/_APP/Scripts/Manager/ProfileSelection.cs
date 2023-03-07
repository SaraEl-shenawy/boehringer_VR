using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType { male, female };

public class ProfileSelection : MonoBehaviour
{
    #region OldSettings
    //public ProfileSelectionSO profileSelection;

    //private void Start()
    //{
    //    if (profileSelection.profileType == profileType.male)
    //    {

    //    }
    //    else if (profileSelection.profileType == profileType.female)
    //    {

    //    }
    //}
    #endregion
    #region Variables
    public static ProfileSelection instance;
    //realtime
    public CharacterProfileSO characterProfile;
    #endregion

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(gameObject);
        }
        else if (!instance) 
        {
            instance = this;
        }
    }
}
