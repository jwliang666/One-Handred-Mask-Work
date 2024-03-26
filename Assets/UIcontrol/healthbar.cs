using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Image bloodBar; // 血条对象
    public float MaxHealth = 200f; // 最大生命值
    public float CurrentHealth ; // 当前生命值
    public  GameObject tar;
    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        tar = GameObject.Find("hero");
        CurrentHealth=tar.GetComponent<heroInjured>().healthCnt;
        float healthPercent = CurrentHealth / MaxHealth;
        bloodBar.fillAmount = healthPercent;
    }

   

    
}