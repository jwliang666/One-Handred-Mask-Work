using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBorn : MonoBehaviour
{
    public float circleDistance = 6f;//刷怪半径
    public float bornDisTime = 5f;//刷怪间隔时间
    private float nowBornDisTime = 5f;
    void Start()
    {

    }

    void Update()
    {
        refreshTimeBorn();
    }
    
    private void refreshTimeBorn()
    {

        nowBornDisTime += Time.deltaTime;
        if (nowBornDisTime >= bornDisTime)
        {
            born();
            nowBornDisTime -= bornDisTime;
        }

    }
    private void born()
    {
        Vector3 p = transform.position;
        Vector3 randomPoint = GenerateRandomPointOnCircle(p, circleDistance);
        Quaternion q = Quaternion.Euler(0, 0, 0);
        Instantiate(Resources.Load("Prefabs/enemyBird") as GameObject, randomPoint, q);
    }
    Vector3 GenerateRandomPointOnCircle(Vector3 center, float radius)
    {
        float randomAngle = Random.Range(0f, 360f);
        float x = center.x + radius * Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float z = center.z + radius * Mathf.Sin(randomAngle * Mathf.Deg2Rad);
        Vector3 randomPoint = new Vector3(x, center.y, z);
        return randomPoint;
    }
}
