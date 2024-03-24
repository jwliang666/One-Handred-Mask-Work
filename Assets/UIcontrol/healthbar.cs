using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Image bloodBar; // 血条对象
    public float MaxHealth = 100f; // 最大生命值
    public float CurrentHealth = 50f; // 当前生命值

    void Start()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float healthPercent = CurrentHealth / MaxHealth;
        bloodBar.fillAmount = healthPercent;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Max(CurrentHealth, 0f); // 生命值不会小于0
        UpdateHealthBar();
    }

    public void Heal(float healAmount)
    {
        CurrentHealth += healAmount;
        CurrentHealth = Mathf.Min(CurrentHealth, MaxHealth); // 生命值不会超过最大生命值
        UpdateHealthBar();
    }
}
