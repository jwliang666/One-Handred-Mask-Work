using UnityEngine;
using UnityEngine.UI;

public class mon4bar : MonoBehaviour
{ // 参考怪物的Transform
    public Slider slider; // 血条的Slider组件

    public OrbitControl mon1 = null;

    void Start()
    {
        if (mon1 == null)
        {
            Debug.LogError("请为monster变量赋值");
            return;
        }
    }
    void Update()
    {
        LateUpdate();
        SetHealth(mon1.mon4xueliang / 6);
    }

    void LateUpdate()
    {
        // 将怪物头顶的世界坐标转换为屏幕坐标
        Vector3 worldPos = mon1.transform.position + Vector3.up * 2; // 2是相对于怪物头顶的偏移量
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        // 将屏幕坐标转换为UI坐标
        Vector3 uiPos = new Vector3(screenPos.x, screenPos.y, 0);

        // 更新血条的位置
        transform.position = uiPos;
    }

    // 设置血条的值
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
