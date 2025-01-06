 
using System.Collections.Generic;
using Match3;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Match3.Board;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("Enemys")]
    public List<Enemy> Enemys;
    public float PowerValue;

    [Header("Powers")]
    public List<Power> powers;
    public List<Button> PowersBtn;
    public int Value;

    bool nextScene;
    private void Awake()
    {

        instance = this;

    }

    private void Update()
    {
        if (Value >= 3)
        {
            PowersBtn[Random.Range(0, 4)].interactable = true;
            Value = 0;
        }
    }

    public void Power1()
    {
        UIHandler.Instance.SelectPower(0);
        PowersBtn[0].interactable = false;
    }

    public void Power2()
    {
        UIHandler.Instance.SelectPower(1);
        PowersBtn[1].interactable = false;
    }

    public void Power3()
    {
        UIHandler.Instance.SelectPower(2);
        PowersBtn[2].interactable = false;
    }

    public void Power4()
    {
        UIHandler.Instance.SelectPower(3);
        PowersBtn[3].interactable = false;
    }

    public void nextLevel()
    {
        if (!nextScene)
        {
            // next scene
            Invoke("Do", 6f);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);


            UIHandler.Instance.turnOnVfx();

            nextScene = true;
        }
       
       

    }
    void Do()
    {
        UIHandler.Instance.ChangeLevel(PlayerPrefs.GetInt("Level", 0));
    }
}

    

