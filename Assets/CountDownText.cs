using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownText : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateDisplay());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator UpdateDisplay()
    {
        while (true)
        {
            var minutes = Mathf.FloorToInt(Game.time / 60).ToString("00");
            var seconds = Mathf.FloorToInt(Game.time % 60).ToString("00");
            text.text = $"Wave {Game.wave}\n{minutes}:{seconds}";
            yield return new WaitForSeconds(1.0f);
        }
    }
}
