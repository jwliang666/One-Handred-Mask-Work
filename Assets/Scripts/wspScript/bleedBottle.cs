using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bleedBottle : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject hero;
    GameObject bssheep;
    heroInjured heroInjured;
    bsheep bsheep;
    void Start()
    {
        hero = GameObject.Find("hero");
        bssheep = GameObject.Find("bssheep");
        heroInjured = hero.GetComponent<heroInjured>();
        bsheep = bssheep.GetComponent<bsheep>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            heroInjured.healthCnt += 200;
            if (heroInjured.healthCnt > 300)
                heroInjured.healthCnt = 300;
            bsheep.bssheephealth += 200;
            if (bsheep.bssheephealth > 300)
                bsheep.bssheephealth = 300;

            Destroy(transform.gameObject);
        }
    }


}