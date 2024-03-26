using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;


public class deAxe : MonoBehaviour
{
    public Transform rotationPoint;
    private float rotationSpeed = 450f; // 一圈的角速度为 360 度/秒
    private float livingTime = 0.8f;
    private float alreadyLivingTime = 0;
    private float axeDis = 2f; // 圆的半径
    GameObject hero;
    void Start()
    {
        hero = GameObject.Find("hero");
    }

    void Update()
    {
        alreadyLivingTime += Time.deltaTime;
        if (alreadyLivingTime >= livingTime)
            Destroy(gameObject);
        rotationPoint = hero.GetComponent<Transform>();


        float angle = rotationSpeed * Time.deltaTime;
        transform.RotateAround(rotationPoint.position, Vector3.forward, angle);
        float x = rotationPoint.position.x + Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z) * axeDis;
        float y = rotationPoint.position.y + Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z) * axeDis;
        Vector3 newPos = new Vector3(x, y, transform.position.z);
        transform.position = newPos;
    }
}