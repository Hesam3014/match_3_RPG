using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public List<GameObject> EnemyBar;
    public List<Transform> EnemyPos;
    [SerializeField] List<GameObject >VisualBomb;
    [SerializeField] List<GameObject> VisualLight;
    int randomEffect;

    [SerializeField] private bool BossFight;
    [Header("Sounds")]
    [SerializeField] private List<AudioClip> DamageEnemyClip;
    [SerializeField] private List<AudioClip> DamageCharacterClip;

    private void Awake()
    {
        instance = this;
    }

    public void DamageEnemy(Vector3 CellPos, string GemType)
    {
 
        if (!BossFight)
        {
            for (int i = 0; i < EnemyBar.Count; i++)
            {


                EnemyBar[i].GetComponent<Slider>().value -= 10;


                // effect Damage
                int a = Random.Range(0, VisualBomb.Count);
                GameObject Go = Instantiate(VisualBomb[a], EnemyPos[i].position, Quaternion.identity);

                randomEffect = Random.Range(0, VisualLight.Count);
                GameObject Go2 = Instantiate(VisualLight[randomEffect], CellPos, Quaternion.Euler(0, 0, -177));

                Destroy(Go, 1f);
                Destroy(Go2, 1f);

                //Enemy Dead
                if (EnemyBar[i].GetComponent<Slider>().value <= 0)
                {
                    // Destroy(EnemyPos[i].gameObject, 0.3f);
                    // Destroy(EnemyBar[i], .2f);
                    EnemyBar[i].SetActive(false);
                    EnemyPos[i].GetComponent<SpriteRenderer>().enabled = false;
                    EnemyBar.RemoveAt(i);
                    EnemyPos.RemoveAt(i);
                }

                // Game Is WIn!
                if (EnemyBar.Count <= 0)
                {
                    GameManager.instance.nextLevel();
                }
                // PlaySound 
                SoundManager.instance.PlaySound(DamageEnemyClip[randomEffect], 0.7f);

            }
        }
        else
        {

            if (EnemyBar[1].GetComponent<Slider>().value > 0 )
            {
                //Damage Sheild 
                if(GemType == "ARC_Gem2(Clone) (Match3.Gem)")
                {
                    // effect Damage
                    int a = Random.Range(0, VisualBomb.Count);
                    GameObject Go = Instantiate(VisualBomb[a], EnemyPos[0].position, Quaternion.identity);

                    randomEffect = Random.Range(0, VisualLight.Count);
                    GameObject Go2 = Instantiate(VisualLight[randomEffect], CellPos, Quaternion.Euler(0, 0, -177));

                    Destroy(Go, 1f);
                    Destroy(Go2, 1f);
                    EnemyBar[1].GetComponent<Slider>().value -= 10;

                    // PlaySound 
                    SoundManager.instance.PlaySound(DamageEnemyClip[randomEffect], 0.7f);

                }

            }
            else 
            {
                // Damage Enemy
                EnemyBar[1].gameObject.SetActive(false);
                EnemyBar[0].GetComponent<Slider>().value -= 10;

                int a = Random.Range(0, VisualBomb.Count);
                GameObject Go = Instantiate(VisualBomb[a], EnemyPos[0].position, Quaternion.identity);

                randomEffect = Random.Range(0, VisualLight.Count);
                GameObject Go2 = Instantiate(VisualLight[randomEffect], CellPos, Quaternion.Euler(0, 0, -177));

                Destroy(Go, 1f);
                Destroy(Go2, 1f);

                // PlaySound 
                SoundManager.instance.PlaySound(DamageEnemyClip[randomEffect], 0.7f);

                // win the game
                if (EnemyBar[0].GetComponent<Slider>().value <=0)
                    GameManager.instance.nextLevel();


            }
        }
    }

    public void PowerValue()
    {
        GameManager.instance.Value += 1;
    }
}
