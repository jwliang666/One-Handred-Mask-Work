using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombbehavior : MonoBehaviour
{
    public float speed = 40f;

    private Vector3 direction;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (!IsInCameraView())
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // ������� Hero��������ը������
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Arrow: OnTriggerEnter2D");
        if (collision.gameObject.tag == "player")
        {
            Destroy(transform.gameObject);  // kills self
            //sGreenArrow.OneLessEgg();
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
