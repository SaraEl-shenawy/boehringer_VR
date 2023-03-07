using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class TrashBin : MonoBehaviour
{
    int counter = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fruits")
        {
            counter++;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            if (counter >= 5)
            {
                AudioManager.instance.Play("fingers feel numb", AudioManager.instance.sounds);
            }
        }
    }
}
