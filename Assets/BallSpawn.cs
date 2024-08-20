using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class BallSpawn : MonoBehaviour
{
    private readonly float spawnInterval = 1.0f;
    private int r = 0;
    private GameObject prefab;
    void Start()
    {
        prefab = Resources.Load("Ball") as GameObject;
        InvokeRepeating(nameof(SpawnBall), 0, spawnInterval);
    }


    void Update()
    {

    }

    private void SpawnBall()
    {
        r = (r + 15) % 360;
        // 発射方向を計算
        var rotation = Quaternion.Euler(0, 0, r);
        var shootDirection = rotation * Vector2.right;
        var ball = Instantiate(prefab, transform.position, Quaternion.identity);
        var rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * 10.0f;
    }
}
