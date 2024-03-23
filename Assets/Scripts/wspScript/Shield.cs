using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    public float healthCnt = 100f;
    private Rigidbody2D rb2d;
    public bool isSpacePressed = false;
    private PlayerMove PlayerMove;
    private float delayTimeCnt = 0f;
    private BoxCollider2D boxCollider2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
        if (Input.GetKey(KeyCode.Space))
        {
            delayTimeCnt += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && !isSpacePressed && delayTimeCnt > 0.5f)
        {
            rb2d.mass *= 100;
            PlayerMove.mHeroSpeed *= 0.1f;
            boxCollider2D.size *= new Vector2(2f, 2f);
            isSpacePressed = true; // 标记空格键被按下
        }
        else if (!Input.GetKey(KeyCode.Space) && isSpacePressed)
        {
            rb2d.mass /= 100;
            PlayerMove.mHeroSpeed *= 10f;
            boxCollider2D.size /= new Vector2(2f, 2f);
            isSpacePressed = false; // 标记空格键松开
            delayTimeCnt = 0f;
        }
    }


}
