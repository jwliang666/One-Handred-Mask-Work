using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isDefencing = false;
    private PlayerMove PlayerMove;
    private float delayTimeCnt = 0f;
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame

    void Update()
    {
        raiseShield();
    }

    private void raiseShield()
    {
        GameObject hero = GameObject.Find("hero");
        PlayerMove = hero.GetComponent<PlayerMove>();
        Vector3 oriSize = boxCollider2D.size;
        if (Input.GetKey(KeyCode.Space))
        {
            if(delayTimeCnt == 0f)
                Instantiate(Resources.Load("Prefabs/ShieldHalo") as GameObject, transform);
            delayTimeCnt += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && !isDefencing && delayTimeCnt > 0.5f)
        {
            PlayerMove.mHeroSpeed *= 0.1f;
            boxCollider2D.size *= new Vector2(2.3f, 2.3f);
            isDefencing = true; // 标记空格键被按下
        }
        else if (!Input.GetKey(KeyCode.Space) && isDefencing)
        {
            PlayerMove.mHeroSpeed *= 10f;
            boxCollider2D.size /= new Vector2(2.3f, 2.3f);
            isDefencing = false; // 标记空格键松开
            delayTimeCnt = 0f;
        }
    }


}
