using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Stuff")]
    public DialogueSO dialogueToShow;
    public int currentText;
    public bool isTalking;
    [Header("UI")] 
    public GameObject dialogueUI;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image portrait;

    public void Start()
    {
        StartDialogue(dialogueToShow);
    }

    public void StartDialogue(DialogueSO newDialogue)
    {
        dialogueUI.SetActive(true);
        gameObject.SetActive(true);
        isTalking = true;
        currentText = 0;
        dialogueToShow = newDialogue;
        nameText.text = dialogueToShow.dialogueList[currentText].character.name;
        portrait.sprite = dialogueToShow.dialogueList[currentText].character.portrait;
        dialogueText.text = dialogueToShow.dialogueList[currentText].text;
    }
    public void ContinueDialogue()
    {
        currentText++;
        if (currentText == dialogueToShow.dialogueList[currentText].text.Length)
        {
            EndDialogue();
            return;
        }
        nameText.text = dialogueToShow.dialogueList[currentText].character.name;
        portrait.sprite = dialogueToShow.dialogueList[currentText].character.portrait;
        dialogueText.text = dialogueToShow.dialogueList[currentText].text; //basic functionality, no options for choices or actions or anything.
    }

    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isTalking)
        {
            //set actions to disable here
            if (Input.GetMouseButtonDown(0))
            {
                ContinueDialogue();
            }
        }
    }
}
