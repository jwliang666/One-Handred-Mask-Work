using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float mHeroSpeed = 13f;//人物移动速度
    private int sprintBar = 1;//当前可进行的冲刺次数（0||1）
    public float coolDownSprintTime = 1.5f;//冲刺一次需要的冷却时间
    private float currentCoolDownSprintTime = 1.5f;//当前冲刺冷却时间
    public float sprintDistanceMul = 155f;//冲刺距离控制
    private float sprintTiredTimeMul = 0.1f;//冲刺后不能移动的时间
    public Vector3 currentRotation = new Vector3(1, 0, 0);//朝向,只能上下左右朝向

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wsadMove();
        sprintMove();
    }

    private void wsadMove()
    {
        float verticalSpeed = Input.GetAxis("Vertical") * mHeroSpeed;
        float horizontalSpeed = Input.GetAxis("Horizontal") * mHeroSpeed;


        if(verticalSpeed > 0)
        {
            currentRotation.y = 1;
        }
        else if(verticalSpeed == 0)
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
        else if (horizontalSpeed == 0)
        {
            currentRotation.x = 0;
        }
        else if (horizontalSpeed < 0)
        {
            currentRotation.x = -1;
        }

        transform.position += verticalSpeed * Time.smoothDeltaTime * transform.up + horizontalSpeed * Time.smoothDeltaTime * transform.right;

    }
  

    private void sprintMove()
    {
        if (Input.GetKeyDown(KeyCode.L) && sprintBar == 1)
        {
            float DisMul = 1f;
            if (currentRotation.x != 0 && currentRotation.y != 0)
                DisMul = 0.707f;
            transform.position += currentRotation.y * mHeroSpeed * Time.smoothDeltaTime * transform.up * sprintDistanceMul * DisMul;
            transform.position += currentRotation.x * mHeroSpeed * Time.smoothDeltaTime * transform.right * sprintDistanceMul * DisMul;
            sprintBar--;
        }

        if (sprintBar == 0 && currentCoolDownSprintTime >= coolDownSprintTime)
        {
            currentCoolDownSprintTime -= coolDownSprintTime;
            sprintBar++;
        }

        if (currentCoolDownSprintTime < coolDownSprintTime)
        {
            currentCoolDownSprintTime += Time.deltaTime;
        }


    }

    private void dashMove()
    {

        if (Input.GetKey(KeyCode.W) && sprintBar == 1 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {

            if (Input.GetKeyDown(KeyCode.L))
            {
                transform.position += mHeroSpeed * Time.smoothDeltaTime * transform.up * sprintDistanceMul;
                sprintBar--;
            }
        }
        if (Input.GetKey(KeyCode.S) && sprintBar == 1 && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {

            if (Input.GetKeyDown(KeyCode.L))
            {
                transform.position -= mHeroSpeed * Time.smoothDeltaTime * transform.up * sprintDistanceMul;
                sprintBar--;
            }
        }
        if (Input.GetKey(KeyCode.A) && sprintBar == 1 && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {

            if (Input.GetKeyDown(KeyCode.L))
            {
                transform.position -= mHeroSpeed * Time.smoothDeltaTime * transform.right * sprintDistanceMul;
                sprintBar--;
            }
        }
        if (Input.GetKey(KeyCode.D) && sprintBar == 1 && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {

            if (Input.GetKeyDown(KeyCode.L))
            {
                transform.position += mHeroSpeed * Time.smoothDeltaTime * transform.right * sprintDistanceMul;
                sprintBar--;
            }
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && sprintBar == 1)
        {

            if (Input.GetKeyDown(KeyCode.L))
            {
                transform.position += mHeroSpeed * Time.smoothDeltaTime * transform.up * sprintDistanceMul * 0.707f;
                transform.position -= mHeroSpeed * Time.smoothDeltaTime * transform.right * sprintDistanceMul * 0.707f;
                sprintBar--;
            }
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D) && sprintBar == 1)
        {

            if (Input.GetKeyDown(KeyCode.L))
            {
                transform.position += mHeroSpeed * Time.smoothDeltaTime * transform.up * sprintDistanceMul * 0.707f;
                transform.position += mHeroSpeed * Time.smoothDeltaTime * transform.right * sprintDistanceMul * 0.707f;
                sprintBar--;
            }
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && sprintBar == 1)
        {

            if (Input.GetKeyDown(KeyCode.L))
            {
                transform.position -= mHeroSpeed * Time.smoothDeltaTime * transform.up * sprintDistanceMul * 0.707f;
                transform.position -= mHeroSpeed * Time.smoothDeltaTime * transform.right * sprintDistanceMul * 0.707f;
                sprintBar--;
            }
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && sprintBar == 1)
        {

            if (Input.GetKeyDown(KeyCode.L))
            {
                transform.position -= mHeroSpeed * Time.smoothDeltaTime * transform.up * sprintDistanceMul * 0.707f;
                transform.position -= mHeroSpeed * Time.smoothDeltaTime * transform.right * sprintDistanceMul * 0.707f;
                sprintBar--;
            }
        }



        if (sprintBar == 0 && currentCoolDownSprintTime >= coolDownSprintTime)
        {
            currentCoolDownSprintTime -= coolDownSprintTime;
            sprintBar++;
        }

        if (currentCoolDownSprintTime < coolDownSprintTime)
        {
            currentCoolDownSprintTime += Time.deltaTime;
        }


    }
}
