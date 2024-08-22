using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public float spawnInterval = 1.0f;

    void Start()
    {
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
                var item = GoldItemPool.Instance.Get();
                item.transform.position = transform.position;
                item.transform.rotation = Quaternion.identity;
            }
        }
    }
}
