using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
public class BallSpawn : MonoBehaviour
{
    public float upDownAmplitude = 1.0f; // 振幅（上下の移動距離）
    public float upDownSpeed = 1.0f; // 移動速度

    private float upDownStartY;
    public float rotationMin = 30.0f;
    public float rotationMax = 90.0f;
    public float shootInterval = 0.1f;

    public int shootCount = 1;


    public int shootSpeed = 10;

    public float rotationSpeed = 1.0f;

    private GameObject prefab;

    void Start()
    {
        prefab = Resources.Load("Ball") as GameObject;
        upDownStartY = transform.position.y;
        StartCoroutine(RepeatAction());
    }


    void Update()
    {
        Rotate();
        UpDown();
    }

    IEnumerator RepeatAction()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            for (var i = 0; i < shootCount; i++)
            {
                SpawnBall(i);
            }
        }
    }

    private void UpDown()
    {
        var y = upDownStartY + upDownAmplitude * Mathf.Cos(Time.time * upDownSpeed);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    private void Rotate()
    {
        // 時間に基づいてCosの値を計算
        float cosValue = Mathf.Cos(Time.time * rotationSpeed);

        // Cosの値を0から1の範囲に変換
        float t = (cosValue + 1) / 2;

        // 角度の補間
        float angle = Mathf.Lerp(rotationMin, rotationMax, t);

        // Z軸周りの回転を適用
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
    private void SpawnBall(int i)
    {
        var pos = new Vector2(transform.position.x, transform.position.y);
        var ball = Instantiate(prefab, pos, transform.rotation);
        var rb = ball.GetComponent<Rigidbody2D>();
        var r = i == 0 ? 1 : Random.Range(0.5f, 1.5f);
        rb.velocity = transform.right * (shootSpeed * r);
    }
}