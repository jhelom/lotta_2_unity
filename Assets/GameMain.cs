using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    void Start()
    {
        Game.Start();
        StartCoroutine(TimeCount());
    }

    void Update()
    { }
    private IEnumerator TimeCount()
    {
        while (Game.time > 0)
        {
            yield return new WaitForSeconds(1f);
            Game.CountDown();
        }
    }
}