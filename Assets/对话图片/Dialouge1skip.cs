using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialouge1skip : MonoBehaviour
{
    // ��ת��ָ������
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene("firstDemo");
    }

    
}
