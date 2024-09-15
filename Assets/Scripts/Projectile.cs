using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    public float speed = 10;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        direction.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position + direction * Time.deltaTime * speed;
        transform.position = position;

        float orthoSizeY = Camera.main.orthographicSize;
        float orthoSizeX = Camera.main.orthographicSize * 16f / 9f;

        if (position.y > orthoSizeY || position.y < -orthoSizeY || position.x > orthoSizeX || position.x < -orthoSizeX)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            Destroy(gameObject);
        }
    }
}
