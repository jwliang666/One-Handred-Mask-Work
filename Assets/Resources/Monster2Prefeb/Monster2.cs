using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonoBehaviour
{
    public int mon2xueliang = 8;
    public GameObject bombPrefab; // 需要在Unity编辑器中指定的炸弹预制体
    //public GameObject hero; // 目标对象（比如英雄）
    public float launchInterval = 1f; // 发射间隔时间
    public float speed = 10f; // 炸弹的速度
    public Vector3 targetPosition;
    private GameObject hero;
    private float timer = 0f;

    //跟随范围
    public float MyChasingRange = 20f;
    void Start()
    {
        hero = GameObject.Find("hero");
    }

    void Update()
    {
        timer += Time.deltaTime;
        targetPosition = hero.transform.position;
        float mydistance = Vector3.Distance(targetPosition, transform.position);
        Debug.Log(mydistance);
        if (timer >= launchInterval && mydistance <= MyChasingRange)
        {
            LaunchBomb();
            timer = 0f;
        }

        if (mon2xueliang <= 0)
        {
            cntjian();
            Vector3 BOMBp = transform.position;
            Quaternion qq = Quaternion.Euler(0, 0, 0);
            Instantiate(Resources.Load("Prefabs/smallMonsterDead") as GameObject, BOMBp, qq);
            Destroy(gameObject);
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


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("pengpengpenpgnepng");
        if (other.gameObject.tag == "attack")
        {
            mon2xueliang -= 4;
        }
        else if (other.gameObject.tag == "playerBullet")
        {
            mon2xueliang -= 1;
        }
    }

    private void cntjian()
    {
        monsterCnt a = GetComponent<monsterCnt>();
        if (a != null)
        {
            a.moncntjian();
        }
    }
}