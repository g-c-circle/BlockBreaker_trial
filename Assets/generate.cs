using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate : MonoBehaviour
{
    public GameObject ballPrefab;
    public float spawnInterval = 2.0f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnBall();
            timer = 0.0f;
        }
    }

    void SpawnBall()
    {
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }
}
