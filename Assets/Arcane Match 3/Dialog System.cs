using System;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{


    [Header("Active Dialogue Param :")]
    public float StartDeley = 5f;
    public GameObject DialogueGameObject;
    public Image CharacterImage;
    public Text DialogueText;

    [Header("Levels Data")]
    public int CurrentLevel = 0;
    public int CurrentLevel_Sentece = 0;
    public List<Level> Levels;
    bool FirstDialog = true;
    private void Start()
    {
        StartCoroutine(ActiveDialoge());
    }
    private void Update()
    {
        ShowDialogue();
    }

    private IEnumerator ActiveDialoge()
    {

        yield return new WaitForSeconds(StartDeley);
        DialogueGameObject.SetActive(true);
    }

    public void ShowDialogue()
    {
        if (FirstDialog)
        {
            FirstDialog = false;
            DialogueText.text = Levels[CurrentLevel].dialogue.Sentence[CurrentLevel_Sentece];
            CharacterImage.sprite = Levels[CurrentLevel].dialogue.CharacterImage;
        }
        if (DialogueGameObject.activeSelf == true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (CurrentLevel_Sentece < Levels[CurrentLevel].dialogue.Sentence.Length - 1)
                {
                    CurrentLevel_Sentece++;
                    DialogueText.text = Levels[CurrentLevel].dialogue.Sentence[CurrentLevel_Sentece];
                    CharacterImage.sprite = Levels[CurrentLevel].dialogue.CharacterImage;
                }
                else
                {
                    DialogueGameObject.SetActive(false);
                    CurrentLevel_Sentece = 0;
                }

            }
        }
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
    public Sprite CharacterImage;
    public string CharacterName;
    [TextArea(3, 10)]
    public string[] Sentence;
}



