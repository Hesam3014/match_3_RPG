 
using System.Collections.Generic; 
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [Header("Enemys")]
    public List<Enemy> Enemys;
    public float PowerValue;

    [Header("Powers")]
    public List<Power> powers;

   
    private void Awake()
    {
        instance = this;
    }

}

    

