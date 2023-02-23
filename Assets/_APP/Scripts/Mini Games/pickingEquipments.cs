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
            }
        }
        if (other.gameObject.tag == "Fruits")
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            AudioManager.instance.Play("My Fingers");
            // vest vibrate off

        }
    }
    public void OnStartDockDialogue()
    {
        AudioManager.instance.Play("TimeToGo");
        DialoguePlayer.instance.userObject.GetComponent<ContinuousMoveProviderBase>().enabled = true;
        DialoguePlayer.instance.backPack.SetActive(false);
    }
}
