using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl2D : MonoBehaviour
{
    [Header("Datas")]
    public float speed;

    [Header("Shooter")]
    public Projectile projectilePrefab;

    private Vector3 direction;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        Shoot();
    }

    private void Movement()
    {
        direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction -= Vector3.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }

        Vector3 _position = direction * Time.deltaTime * speed;
        Vector3 position = transform.position + _position;
        float orthoSizeY = Camera.main.orthographicSize;
        float orthoSizeX = Camera.main.orthographicSize * 16f / 9f;

        if (position.y > orthoSizeY || position.y < -orthoSizeY || position.x > orthoSizeX || position.x < -orthoSizeX)
            return;

        transform.position = position;
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Instantiate(projectilePrefab.gameObject, transform.position, Quaternion.identity);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            Debug.Log("You DEAD");
        }
    }
}
