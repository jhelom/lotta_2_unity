using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
public class BallSpawn : MonoBehaviour
{
    public float minAngle = 30.0f;
    public float maxAngle = 90.0f;
    public float spawnInterval = 0.1f;


    public int shootSpeed = 10;

    public float rotationSpeed = 1.0f;

    private GameObject prefab;

    void Start()
    {
        prefab = Resources.Load("Ball") as GameObject;
        StartCoroutine(RepeatAction());
    }


    void Update()
    {
        Rotate();
    }

    IEnumerator RepeatAction()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnBall();
        }
    }

    private void Rotate()
    {
        // 時間に基づいてCosの値を計算
        float cosValue = Mathf.Cos(Time.time * rotationSpeed);

        // Cosの値を0から1の範囲に変換
        float t = (cosValue + 1) / 2;

        // 角度の補間
        float angle = Mathf.Lerp(minAngle, maxAngle, t);

        // Z軸周りの回転を適用
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
    private void SpawnBall()
    {

        // 発射方向を計算
        // var rotation = Quaternion.Euler(0, 0, transform.rotation.z);
        // var shootDirection = rotation * Vector2.right;
        var pos = new Vector2(transform.position.x, transform.position.y);
        var ball = Instantiate(prefab, pos, transform.rotation);
        var rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * shootSpeed;
    }
}
