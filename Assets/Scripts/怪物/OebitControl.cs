using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitControl : MonoBehaviour
{
    public int mon4xueliang = 6;
    public float OrbitRadius = 10f;
    public float OrbitSpeed = 360.0f / 10f; // 10 seconds per cycle
    public Transform HostXform = null;
    public AudioSource deathSound;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(HostXform != null);

        // we follow the host object)
        transform.rotation = Quaternion.identity;
        deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // we follow the host
        transform.position = HostXform.position + OrbitRadius * transform.right;

        // update our rotation (sattlite will rotate)
        Quaternion r = Quaternion.AngleAxis((OrbitSpeed * Time.smoothDeltaTime), Vector3.forward);
        transform.rotation = r * transform.rotation;

        if (mon4xueliang <= 0)
        {
            cntjian();
            Vector3 BOMBp = transform.position;
            Quaternion qq = Quaternion.Euler(0, 0, 0);
            Instantiate(Resources.Load("Prefabs/smallMonsterDead") as GameObject, BOMBp, qq);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "attack")
        {
            mon4xueliang -= 4;
            deathSound.Play();
        }
        else if (other.gameObject.tag == "playerBullet")
        {
            mon4xueliang -= 2;
            deathSound.Play();
        }
    }
    private void cntjian()
    {
        monsterCnt a = GetComponent<monsterCnt>();
        if (a != null)
        {
            a.moncntjian();
        }
    }

}
