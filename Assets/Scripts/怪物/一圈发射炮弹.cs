using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : MonoBehaviour
{
    public int mon3xueliang = 10;
    private float spawnTimer = 0f;
    private float spawnInterval = 1f;
    float spawnRadius = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        // 当计时器大于等于生成间隔时生成蛋并重置计时器
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;

            // 设置要生成蛋的数量
            int eggCount = 8; // 这里假设生成8个蛋，你可以根据需要调整数量

            // 计算每个蛋之间的角度间隔
            float angleInterval = 360f / eggCount;

            // 生成蛋
            for (int i = 0; i < eggCount; i++)
            {
                // 计算当前蛋的角度
                float angle = i * angleInterval;

                // 将角度转换为弧度
                float radian = angle * Mathf.Deg2Rad;

                // 计算蛋的位置
                float spawnX = transform.position.x + Mathf.Cos(radian) * spawnRadius;
                float spawnY = transform.position.y + Mathf.Sin(radian) * spawnRadius;

                // 生成蛋并设置位置和方向
                GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject);
                e.transform.position = new Vector3(spawnX, spawnY, transform.position.z);
                e.transform.up = (e.transform.position - transform.position).normalized;

                // 记录生成的蛋
                //mTotalEggCount++;
            }
        }
    }
    public void xueliangjian()
    {
        if (mon3xueliang > 0) mon3xueliang--;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string thisTag = gameObject.tag; // 获取当前游戏对象的标签
        string otherTag = collision.gameObject.tag; // 获取碰撞对象的标签

        Debug.Log("Collision between tag: " + thisTag + " and " + otherTag);

        // 检测两个刚体的标签
        if (otherTag == "attack")
        {
            xueliangjian();
            if (mon3xueliang <= 0)
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
