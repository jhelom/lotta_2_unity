using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
public class BallSpawn : MonoBehaviour
{
    public PlayerType playerType = PlayerType.Red;

    /// <summary>
    /// 上下に移動する範囲
    /// </summary>
    public float upDownRange = 1.0f;

    /// <summary>
    /// 上下に移動する速度
    /// </summary>
    public float upDownSpeed = 1.0f; // 移動速度

    private float upDownStartY;

    /// <summary>
    /// 回転の最小値
    /// </summary>
    public float rotationMin = 30.0f;

    /// <summary>
    /// 回転の最大値
    /// </summary>
    public float rotationMax = 90.0f;

    /// <summary>
    /// 回転の速度
    /// </summary>
    public float rotationSpeed = 1.0f;

    /// <summary>
    /// 弾の発射間隔
    /// </summary>
    public float shootInterval = 0.1f;

    /// <summary>
    /// 一度に発射する弾の数
    /// </summary>
    public int shootCount = 1;

    /// <summary>
    /// 弾の速度
    /// </summary>

    public int shootSpeed = 10;


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
            if (Game.IsActive)
            {
                for (var i = 0; i < shootCount; i++)
                {
                    SpawnBall();
                }
            }
        }
    }

    private void UpDown()
    {
        var y = upDownStartY + upDownRange * Mathf.Cos(Time.time * upDownSpeed);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    private void Rotate()
    {
        // 時間に基づいてCosの値を計算
        var cosValue = Mathf.Cos(Time.time * rotationSpeed);

        // Cosの値を0から1の範囲に変換
        var t = (cosValue + 1) / 2;

        // 角度の補間
        var angle = Mathf.Lerp(rotationMin, rotationMax, t);

        // Z軸周りの回転を適用
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
    private void SpawnBall()
    {
        var ball = BallPool.Instance.Get();
        ball.transform.position = transform.position;
        ball.GetComponent<Renderer>().material.color = playerType == PlayerType.Red ? Game.COLOR_RED : Game.COLOR_BLUE;
        var rb = ball.GetComponent<Rigidbody2D>();
        var r = Random.Range(0.8f, 1.2f);
        rb.velocity = transform.right * (shootSpeed * r);
    }
}