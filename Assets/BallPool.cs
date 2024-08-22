using UnityEngine;
using UnityEngine.Pool;

public class BallPool
{
    public static BallPool Instance
    {
        get;
    } = new();

    private readonly ObjectPool<GameObject> pool;
    private GameObject prefab;
    private BallPool()
    {
        prefab = (GameObject)Resources.Load("Ball");

        pool = new(
            OnCreate,
            OnTake,
            OnReturn,
            OnDestroy,
            false,
            100,
            100);
    }

    private GameObject OnCreate()
    {
        return Object.Instantiate(prefab);
    }

    private void OnTake(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void OnReturn(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy(GameObject gameObject)
    {
        Object.Destroy(gameObject);
    }

    public GameObject Get()
    {
        return pool.Get();
    }

    public void Release(GameObject gameObject)
    {
        pool.Release(gameObject);
    }
}
