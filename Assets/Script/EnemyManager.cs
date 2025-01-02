using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public List<GameObject> EnemyBar ;
    public List<Transform> EnemyPos;

    [SerializeField] List<GameObject >VisualBomb;
    [SerializeField] GameObject VisualLight;
    private void Awake()
    {
        instance = this;
    }

    public void DamageEnemy(Vector3 CellPos)
    {
        for (int i = 0; i < EnemyBar.Count; i++)
        {
           EnemyBar[i].GetComponent<Slider>().value -= 10;
           

            int a = Random.Range(0, VisualBomb.Count);
           GameObject Go =  Instantiate(VisualBomb[a],EnemyPos[i].position,Quaternion.identity);

           
            GameObject Go2= Instantiate(VisualLight, CellPos, Quaternion.Euler(0,0, -177));

            Destroy(Go, 1f);
            Destroy(Go2, 1f);

            if (EnemyBar[i].GetComponent<Slider>().value <= 0)
            {
                // Destroy(EnemyPos[i].gameObject, 0.3f);
                // Destroy(EnemyBar[i], .2f);
                EnemyBar[i].SetActive(false);
                EnemyPos[i].GetComponent<SpriteRenderer>().enabled = false;
                EnemyBar.RemoveAt(i);
                EnemyPos.RemoveAt(i);
            }

            if(EnemyBar.Count <0)
            {
                //Game is win now
            }

        }
    }
}
