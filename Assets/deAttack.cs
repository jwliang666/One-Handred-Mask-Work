using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float livingTime = 0.5f;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void livingToDead()
    {
        livingTime -= Time.deltaTime;
        if(livingTime < 0.2f && Input.GetKeyDown(KeyCode.J))
        { /*多段攻击(如果有）
           * Destroy 第一段
           * Resources.load第二段
           * */
        }
        if(livingTime <0)
        {
            Destroy(gameObject);
        }
    }
    private Vector3 getHeroPosition()
    {
        PlayerMove PlayerMove;
        GameObject hero = GameObject.Find("hero");
        PlayerMove = hero.GetComponent<PlayerMove>();
        return hero.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            /*
             */
        }
    }
}
