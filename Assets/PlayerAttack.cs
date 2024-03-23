using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public int AttackType = 0;// 0==defaultAttack
    GameObject currentWeapon;
    private PlayerMove PlayerMove;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getCurrentAttackType();
        Attack();
        
    }
    private Vector3 getCurrentPlayerRotation()
    {
        GameObject hero = GameObject.Find("hero");
        PlayerMove = hero.GetComponent<PlayerMove>();
        return PlayerMove.currentRotation;
    }

    private void getCurrentAttackType()
    {
        if(AttackType == 0)
        {
            currentWeapon = Instantiate(Resources.Load("deAttack") as GameObject);
        }
        /*other type*/
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            








        }
    }
    
}
