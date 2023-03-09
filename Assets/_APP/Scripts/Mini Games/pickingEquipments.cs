using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

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
                this.GetComponentInChildren<Animator>().enabled = true;
            }
        }
        if (other.gameObject.tag == "Fruits")
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            AudioManager.instance.Play("fingers feel numb", 1);
            // vest vibrate off

        }
    }
    public void OnStartDockDialogue()
    {
        AudioManager.instance.Play("TimeToGo", 1);
        DialoguePlayer.instance.userObject.GetComponent<ContinuousMoveProviderBase>().enabled = true;
    }
}

