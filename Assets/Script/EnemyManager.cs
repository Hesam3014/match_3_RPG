using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


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
    [SerializeField] private List<AudioClip> VoisCharacterClip;
    [SerializeField] private bool PlayVois;

    [Header("Visual_Enemy")]
    [SerializeField] private List<GameObject> Visual_Enemy;
    [SerializeField] public List<Vector3> EnemySiza;
    [SerializeField] public bool Boss;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (!Boss)
        {
            for (int i = 0; i < EnemyBar.Count; i++)
            {
                EnemySiza[i] = Visual_Enemy[i].transform.localScale;
            }
        }
    }

    public void DamageEnemy(Vector3 CellPos, string GemType)
    {
 
        if (!BossFight)
        {
            for (int i = 0; i < EnemyBar.Count; i++)
            {


                EnemyBar[i].GetComponent<Slider>().value -= 10;
                // Visual_Enemy[i].gameObject.transform.DOPunchScale(new Vector3(Visual_Enemy[i].transform.position.x + 0.001f, Visual_Enemy[i].transform.position.y + 0.001f), 0.3f);
                ShackingEnemy(Visual_Enemy[i], i);


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

                if (!PlayVois)
                {
                    SoundManager.instance.PlaySound(VoisCharacterClip[Random.Range(0, VoisCharacterClip.Count)], 0.7f);
                    PlayVois = true;
                    Invoke("Interruption", 2);
                }

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

                   // ShackingEnemy(Visual_Enemy[1], 1);

                    // PlaySound 
                    SoundManager.instance.PlaySound(DamageEnemyClip[randomEffect], 0.7f);
                    if (!PlayVois)
                    {
                        SoundManager.instance.PlaySound(VoisCharacterClip[Random.Range(0, VoisCharacterClip.Count)], 0.7f);
                        PlayVois = true;
                        Invoke("Interruption", 2);
                    }


                }

            }
            else 
            {
                // Damage Enemy
                EnemyBar[1].gameObject.SetActive(false);
                EnemyBar[0].GetComponent<Slider>().value -= 10;

                ShackingEnemy(Visual_Enemy[0], 0);

                int a = Random.Range(0, VisualBomb.Count);
                GameObject Go = Instantiate(VisualBomb[a], EnemyPos[0].position, Quaternion.identity);

                randomEffect = Random.Range(0, VisualLight.Count);
                GameObject Go2 = Instantiate(VisualLight[randomEffect], CellPos, Quaternion.Euler(0, 0, -177));

                Destroy(Go, 1f);
                Destroy(Go2, 1f);

                // PlaySound 
                SoundManager.instance.PlaySound(DamageEnemyClip[randomEffect], 0.7f);
                if (!PlayVois)
                {
                    SoundManager.instance.PlaySound(VoisCharacterClip[Random.Range(0, VoisCharacterClip.Count)], 0.7f);
                    PlayVois = true;
                    Invoke("Interruption", 2);
                }


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

    private void ShackingEnemy(GameObject Enemy, int Count)
    {
        const float duration = 0.3f;
        const float strength = 0.3f;

        Enemy.transform.DOKill();

        Enemy.transform.DOShakeScale(duration, strength).OnComplete(() =>
        {
            Enemy.transform.localScale = EnemySiza[Count];   
        });
    }

    public void Interruption()
    {
        PlayVois = false;
    }
}
