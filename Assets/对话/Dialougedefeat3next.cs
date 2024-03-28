using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialougedefeat3 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Dialougedefeat3next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 11);
    }
}