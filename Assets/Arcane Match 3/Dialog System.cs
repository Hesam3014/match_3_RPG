using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("Active Dialogue Parameters:")]
    public float StartDeley = 5f;
    public GameObject DialogueGameObject;
    public Image CharacterImage;
    public Text DialogueText;

    [Header("Levels Data")]
    public int CurrentLevel = 0;
    public int CurrentLevel_Sentence = 0;
    public List<Level> Levels;
    private bool FirstDialog = true;

    private void Start()
    {
        StartCoroutine(ActiveDialogue());
    }

    private void Update()
    {
        ShowDialogue();
    }

    private IEnumerator ActiveDialogue()
    {
        yield return new WaitForSeconds(StartDeley);
        DialogueGameObject.SetActive(true);
    }

    public void ShowDialogue()
    {
        if (FirstDialog)
        {
            FirstDialog = false;
            UpdateDialogueUI();
        }

        if (DialogueGameObject.activeSelf && Input.GetMouseButtonDown(0))
        {
            if (CurrentLevel_Sentence < Levels[CurrentLevel].dialogue.Sentences.Length - 1)
            {
                CurrentLevel_Sentence++;
                UpdateDialogueUI();
            }
            else
            {
                DialogueGameObject.SetActive(false);
                CurrentLevel_Sentence = 0;
            }
        }
    }

    private void UpdateDialogueUI()
    {
        DialogueText.text = Levels[CurrentLevel].dialogue.Sentences[CurrentLevel_Sentence];
        CharacterImage.sprite = Levels[CurrentLevel].dialogue.CharacterImages[CurrentLevel_Sentence];
    }
}

[Serializable]
public class Level
{
    public Dialogue dialogue;
}

[Serializable]
public class Dialogue
{
    public string CharacterName;
    [TextArea(3, 10)]
    public string[] Sentences;
    public Sprite[] CharacterImages;
}
