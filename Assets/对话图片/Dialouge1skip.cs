using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialouge1skip : MonoBehaviour
{
    // 跳转到指定场景
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene("firstDemo");
    }

    
}
