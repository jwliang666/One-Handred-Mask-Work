using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonoBehaviour
{
    public int mon1xueliang = 6;
    public GameObject mMyTarget = null;
    public float mTurnRate = 0.05f;
    public float mChaseRange = 10f; // 追随范围
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
        if (mMyTarget != null && Vector3.Distance(transform.position, mMyTarget.transform.position) <= mChaseRange)
        {
            PointAtPosition(mMyTarget.transform.position, mTurnRate * Time.smoothDeltaTime);
            transform.position += kMySpeed * Time.smoothDeltaTime * transform.up;
        }

        if (mon1xueliang <= 0)
        {
            cntjian();
            Destroy(gameObject);
        }
    }

    private void getMytarget()
    {
        mMyTarget = GameObject.Find("hero");
    }

    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.position;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("pengpengpenpgnepng");
        if (other.gameObject.tag == "attack")
        {
            mon1xueliang -= 4;
        }
        else if (other.gameObject.tag == "playerBullet")
        {
            mon1xueliang -= 1;
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
