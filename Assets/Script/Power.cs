using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public float PowerActive;
    public int DamageValue;
    public bool EveryEnemy;
    public int Health, MaxHealth;

    public Slider PowerSlider, HealthSlider;
    public Button Btn;

    [Header("Revive")]
    public Slider ReviveSlider;
    public bool Revive;
    public float timer;

    private void Start()
    {
        PowerSlider.maxValue = PowerActive;
        Health = MaxHealth;
        HealthSlider.maxValue = Health;

        GameManager.instance.powers.Add(this);
    }

    private void Update()
    {
        if (Revive)
        {
            timer -= Time.deltaTime;
            ReviveSlider.value = timer;
            if(timer <= 0)
            {
                ReviveSlider.value = 0;
                Btn.interactable = true;

                Health = MaxHealth;
                HealthSlider.value = 0;

                GameManager.instance.powers.Add(this);

                Revive = false;
            }

            return;
        }

        if(PowerActive <= GameManager.instance.PowerValue)
        {
            Btn.interactable = true;
        }
        else
        {
            Btn.interactable = false;
        }

        PowerSlider.value = GameManager.instance.PowerValue;
    }

    public void OnPowerUsing()
    {
        List<Enemy> Enemys = GameManager.instance.Enemys;

        GameManager.instance.PowerValue -= PowerActive;

        if (EveryEnemy)
        {
            for(int i = 0; i < Enemys.Count; i++)
            {
                Enemys[i].Damage(DamageValue);
            }
        }
        else
        {
            Enemys[0].Damage(DamageValue);
        }
    }

    public void Damage(int DamageValue)
    {
        Health -= DamageValue;

        HealthSlider.value += DamageValue;

        if (Health <= 0)
        {
            Revive = true;
            Btn.interactable = false;
            ReviveSlider.maxValue = 20;
            ReviveSlider.value = 20;
            timer = PowerSlider.maxValue;

            GameManager.instance.powers.Remove(this);
        }
    }
}
