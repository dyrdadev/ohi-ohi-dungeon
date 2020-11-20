using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class GameData : SingletonMonoBehaviour<GameData>
{
    public int score;

    public void IncreaseScore(int value)
    {
        score += value;
    }
    
    public void ResetScore()
    {
        score = 0;
    }

    public enum LevelTheme
    {
        Demons,
        Undeads,
        Orcs
    }
    [HideInInspector]
    public LevelTheme currentLevelTheme;
    
    void GetNextLevelTheme()
    {
        //Array values = Enum.GetValues(typeof(LevelTheme));
        //Random random = new Random();
        //currentLevelTheme = (LevelTheme)values.GetValue(random.Next(values.Length));
        currentLevelTheme = LevelTheme.Demons; // Currently only demons is implemented.
    }

    public void Reset()
    {
        ResetScore();
        GetNextLevelTheme();
    }
}
