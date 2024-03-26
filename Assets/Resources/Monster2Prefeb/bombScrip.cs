using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombbehavior : MonoBehaviour
{
    public float speed = 20f;

    private Vector3 direction;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (!IsInCameraView())
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        string otherTag = other.gameObject.tag;
        if (otherTag == "Player" || otherTag == "Wall")
        {
            Vector3 BOMBp = transform.position;
            Quaternion qq = Quaternion.Euler(0, 0, 0);
            Instantiate(Resources.Load("Prefabs/Red") as GameObject, BOMBp, qq);
            Destroy(gameObject);
        }

    }


    private bool IsInCameraView()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        return screenPos.x > 0 && screenPos.x < Screen.width && screenPos.y > 0 && screenPos.y < Screen.height;
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection.normalized;
    }


}
