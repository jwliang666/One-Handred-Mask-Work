using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float livingTime = 0.2f;
    private PlayerManage PlayerManage;
    private PlayerAttack PlayerAttack;
    private Transform PlayerTransform;
    Vector3 qp;
    void Start()
    {
        getPlayerManage();

    }

    // Update is called once per frame
    void Update()
    {
        livingToDead();
        followPlayer();
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
        qp = PlayerManage.getCurrentPlayerPosition();
        qp += 0.5f * PlayerManage.getCurrentPlayerRotation().x * PlayerManage.getCurrentPlayerSize().x * PlayerTransform.right * PlayerAttack.attackDisPlayer * mul;
        qp += 0.5f * PlayerManage.getCurrentPlayerRotation().y * PlayerManage.getCurrentPlayerSize().y * PlayerTransform.up * PlayerAttack.attackDisPlayer * mul;
        transform.position = p;
        transform.rotation = q;
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
