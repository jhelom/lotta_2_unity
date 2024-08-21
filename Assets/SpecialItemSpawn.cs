using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemSpawn : MonoBehaviour
{
    public float spawnInterval = 1.0f;
    private GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        prefab = (GameObject)Resources.Load("SpecialItem");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        if (Game.IsActive)
        {
            var item = Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
