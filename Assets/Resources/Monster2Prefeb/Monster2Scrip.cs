using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncher : MonoBehaviour
{
    public GameObject bombPrefab; // ��Ҫ��Unity�༭����ָ����ը��Ԥ����
    public GameObject hero; // Ŀ����󣨱���Ӣ�ۣ�
    public float launchInterval = 1f; // ������ʱ��
    public float speed = 10f; // ը�����ٶ�
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

        // ��ȡ��ǰ hero ��λ��
    
        Debug.Log(targetPosition);
        // ����ը���ķ���
        Vector3 direction = (targetPosition - transform.position).normalized;

        // ʵ����ը��������λ��
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);

        // ��ȡը���ϵ� bombbehavior ������������ٶȺͷ���
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
