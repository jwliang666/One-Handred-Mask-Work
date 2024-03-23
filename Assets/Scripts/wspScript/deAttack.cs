using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float livingTime = 0.15f;
    private PlayerManage PlayerManage;
    private PlayerAttack PlayerAttack;
    void Start()
    {
        getPlayerManage();

    }

    // Update is called once per frame
    void Update()
    {
        livingToDead();
        
    }
    private void getPlayerManage()
    {
        GameObject PlayerManager = GameObject.Find("PlayerManage");
        PlayerManage = PlayerManager.GetComponent<PlayerManage>();
    }

    private void livingToDead()
    {
        livingTime -= Time.deltaTime;
        if(livingTime <0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
         * if (collision.gameObject.CompareTag("Enemy"))
        {
            
             
        } */        
    }
}
