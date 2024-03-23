using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncher : MonoBehaviour
{
    public GameObject bombPrefab; // 需要在Unity编辑器中指定的炸弹预制体
    public GameObject hero; // 目标对象（比如英雄）
    public float launchInterval = 1f; // 发射间隔时间
    public float speed = 10f; // 炸弹的速度
    public Vector3 targetPosition;

    private float timer = 0f;
    void Start()
    {
        Debug.Assert(hero != null);
    }

    void Update()
    {
        timer += Time.deltaTime;
        targetPosition = hero.transform.position;

        if (timer >= launchInterval)
        {
            LaunchBomb();
            timer = 0f;
        }
    }

    void LaunchBomb()
    {
        if (hero == null)
        {
            Debug.LogWarning("No hero specified for bomb launcher.");
            return;
        }

        // 获取当前 hero 的位置
    
        Debug.Log(targetPosition);
        // 计算炸弹的方向
        Vector3 direction = (targetPosition - transform.position).normalized;

        // 实例化炸弹并设置位置
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);

        // 获取炸弹上的 bombbehavior 组件，并设置速度和方向
        bombbehavior bombBehavior = bomb.GetComponent<bombbehavior>();
        if (bombBehavior != null)
        {
            bombBehavior.SetDirection(direction * speed);
        }
        else
        {
            Debug.LogWarning("Bomb prefab is missing bombbehavior component.");
        }
    }
}
