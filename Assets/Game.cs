using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public static class Game
{
    const string SCENE_MAIN = "MainScene";

    const int COUNTDOWN_TIME_SECONDS = 60 * 1;
    public static readonly Color32 COLOR_RED = new Color32(255, 0, 192, 255);
    public static readonly Color32 COLOR_BLUE = new Color32(0, 192, 255, 255);
    public static GamePlayer bluePlayer = new();
    public static GamePlayer redPlayer = new();

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
        IsActive = false;
    }


    public static void CountDown()
    {
        time = Mathf.Max(0, time - 1);
    }
}




