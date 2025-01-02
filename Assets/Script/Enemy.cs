using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("HealthEnemy")]
    public int Health;
    public Slider slider;

    [Header("Attack")]
    public int DamageValue;
    private float Attacking;
    public int AttackActive;
    public Slider AttackSlider;

    private void Start()
    {
        GameManager.instance.Enemys.Add(this);
        slider.maxValue = Health;
        /*
        // Attack 
        AttackSlider.maxValue = AttackActive;*/
    }

    public void Damage(int DamageValue)
    {
        Health -= DamageValue;
        slider.value += DamageValue;

        if (Health <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.Enemys.Remove(this);
        }
        /*
        // Attack
        Attacking += DamageValue;
        AttackSlider.value = Attacking;
        
        if (Attacking >= AttackActive)
        {
            Attacking -= AttackActive;
            AttackSlider.value = Attacking;
            Attack();
        }*/
    }

    public void Attack()
    {
        Power power = GameManager.instance.powers[Random.Range(0, GameManager.instance.powers.Count)];
        power.Damage(DamageValue);
    }
}
