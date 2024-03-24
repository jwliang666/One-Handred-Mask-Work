using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bsheep : MonoBehaviour
{
    public Transform[] waypoints; // 定义路径点
    public float moveSpeed = 3f; // 移动速度

    private int currentWaypointIndex = 0; // 当前路径点索引
    public Animator myani;
    void Start()
    {
        // 初始化当前路径点为第一个路径点
        transform.position = waypoints[0].position;
    }

    
    void move()
    {
        // 检查是否有路径点
        if (waypoints.Length ==currentWaypointIndex)
         {   
           myani.SetBool("bsleft",false);
           myani.SetBool("bsright",false);
           myani.SetBool("bsup",false);
           myani.SetBool("bsdown",false);
          return;
         }

        // 获取当前路径点
        Transform currentWaypoint = waypoints[currentWaypointIndex];

        // 计算NPC朝向当前路径点的方向
        Vector3 direction = currentWaypoint.position - transform.position;
    

        // 如果NPC与当前路径点的距离小于一个阈值，前往下一个路径点
        if (direction.magnitude < 0.1f)
        {
            transform.position=waypoints[currentWaypointIndex].position;
            if(currentWaypointIndex<waypoints.Length)
            currentWaypointIndex++;
            else return;
        }
         
        // 计算NPC的移动向量
        Vector3 movement = direction.normalized * moveSpeed * Time.deltaTime;
        myani.GetComponent<Animator>();
              myani.SetBool("bsleft",false);
              myani.SetBool("bsright",false);
              myani.SetBool("bsup",false);
              myani.SetBool("bsdown",false);
             
             
             
              if(direction.x<-0.05f)
              {
                myani.SetBool("bsleft",true);
              }
              if(direction.x>0.05f)
              {
               myani.SetBool("bsright",true);
              }  
              else if(direction.y>0.05f)
              {
                myani.SetBool("bsup",true);
              }  
              else if(direction.y<-0.05f)
              {
                myani.SetBool("bsdown",true);
              }
   
        // 移动NPC
        transform.position += movement;
        
    
    }
    void Update()
    {
        move();
        
        
    }

}