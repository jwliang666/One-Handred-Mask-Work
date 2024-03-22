using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float mHeroSpeed = 20f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += mHeroSpeed * Time.smoothDeltaTime * transform.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= mHeroSpeed * Time.smoothDeltaTime * transform.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= mHeroSpeed * Time.smoothDeltaTime * transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += mHeroSpeed * Time.smoothDeltaTime * transform.right;
        }

    }
}
