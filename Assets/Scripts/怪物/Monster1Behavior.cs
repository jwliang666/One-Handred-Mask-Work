using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonoBehaviour
{
    public int mon1xueliang = 6;
    public GameObject mMyTarget1 = null;
    public GameObject mMyTarget2 = null;
    public float mTurnRate = 0.05f;
    public float mChaseRange = 10f; // 追随范围
    private const float kMySpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        getMytarget();
    }

    // Update is called once per frame
    void Update()
    {
        float mudistance1 = Vector3.Distance(transform.position, mMyTarget1.transform.position);
        float mudistance2 = Vector3.Distance(transform.position, mMyTarget2.transform.position);

        if (mudistance1 <= mChaseRange || mudistance2 <= mChaseRange)
        {
            if (mudistance1 <= mudistance2)
            {
                PointAtPosition(mMyTarget1.transform.position, mTurnRate * Time.smoothDeltaTime);

            }
            else
            {
                PointAtPosition(mMyTarget2.transform.position, mTurnRate * Time.smoothDeltaTime);
            }
            transform.position += kMySpeed * Time.smoothDeltaTime * transform.up;
        }

        if (mon1xueliang <= 0)
        {
            cntjian();
            Vector3 BOMBp = transform.position;
            Quaternion qq = Quaternion.Euler(0, 0, 0);
            Instantiate(Resources.Load("Prefabs/BigMonsterDead") as GameObject, BOMBp, qq);
            Destroy(gameObject);
        }
    }

    private void getMytarget()
    {
        mMyTarget1 = GameObject.Find("hero");
        mMyTarget2 = GameObject.Find("bssheep");
    }

    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.position;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
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
