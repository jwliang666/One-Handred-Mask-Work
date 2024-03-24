using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playcontrol : MonoBehaviour
{
     public float mHeroSpeed = 13f;//人物移动速度
    public float coolDownSprintTime = 1.8f;//冲刺条满能量 说是能量其实是2.5s，1s对应1单位能量
    public float currentCoolDownSprintTime = 1.8f;//当前冲刺条能量
    private float sprintMul = 1.4f;
    public Vector3 currentRotation = new Vector3(1, 0, 0);//朝向,只能上下左右朝向
    public Animator myani;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        wsadMove();
        sprintMove();
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    
    private void wsadMove()
    {
        float verticalSpeed = Input.GetAxis("Vertical") * mHeroSpeed;
        float horizontalSpeed = Input.GetAxis("Horizontal") * mHeroSpeed;
        refreshRotation();
        if (ifPlayerCanMove())
            {
              transform.position += verticalSpeed * Time.smoothDeltaTime * transform.up + horizontalSpeed * Time.smoothDeltaTime * transform.right;
              myani.GetComponent<Animator>();
              myani.SetBool("left",false);
              myani.SetBool("right",false);
              myani.SetBool("up",false);
              myani.SetBool("down",false);
              if(horizontalSpeed <0)
              {
                myani.SetBool("left",true);
              }
              else if(horizontalSpeed>0)
              {
               myani.SetBool("right",true);
              }  
              else if(verticalSpeed>0)
              {
                myani.SetBool("up",true);
              }  
              else if(verticalSpeed<0)
              {
                myani.SetBool("down",true);
              }

              
            }
    }

    
    private void sprintMove()
    {
        if (Input.GetKey(KeyCode.L) && currentCoolDownSprintTime > 0f)
        {
            float verticalSpeed = Input.GetAxis("Vertical") * mHeroSpeed * sprintMul;
            float horizontalSpeed = Input.GetAxis("Horizontal") * mHeroSpeed * sprintMul;
            refreshRotation();
            if (ifPlayerCanMove())
                transform.position += verticalSpeed * Time.smoothDeltaTime * transform.up + horizontalSpeed * Time.smoothDeltaTime * transform.right;
            currentCoolDownSprintTime -= Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.L) && currentCoolDownSprintTime > -0.5f)
            currentCoolDownSprintTime -= Time.deltaTime;

        if (currentCoolDownSprintTime < coolDownSprintTime && !Input.GetKey(KeyCode.L))
            currentCoolDownSprintTime +=  0.5f * Time.deltaTime;
    }
    private bool ifPlayerCanMove()
    {
        bool flag = true;
        return flag;
    }

    private void refreshRotation()
    {
        float verticalSpeed = Input.GetAxis("Vertical");
        float horizontalSpeed = Input.GetAxis("Horizontal");

        if (verticalSpeed > 0)
        {
            currentRotation.y = 1;
        }
        else if (verticalSpeed == 0 && horizontalSpeed != 0)
        {
            currentRotation.y = 0;
        }
        else if (verticalSpeed < 0)
        {
            currentRotation.y = -1;
        }

        if (horizontalSpeed > 0)
        {
            currentRotation.x = 1;
        }
        else if (horizontalSpeed == 0 && verticalSpeed != 0)
        {
            currentRotation.x = 0;
        }
        else if (horizontalSpeed < 0)
        {
            currentRotation.x = -1;
        }
    }
}
