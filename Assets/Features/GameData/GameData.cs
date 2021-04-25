using System;
using UnityEngine;
using DyrdaDev.Singleton;
using UniRx;
using Random = System.Random;

public class GameData : SingletonMonoBehaviour<GameData>
{
    public enum LevelTheme
    {
        Demons,
        Undeads,
        Orcs
    }
    
    [HideInInspector] public LevelTheme currentLevelTheme;
    private Random LevelThemeRandom = new Random();
    
    public int score;

    public void Awake()
    {
        currentLevelTheme = GetRandomLevelTheme();
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }

    public void ResetScore()
    {
        score = 0;
    }


    private void GetNextLevelTheme()
    {
        var previousLevelTheme = currentLevelTheme;
        var newLevelTheme = currentLevelTheme;
        
        while (previousLevelTheme == newLevelTheme)
        {
            newLevelTheme = GetRandomLevelTheme();
        }

        currentLevelTheme = newLevelTheme;
    }


    public void Reset()
    {
        ResetScore();
        GetNextLevelTheme();
    }

    private LevelTheme GetRandomLevelTheme()
    {
        Array values = Enum.GetValues(typeof(LevelTheme));
        return (LevelTheme)values.GetValue(LevelThemeRandom.Next(values.Length));
    }
}