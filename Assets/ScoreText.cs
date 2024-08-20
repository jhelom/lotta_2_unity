using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GamePlayerType playerType = GamePlayerType.Red;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateScore());
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (playerType == GamePlayerType.Red)
            {
                text.text = Game.redPlayer.score.ToString();
            }
            else
            {
                text.text = Game.bluePlayer.score.ToString();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
