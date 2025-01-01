using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    public int DamageValue;

    private void Start()
    {
         gameObject.transform.DOJump(new Vector3(gameObject.transform.position.x + Random.Range(-0.2f, 0.2f), gameObject.transform.position.y + Random.Range(-0.4f, -0.2f)), 0.7f, 0, 0.5f).OnComplete(() =>
         {
            gameObject.transform.DOMoveY(7, 2f).SetEase(Ease.OutQuint);
         });


    }

    private void OnTriggerEnter2D(Collider2D Taregt)
    {
        if (Taregt.CompareTag("Enemy"))
        {
            Taregt.GetComponent<Enemy>().Damage(DamageValue);
            Destroy(gameObject);
        }
    }
}
