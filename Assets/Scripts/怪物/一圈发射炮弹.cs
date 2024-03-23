using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 一圈发射炮弹 : MonoBehaviour
{
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
}
