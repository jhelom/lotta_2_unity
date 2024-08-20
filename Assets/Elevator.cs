using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private float screenTop;
    private float screenBottom;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトを下方向に移動
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // 画面下端を超えたら、画面上端に移動
        if (transform.position.y < screenBottom)
        {
            transform.position = new Vector2(transform.position.x, screenTop);
        }
    }
}
