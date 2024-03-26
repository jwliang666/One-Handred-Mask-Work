using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panbullet : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 direction;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (!IsInCameraView())
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        string Tag = collision.gameObject.tag;
        if (Tag == "Player" || Tag == "Wall")
        {
            Destroy(transform.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string Tag = collision.gameObject.tag;
        if (Tag == "Player" || Tag == "Wall")
        {
            Destroy(transform.gameObject);
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