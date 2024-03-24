using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroInjured : MonoBehaviour
{
    public int healthCnt = 100;
    private Shield Shield;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool IfisDefencing()
    {
        Shield = GetComponent<Shield>();
        return Shield.isDefencing;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string Tag = collision.gameObject.tag;
        
        if (!IfisDefencing())
        {
            if (Tag == "Enemy")
            {
                healthCnt -= 20;
            }
            if (Tag == "Bullet")
            {
                healthCnt -= 15;
            }
        }
        if (healthCnt <= 0)
            Destroy(gameObject);
    }
}
