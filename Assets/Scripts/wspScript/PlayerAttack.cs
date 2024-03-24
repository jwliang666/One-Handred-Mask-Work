using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    public int AttackType = 0;// 0==defaultAttack
    public const float attackDisPlayer = 2f;//攻击与玩家的距离
    private PlayerManage PlayerManage;
    private GameObject currentWeapon;
    private const float attackCoolTime = 0.2f;//每0.2f可攻击一次
    private float attackDisTime = 0.2f;//>0.2f才能攻击，否则不能
    void Start()
    {
        getPlayerManage();
    }

   
    void Update()
    {
        if(IfPlayerCanAttack())
            Attack();
        attackTime();
    }
   

    private void getPlayerManage()
    {
        GameObject PlayerManager = GameObject.Find("PlayerManage");
        PlayerManage = PlayerManager.GetComponent<PlayerManage>();
    }

    private void attackTime()
    {
        if(attackDisTime <= attackCoolTime)
            attackDisTime += Time.deltaTime;
    }
    private void Attack()
    {
    
        if (Input.GetKeyDown(KeyCode.J))
        {
            if(AttackType == 0)
            {
                float mul = 1f;//用来控制斜上距离

                float z = 0;
                if(PlayerManage.getCurrentPlayerRotation().x == 0  && PlayerManage.getCurrentPlayerRotation().y > 0)
                {
                    z = 0;  
                }
                else if (PlayerManage.getCurrentPlayerRotation().x < 0 && PlayerManage.getCurrentPlayerRotation().y > 0)
                {
                    z = 45;
                    mul = 0.707f;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x < 0 && PlayerManage.getCurrentPlayerRotation().y == 0)
                {
                    z = 90;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x < 0 && PlayerManage.getCurrentPlayerRotation().y < 0)
                {
                    z = 135;
                    mul = 0.707f;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x == 0 && PlayerManage.getCurrentPlayerRotation().y < 0)
                {
                    z = 180;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x > 0 && PlayerManage.getCurrentPlayerRotation().y < 0)
                {
                    z = -135;
                    mul = 0.707f;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x > 0 && PlayerManage.getCurrentPlayerRotation().y == 0)
                {
                    z = -90;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x > 0 && PlayerManage.getCurrentPlayerRotation().y > 0)
                {
                    z = -45;
                    mul = 0.707f;
                }
                Quaternion q = Quaternion.Euler(0, 0, z);

                Vector3 p = PlayerManage.getCurrentPlayerPosition();
                p += PlayerManage.getCurrentPlayerRotation().x * PlayerManage.getCurrentPlayerSize().x * transform.right * PlayerAttack.attackDisPlayer * mul;
                p += PlayerManage.getCurrentPlayerRotation().y * PlayerManage.getCurrentPlayerSize().y * transform.up * PlayerAttack.attackDisPlayer * mul;
                currentWeapon = Instantiate(Resources.Load("Prefabs/deAttack") as GameObject, p, q, transform);
            } 
            attackDisTime -= attackCoolTime;
        }
    }
    
    private bool IfPlayerCanAttack()
    {
        bool flag = true;
        if (attackDisTime < 0.2f)
            flag = false;
        return flag;
    }


}
