using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonoBehaviour
{
    public int mon1xueliang = 10;
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
        if(mMyTarget != null)
        {
            PointAtPosition(mMyTarget.transform.localPosition, mTurnRate * Time.smoothDeltaTime);
            transform.localPosition += kMySpeed * Time.smoothDeltaTime * transform.up;
        }
        if (mon1xueliang <= 0)
            Destroy(gameObject);
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

}
