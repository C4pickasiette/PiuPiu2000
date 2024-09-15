using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{

    public float speed = 4;

    private Vector2 refreshTimeRange = new Vector2(1, 5);
    private float refreshTime = 1f;
    private float deltaTime = 0f;

    private Vector3 direction;

    void Start()
    {
        RefreshDirection();
    }


    void Update()
    {
        deltaTime += Time.deltaTime;

        if(deltaTime >= refreshTime) 
        {
            refreshTime = Random.Range(refreshTimeRange.x, refreshTimeRange.y);
            RefreshDirection();
            deltaTime = 0;
        }

        transform.position += direction * Time.deltaTime * speed;
    }

    private void RefreshDirection()
    {
        Vector3 directionPlayer = GameManager.Main.playerPosition - transform.position;
        direction = Vector3.Lerp(directionPlayer.normalized, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Random.value);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
}
