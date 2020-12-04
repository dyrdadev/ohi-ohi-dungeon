using System;
using UnityEngine;
using DyrdaIo.Singleton;
using UniRx;

public class GameData : SingletonMonoBehaviour<GameData>
{
    public enum LevelTheme
    {
        Demons,
        Undeads,
        Orcs
    }

    public ReactiveProperty<int> score = new ReactiveProperty<int>(0);
   
    [HideInInspector] public LevelTheme currentLevelTheme;
    

    public void IncreaseScore(int value)
    {
        score.Value += value;
    }

    public void ResetScore()
    {
        score.Value = 0;
    }


    private void GetNextLevelTheme()
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