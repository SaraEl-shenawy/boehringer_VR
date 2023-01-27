using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSequence : MonoBehaviour
{
    public List<GameObject> panels;
    public void ActivateNextPanel(int _index = 0)
    {
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(false);
        }
        panels[_index].SetActive(true);
        _index++;
    }
}
