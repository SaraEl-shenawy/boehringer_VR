using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickingEquipments : MonoBehaviour
{
    int counter = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FishingItems")
        {
            counter++;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            if (counter >= 3)
            {
                OnStartDockDialogue();
            }
        }
    }
    public void OnStartDockDialogue()
    {
        AudioManager.instance.Play("TimeToGo");
    }
}
