using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster3 : MonoBehaviour
{
    public int mon3xueliang = 12;
    private float spawnTimer = 0f;
    private float spawnInterval = 1f;
    float spawnRadius = 2.0f;
    public GameObject mMyTarget1 = null;
    public GameObject mMyTarget2 = null;
    public float mChaseRange = 30f; // 追随范围
    public GameObject littlePlane = null;
    public AudioSource deathSound;
    // Start is called before the first frame update
    void Start()
    {
        mMyTarget1 = GameObject.Find("hero");
        mMyTarget2 = GameObject.Find("bssheep");
        deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        float fangshi = Random.value;
        if (Vector3.Distance(transform.position, mMyTarget1.transform.position) <= mChaseRange ||
         Vector3.Distance(transform.position, mMyTarget2.transform.position) <= mChaseRange)
        {
            if (fangshi >= 0.5f)
                luoxuanegg();
            else
                tongshiegg();
        }// 当计时器大于等于生成间隔时生成蛋并重置计时器


        if (mon3xueliang <= 0)
        {
            
            Vector3 BOMBp = transform.position;
            Quaternion qq = Quaternion.Euler(0, 0, 0);
            Instantiate(Resources.Load("Prefabs/BigMonsterDead") as GameObject, BOMBp, qq);
            cntjian();
            Destroy(gameObject);
        }
    }
    private void luoxuanegg()
    {
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;

            // 定义生成蛋的半径
            float spawnRadius = 2.0f; // 可以根据需要调整生成的蛋围绕的半径

            // 设置要生成蛋的数量
            int eggCount = 8; // 这里假设生成8个蛋，你可以根据需要调整数量

            // 计算每个蛋之间的角度间隔
            float angleInterval = 360f / eggCount;

            // 计算生成间隔时间，使得蛋在时间上错开
            float spawnDelay = 0.1f; // 可以根据需要调整每个蛋生成的延迟时间

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

                // 延迟生成蛋
                StartCoroutine(SpawnEggWithDelay(spawnX, spawnY, spawnDelay * i));
            }
        }
    }

    IEnumerator SpawnEggWithDelay(float x, float y, float delay)
    {
        yield return new WaitForSeconds(delay);

        // 生成蛋并设置位置和方向
        GameObject e = Instantiate(Resources.Load("Prefabs/Egg") as GameObject);
        e.transform.position = new Vector3(x, y, transform.position.z);
        e.transform.up = (e.transform.position - transform.position).normalized;

        // 记录生成的蛋
        //mTotalEggCount++;
    }


    private void tongshiegg()
    {
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

    private bool IfLittlePlaneliving()
    {
        bool flag = true;
        if (littlePlane == null)
            flag = false;
        return flag;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "attack" && (!IfLittlePlaneliving()))
        {
            mon3xueliang -= 4;
            deathSound.Play();
        }
        else if (other.gameObject.tag == "playerBullet" && (!IfLittlePlaneliving()))
        {
            mon3xueliang -= 2;
            deathSound.Play();
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
