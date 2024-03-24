using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public int ShootType = 0;// 0==defaultShoot
    public const float ShootDisPlayer = 2f;//攻击与玩家的距离
    private PlayerManage PlayerManage;
    private const float ShootCoolTime = 0.2f;//每0.2f可攻击一次
    private float ShootDisTime = 0.2f;//>0.2f才能攻击，否则不能
    void Start()
    {
        getPlayerManage();
    }


    void Update()
    {
        if (IfPlayerCanShoot())
            Shoot();
        ShootTime();
    }


    private void getPlayerManage()
    {
        GameObject PlayerManager = GameObject.Find("PlayerManage");
        PlayerManage = PlayerManager.GetComponent<PlayerManage>();
    }

    private void ShootTime()
    {
        if (ShootDisTime <= ShootCoolTime)
            ShootDisTime += Time.deltaTime;
    }
    private void Shoot()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (ShootType == 0)
            {
                int z = 0;
                if (PlayerManage.getCurrentPlayerRotation().x == 0 && PlayerManage.getCurrentPlayerRotation().y > 0)
                {
                    z = 0;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x < 0 && PlayerManage.getCurrentPlayerRotation().y > 0)
                {
                    z = 45;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x < 0 && PlayerManage.getCurrentPlayerRotation().y == 0)
                {
                    z = 90;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x < 0 && PlayerManage.getCurrentPlayerRotation().y < 0)
                {
                    z = 135;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x == 0 && PlayerManage.getCurrentPlayerRotation().y < 0)
                {
                    z = 180;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x > 0 && PlayerManage.getCurrentPlayerRotation().y < 0)
                {
                    z = -135;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x > 0 && PlayerManage.getCurrentPlayerRotation().y == 0)
                {
                    z = -90;
                }
                else if (PlayerManage.getCurrentPlayerRotation().x > 0 && PlayerManage.getCurrentPlayerRotation().y > 0)
                {
                    z = -45;
                }
                Quaternion q = Quaternion.Euler(0, 0, z);

                Vector3 p = PlayerManage.getCurrentPlayerPosition();
                int z1 = z + 20;
                int z2 = z - 20;
                Quaternion q1 = Quaternion.Euler(0, 0, z1);
                Quaternion q2 = Quaternion.Euler(0, 0, z2);
                Instantiate(Resources.Load("Prefabs/deShoot") as GameObject, p, q);
                Instantiate(Resources.Load("Prefabs/deShoot") as GameObject, p, q1);
                Instantiate(Resources.Load("Prefabs/deShoot") as GameObject, p, q2);

            }
            ShootDisTime -= ShootCoolTime;
        }
    }

    private bool IfPlayerCanShoot()
    {
        bool flag = true;
        if (ShootDisTime < ShootCoolTime)
            flag = false;
        return flag;
    }
}