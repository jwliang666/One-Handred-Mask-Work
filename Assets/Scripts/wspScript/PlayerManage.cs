using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManage : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 getCurrentPlayerPosition()
    {
        GameObject hero = GameObject.Find("hero");
        return hero.transform.position;
    }

    public Vector3 getCurrentPlayerRotation()
    {
        GameObject hero = GameObject.Find("hero");
        PlayerMove PlayerMove = hero.GetComponent<PlayerMove>();
        return PlayerMove.currentRotation;
    }

    public Vector3 getCurrentPlayerSize()
    {
        GameObject hero = GameObject.Find("hero");
        BoxCollider2D collider = hero.GetComponent<BoxCollider2D>();
        Vector3 size = collider.size;
        return size;
    }
}
