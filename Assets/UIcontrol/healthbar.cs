using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Image bloodBar; // 血条对象
    public float MaxHealth ; // 最大生命值
    public float CurrentHealth; // 当前生命值
    public GameObject tar;
    void Start()
    {
     tar = GameObject.Find("hero");
     MaxHealth = tar.GetComponent<heroInjured>().healthCnt;
    }
    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        
        CurrentHealth = tar.GetComponent<heroInjured>().healthCnt;

        float healthPercent = CurrentHealth / MaxHealth;
        bloodBar.fillAmount = healthPercent;
    }




}