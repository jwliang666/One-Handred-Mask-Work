using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialougevictory16 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Dialougevictory16next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}