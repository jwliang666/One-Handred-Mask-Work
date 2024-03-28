using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialouge0skip : MonoBehaviour
{
    // 跳转到指定场景
    public void Dialouge0skipbyname(string sceneName)
    {
        SceneManager.LoadScene("map1");
    }

    
}
