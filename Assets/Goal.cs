using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Goal : MonoBehaviour
{
    [SerializeField]
    public GamePlayerType playerType = GamePlayerType.Red;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "GoldItem")
        {
            if (playerType == GamePlayerType.Red)
            {
                Game.redPlayer.score += 1;
            }
            else
            {
                Game.bluePlayer.score += 1;
            }
        }
    }
}
