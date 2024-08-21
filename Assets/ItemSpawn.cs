using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public float spawnInterval = 1.0f;

    private GameObject goldItem;
    private GameObject motionItem;
    private GameObject fashionItem;
    void Start()
    {
        goldItem = Resources.Load("GoldItem") as GameObject;
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

            if (Game.IsActive)
            {
                var item = Instantiate(goldItem, transform.position, Quaternion.identity);
            }
        }
    }
}
