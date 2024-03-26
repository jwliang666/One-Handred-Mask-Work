using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float livingTime = 0.15f;
    private PlayerManage PlayerManage;
    private PlayerAttack PlayerAttack;
    private Transform PlayerTransform;
    private float swordSpeed = 5f;
    Vector3 qp;
    private Vector3 swordDistance = new Vector3(0, 0, 0);
    private float alreadyLivingTime = 0;
    void Start()
    {
        getPlayerManage();

    }

    // Update is called once per frame
    void Update()
    {
        livingToDead();
        followPlayer();
        swordDisCnt();
    }
    private void getPlayerManage()
    {
        GameObject PlayerManager = GameObject.Find("PlayerManage");
        PlayerManage = PlayerManager.GetComponent<PlayerManage>();
        GameObject hero = GameObject.Find("hero");
        PlayerTransform = hero.GetComponent<Transform>();
    }
    private void followPlayer()
    {
        float mul = 1f;//用来控制斜上距离

        float z = 0;
        if (PlayerManage.getCurrentPlayerRotation().x == 0 && PlayerManage.getCurrentPlayerRotation().y > 0)
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
        p += PlayerManage.getCurrentPlayerRotation().x * PlayerManage.getCurrentPlayerSize().x * PlayerTransform.right * PlayerAttack.attackDisPlayer * mul;
        p += PlayerManage.getCurrentPlayerRotation().y * PlayerManage.getCurrentPlayerSize().y * PlayerTransform.up * PlayerAttack.attackDisPlayer * mul;
        p.z += 2;
        qp = PlayerManage.getCurrentPlayerPosition();
        qp += 0.5f * PlayerManage.getCurrentPlayerRotation().x * PlayerManage.getCurrentPlayerSize().x * PlayerTransform.right * PlayerAttack.attackDisPlayer * mul;
        qp += 0.5f * PlayerManage.getCurrentPlayerRotation().y * PlayerManage.getCurrentPlayerSize().y * PlayerTransform.up * PlayerAttack.attackDisPlayer * mul;
        transform.position = p + swordDistance;
        transform.rotation = q;
    }

    private void swordDisCnt()
    {
        alreadyLivingTime += Time.deltaTime;
        if(alreadyLivingTime <= 0.8f * livingTime)
            swordDistance += swordSpeed * Time.deltaTime * transform.up;
        else
            swordDistance -= 2f *swordSpeed * Time.deltaTime * transform.up;
    }
    private void livingToDead()
    {
        livingTime -= Time.deltaTime;
        if(livingTime <0)
        {
            Destroy(gameObject);
        }
    }

}
