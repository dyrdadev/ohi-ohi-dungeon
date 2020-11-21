using UnityEngine;
using DyrdaIo.Singleton;

public class GameData : SingletonMonoBehaviour<GameData>
{
    public enum LevelTheme
    {
        Demons,
        Undeads,
        Orcs
    }

    [HideInInspector] public LevelTheme currentLevelTheme;

    public int score;

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