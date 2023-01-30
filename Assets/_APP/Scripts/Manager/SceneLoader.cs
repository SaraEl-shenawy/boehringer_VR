using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private void Update()
    {
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        LoadScene("SampleScene");

    //    }
    }
    public void LoadScene(string _scenName)
    {
        SceneManager.LoadScene(_scenName);
    }
}
