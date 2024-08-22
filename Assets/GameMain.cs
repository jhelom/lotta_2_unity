#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GameMain : MonoBehaviour
{

    public static GameMain? Instance
    {
        get;
        private set;
    }

    void Start()
    {
        Application.targetFrameRate = 24;
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