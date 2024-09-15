using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerCtrl2D playerCtrl;

    public Ennemy ennemyPrefab;

    [HideInInspector]
    public Vector3 playerPosition => playerCtrl.transform.position;

    public static GameManager Main;

    private Vector2 refreshTimeRange = new Vector2(3, 10);
    private float refreshTime = 3f;
    private float deltaTime = 0f;

    void Awake()
    {
        if(GameManager.Main == null)
        {
            GameManager.Main = this;
        }
        else if(GameManager.Main != this) 
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;

        if (deltaTime >= refreshTime)
        {
            refreshTime = Random.Range(refreshTimeRange.x, refreshTimeRange.y);
            deltaTime = 0;

            InstantiateEnnemy();
        }
    }

    private void InstantiateEnnemy()
    {
        float orthoSizeY = Camera.main.orthographicSize;
        float orthoSizeX = Camera.main.orthographicSize * 16f / 9f;
        Vector3 position = new Vector3(Random.Range(-orthoSizeX, orthoSizeX), Random.Range(-orthoSizeY, orthoSizeY));

        Instantiate(ennemyPrefab.gameObject, position, Quaternion.identity);
    }
}
