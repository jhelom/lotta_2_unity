#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public static class Game
{
    const string SCENE_MAIN = "MainScene";

    const int COUNTDOWN_TIME_SECONDS = 60 * 10;
    const int SPECIAL_ITEM_TIME_SECONDS = 30;
    const int SHOOT_COUNT_MIN = 1;
    const int SHOOT_COUNT_MAX = 10;

    const float SHOOT_INTERVAL_MIN = 0.1f;
    const float SHOOT_INTERVAL_MAX = 1.0f;

    public static readonly Color32 COLOR_RED = new(255, 0, 192, 255);
    public static readonly Color32 COLOR_BLUE = new(0, 192, 255, 255);
    public static Player bluePlayer = new();
    public static Player redPlayer = new();

    public static float time
    {
        get;
        private set;
    } = 0.0f;

    public static int wave
    {
        get;
        private set;
    } = 0;

    public static bool IsActive
    {
        get;
        private set;
    } = false;

    public static void Start()
    {
        IsActive = true;

        redPlayer = new Player()
        {
            name = "Lotta"
        };

        bluePlayer = new Player()
        {
            name = "Niia"
        };

        time = COUNTDOWN_TIME_SECONDS;
        wave++;
    }

    public static void End()
    {
        IsActive = false;
    }


    public static void CountDown()
    {
        time = Mathf.Max(0, time - 1);

        if (time == 0)
        {
            End();
        }

        Console.WriteLine("END");
    }

    public static Player GetPlayer(PlayerType playerType)
    {
        return playerType == PlayerType.Red ? redPlayer : bluePlayer;
    }

}




