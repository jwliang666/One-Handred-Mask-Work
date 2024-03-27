using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialougedefeat0 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Dialougedefeat0next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}