using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    public static GamePlayer bluePlayer = new GamePlayer();
    public static GamePlayer redPlayer = new GamePlayer();

    public static void Start()
    {
        bluePlayer = new GamePlayer();
        redPlayer = new GamePlayer();
    }

    public static void CountDown()
    {

    }
}




