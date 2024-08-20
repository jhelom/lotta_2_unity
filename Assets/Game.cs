using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public static class Game
{
    const int COUNTDOWN_TIME_SECONDS = 60 * 5;
    public static GamePlayer bluePlayer = new GamePlayer();
    public static GamePlayer redPlayer = new GamePlayer();

    public static float time = 0;
    public static int wave = 0;
    public static void Start()
    {
        redPlayer = new GamePlayer()
        {
            name = "Lotta"
        };

        bluePlayer = new GamePlayer()
        {
            name = "Niia"
        };

        time = COUNTDOWN_TIME_SECONDS;
        wave++;
    }

    public static void End()
    {

    }

    public static void CountDown()
    {
        time = Mathf.Max(0, time - 1);
    }
}




