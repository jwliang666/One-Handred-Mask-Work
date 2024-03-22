using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float mHeroSpeed = 13f;

    private int sprintBar = 1;
    public float coolDownSprintTime = 1.5f;
    private float currentCoolDownSprintTime = 0f;
    public float sprintDistanceMul = 155f;
    private float sprintTiredTimeMul = 0.1f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wasdMove();
        dashMove();
    }

    private void wasdMove()
    {
        if (Input.GetKey(KeyCode.W) && currentCoolDownSprintTime > sprintTiredTimeMul * coolDownSprintTime)
        {
            transform.position += mHeroSpeed * Time.smoothDeltaTime * transform.up;
        }
        if (Input.GetKey(KeyCode.S) && currentCoolDownSprintTime > sprintTiredTimeMul * coolDownSprintTime)
        {
            transform.position -= mHeroSpeed * Time.smoothDeltaTime * transform.up;
        }
        if (Input.GetKey(KeyCode.A) && currentCoolDownSprintTime > sprintTiredTimeMul * coolDownSprintTime)
        {
            transform.position -= mHeroSpeed * Time.smoothDeltaTime * transform.right;
        }
        if (Input.GetKey(KeyCode.D) && currentCoolDownSprintTime > sprintTiredTimeMul * coolDownSprintTime)
        {
            transform.position += mHeroSpeed * Time.smoothDeltaTime * transform.right;
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
