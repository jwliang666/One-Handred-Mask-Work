using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulleDestory : MonoBehaviour
{
    // Start is called before the first frame update
    private float livingTime = 0.5f;
    private float alreadyLivingTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alreadyLivingTime += Time.deltaTime;
        if(alreadyLivingTime > livingTime)
        {
            Destroy(gameObject);
        }
    }
}
