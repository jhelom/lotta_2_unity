using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI text;
    public PlayerType playerType = PlayerType.Red;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateDisplay());
    }

    IEnumerator UpdateDisplay()
    {
        while (true)
        {
            var player = Game.GetPlayer(playerType);
            text.text = player.name + "\n" + player.score.ToString();
            yield return new WaitForSeconds(0.2f);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
