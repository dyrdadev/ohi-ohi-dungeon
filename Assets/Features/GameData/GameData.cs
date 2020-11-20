using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class GameData : SingletonMonoBehaviour<GameData>
{
    public class ScoreUpdatedEventArgs : EventArgs
    {
        public int value;

        public ScoreUpdatedEventArgs(int value)
        {
            this.value = value;
        }
    }
    public event EventHandler<ScoreUpdatedEventArgs> ScoreUpdated;
    protected virtual void OnScoreUpdated(ScoreUpdatedEventArgs eventArgs)
    {
        EventHandler<ScoreUpdatedEventArgs> handler = ScoreUpdated;
        handler?.Invoke(this, eventArgs);
    }
    
    private int _score;
    public int score
    {
        get => _score;
        set
        {
            _score = value;
            
            OnScoreUpdated(new ScoreUpdatedEventArgs(_score));
        }
    }
    
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
