 
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

    [SerializeField] GameObject DesPref;
   
    private void Awake()
    {

        instance = this;

    }
    private void Start()
    {
        

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        UIHandler.Instance.ChangeLevel(1);
    } 

    public void nextLevel()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level", 0) + 1);
       // SceneManager.LoadScene(PlayerPrefs.GetInt("Level",0),LoadSceneMode.Single);
        Instantiate(DesPref);

    }

}

    

