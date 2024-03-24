using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deShot : MonoBehaviour
{

    private float livingTime = 3f;
    private PlayerManage PlayerManage;
    private PlayerAttack PlayerAttack;
    private float flyingSpeed = 20f;
    void Start()
    {
        getPlayerManage();

    }

    void Update()
    {
        livingToDead();
        fly();
    }

    private void fly()
    {
        transform.position += flyingSpeed * Time.smoothDeltaTime * transform.up;
    }
    private void getPlayerManage()
    {
        GameObject PlayerManager = GameObject.Find("PlayerManage");
        PlayerManage = PlayerManager.GetComponent<PlayerManage>();
    }

    private void livingToDead()
    {
        livingTime -= Time.deltaTime;
        if (livingTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);          
        }
    }

}
