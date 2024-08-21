#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public static GameMain? Instance
    {
        get;
        private set;
    }

    void Start()
    {
        Instance = this;
        Game.Start();
        StartCoroutine(TimeCount());
    }

    void Update()
    { }
    private IEnumerator TimeCount()
    {
        while (Game.time > 0)
        {
            Game.CountDown();
            yield return new WaitForSeconds(1f);
        }
    }
}