using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    //singleton
    public static GameManager instance;

    #endregion

    private void Awake()
    {
        if (instance && instance != this)
        {
            Destroy(this.gameObject);
        }
    }
}
