using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button maleSelection;
    public Button femaleSelection;
    public Button firstYesButton;
    public Button secondYesButton;
    public GameObject firstYesButtonPanel;
    public GameObject secondYesButtonPanel;


    public ProfileSelectionSO profileSelection;

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
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Clinic")
        {
            firstYesButton.onClick.AddListener(OnPressFirstYes);
            secondYesButton.onClick.AddListener(OnPressSecondYes);
        }
        maleSelection.onClick.AddListener(MaleSelection);
        femaleSelection.onClick.AddListener(FemaleSelection);
    }

    void MaleSelection()
    {
        profileSelection.profileType = profileType.male;
    }
    void FemaleSelection()
    {
        profileSelection.profileType = profileType.female;
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
        firstYesButtonPanel.SetActive(false);
    }
    public void OnPressSecondYes()
    {
        secondYesButtonPanel.SetActive(false);
        StartCoroutine(DialoguePlayer.instance.PlayDialogueAudios(AudioManager.instance.secondClinicDialogue, null));

    }
}
