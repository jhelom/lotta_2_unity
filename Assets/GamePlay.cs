using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(nameof(TimeCount));
    }

    void Update()
    { }
    private IEnumerator TimeCount()
    {
        yield return new WaitForSeconds(1f);
    }
}