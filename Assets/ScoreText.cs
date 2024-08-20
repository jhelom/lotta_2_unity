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
        StartCoroutine(UpdateDisplay());
    }

    IEnumerator UpdateDisplay()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (playerType == GamePlayerType.Red)
            {
                text.text = Game.redPlayer.name + "\n" + Game.redPlayer.score.ToString();
            }
            else
            {
                text.text = Game.bluePlayer.name + "\n" + Game.bluePlayer.score.ToString();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
