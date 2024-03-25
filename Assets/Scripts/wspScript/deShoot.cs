using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deShoot : MonoBehaviour
{

    private float livingTime = 3f;
    private PlayerManage PlayerManage;
    public float flyingSpeed = 20f;
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

    void OnTriggerStay2D(Collider2D other)
    {
        string otherTag = other.gameObject.tag;
        if (otherTag != "Player")
            Destroy(gameObject);
    }


}
