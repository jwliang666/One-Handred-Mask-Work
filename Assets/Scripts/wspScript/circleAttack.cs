using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            circleSword();
    }

    private void circleSword()
    {
        Vector3 p = transform.position + 5f * transform.up;
        Quaternion q = Quaternion.Euler(0, 0, 0); // 初始旋转角度
        GameObject Sword = Instantiate(Resources.Load("Prefabs/deAttack") as GameObject, p, q);

        StartCoroutine(RotateSword(Sword));
    }

    private IEnumerator RotateSword(GameObject sword)
    {
        float duration = 1f; // 旋转持续时间
        float rotationSpeed = 360f / duration; // 每秒旋转角度

        float timePassed = 0f;
        while (timePassed < duration)
        {
            float angle = rotationSpeed * Time.deltaTime; // 计算本帧旋转角度
            sword.transform.RotateAround(transform.position, Vector3.forward, angle); // 绕指定轴旋转
            timePassed += Time.deltaTime;
            yield return null; // 等待下一帧
        }

        // 确保旋转到 360 度
        sword.transform.RotateAround(transform.position, Vector3.forward, 360 - (rotationSpeed * Time.deltaTime) * timePassed);
    }
}
