using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button firstYesButton;
    public Button secondYesButton;
    public GameObject firstYesButtonPanel;
    public GameObject secondYesButtonPanel;


    public static UIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        firstYesButton.onClick.AddListener(OnPressFirstYes);
        secondYesButton.onClick.AddListener(OnPressSecondYes);
    }
    public void ActivateFirstYesPanel()
    {
        firstYesButtonPanel.SetActive(true);
    }
    public void ActivateSecondYesPanel()
    {
        secondYesButtonPanel.SetActive(true);
    }

    public void OnPressFirstYes()
    {
        StartCoroutine(DialoguePlayer.instance.PlayDialogueAudios(AudioManager.instance.firstClinicDialogue, ActivateSecondYesPanel));
    }
    public void OnPressSecondYes()
    {
        secondYesButtonPanel.SetActive(false);
        StartCoroutine(DialoguePlayer.instance.PlayDialogueAudios(AudioManager.instance.secondClinicDialogue, null));

    }
}
