using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskWudi : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject hero;
    void Start()
    {
        hero = GameObject.Find("hero");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = hero.transform.position;
        p.x += 9.03f;
        p.y -= 4.26f;
        transform.position = p;
    }
}
