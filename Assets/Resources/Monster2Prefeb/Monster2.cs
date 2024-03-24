using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour
{
    public int mon2xueliang = 5;
    public GameObject bombPrefab; // 需要在Unity编辑器中指定的炸弹预制体
    //public GameObject hero; // 目标对象（比如英雄）
    public float launchInterval = 1f; // 发射间隔时间
    public float speed = 10f; // 炸弹的速度
    public Vector3 targetPosition;
    private GameObject hero;
    private float timer = 0f;
    void Start()
    {
        hero = GameObject.Find("hero");
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
    public void xueliangjian()
    {
        if (mon2xueliang > 0)
            mon2xueliang--;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string thisTag = gameObject.tag; // 获取当前游戏对象的标签
        string otherTag = collision.gameObject.tag; // 获取碰撞对象的标签

        Debug.Log("Collision between tag: " + thisTag + " and " + otherTag);

        // 检测两个刚体的标签
        if (otherTag == "attack" || otherTag == "playBullet")
        {
            xueliangjian();
            if (mon2xueliang <= 0)
                Destroy(gameObject);
            // 执行对应操作
            Debug.Log("Collision between Tag1 and Tag2");
        }
        else if (thisTag == "Tag2" && otherTag == "Tag1")
        {
            // 执行对应操作
            Debug.Log("Collision between Tag2 and Tag1");
        }
    }
}