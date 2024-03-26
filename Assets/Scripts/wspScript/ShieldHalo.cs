using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHalo : MonoBehaviour
{
    private Shield shield;
    private Renderer shieldRenderer;

    void Start()
    {
        shieldRenderer = GetComponent<Renderer>();
        StartCoroutine(ChangeColorOverTime());
    }

    private IEnumerator ChangeColorOverTime()
    {
        Color startColor = Color.gray; // 初始颜色
        Color endColor = Color.white; // 最终颜色
        float duration = 0.3f; // 变化持续时间

        float timePassed = 0f;
        while (timePassed < duration)
        {
            float t = timePassed / duration; // 计算插值比例
            shieldRenderer.material.color = Color.Lerp(startColor, endColor, t); // 插值设置颜色
            timePassed += Time.deltaTime;
            yield return null; // 等待下一帧
        }

        // 最后一个颜色变化完成后，突变为红色
        shieldRenderer.material.color = Color.red;
    }

    void Update()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }
}

