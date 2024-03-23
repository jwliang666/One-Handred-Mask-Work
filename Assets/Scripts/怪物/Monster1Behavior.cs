using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonoBehaviour
{
    public int mon1xueliang = 1;
    public GameObject mMyTarget = null;
    public float mTurnRate = 0.05f;
    private const float kMySpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        getMytarget();
        Debug.Assert(mMyTarget != null);
    }

    // Update is called once per frame
    void Update()
    {

        PointAtPosition(mMyTarget.transform.localPosition, mTurnRate * Time.smoothDeltaTime);
        transform.localPosition += kMySpeed * Time.smoothDeltaTime * transform.up;
    }

    private void getMytarget()
    {
        mMyTarget = GameObject.Find("hero");
    }
    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.localPosition;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }
    public void xueliangjian()
    {
        if (mon1xueliang > 0)
            mon1xueliang--;
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
            if (mon1xueliang <= 0)
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
