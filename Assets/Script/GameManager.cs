 
using System.Collections.Generic;
using Match3;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("Enemys")]
    public List<Enemy> Enemys;
    public float PowerValue;

    [Header("Powers")]
    public List<Power> powers;


    bool nextScene;
    private void Awake()
    {

        instance = this;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            UIHandler.Instance.SelectPower(3);
        }
    }

    public void nextLevel()
    {
        if (!nextScene)
        {
            // next scene
            Invoke("Do", 1f);
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
            nextScene = true;
        }
       
       

    }
    void Do()
    {
        UIHandler.Instance.ChangeLevel(PlayerPrefs.GetInt("Level", 0));
    }
}

    

