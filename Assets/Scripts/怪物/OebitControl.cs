using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitControl : MonoBehaviour
{
    public int mon4xueliang = 5;
    public float OrbitRadius = 10f;
    public float OrbitSpeed = 360.0f / 10f; // 10 seconds per cycle
    public Transform HostXform = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(HostXform != null);

        // we follow the host object)
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        // we follow the host
        transform.position = HostXform.position + OrbitRadius * transform.right;

        // update our rotation (sattlite will rotate)
        Quaternion r = Quaternion.AngleAxis((OrbitSpeed * Time.smoothDeltaTime), Vector3.forward);
        transform.rotation = r * transform.rotation;
    }

    public void xueliangjian()
    {
        if (mon4xueliang > 0)
            mon4xueliang--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string thisTag = gameObject.tag; // 获取当前游戏对象的标签
        string otherTag = collision.gameObject.tag; // 获取碰撞对象的标签

        Debug.Log("Collision between tag: " + thisTag + " and " + otherTag);

        // 检测两个刚体的标签
        if (otherTag == "attack" || otherTag == "playBullet")
        {
            xueliangjian();
            if (mon4xueliang <= 0)
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
