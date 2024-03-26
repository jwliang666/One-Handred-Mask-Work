using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bluebar : MonoBehaviour
{
    public Image blueBar; // 血条对象
    public float MaxHealth ; // 最大生命值
    public float CurrentHealth; // 当前生命值
    public GameObject tar;
    void Start()
    {
     tar = GameObject.Find("hero");
     MaxHealth = tar.GetComponent<PlayerMove>().UIsprintBar;
    }
    void Update()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        
        CurrentHealth = tar.GetComponent<PlayerMove>().UIsprintBar;

        float healthPercent = CurrentHealth / MaxHealth;
        blueBar.fillAmount = healthPercent;
    }
}
