using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public float spawnInterval = 1.0f;

    private GameObject prefab;
    void Start()
    {
        prefab = Resources.Load("GoldItem") as GameObject;
        // InvokeRepeating(nameof(SpawnBall), 0, spawnInterval);
        StartCoroutine(RepeatAction());
    }


    void Update()
    {

    }

    IEnumerator RepeatAction()
    {
        while (true)
        {
            // 一定間隔待機
            yield return new WaitForSeconds(spawnInterval);

            // 実行する処理
            var item = Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
