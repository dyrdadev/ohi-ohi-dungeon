using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreLabel : MonoBehaviour
{
    private Text _text;
    public bool withPrefix = true;
    void Start()
    {
        _text = GetComponent<Text>();

        SetScore(GameData.Instance.score);
        GameData.Instance.ScoreUpdated += ScoreChanged;
    }

    private void OnDisable()
    {
        GameData.Instance.ScoreUpdated -= ScoreChanged;
    }

    private void ScoreChanged(object sender, GameData.ScoreUpdatedEventArgs args)
    {
        SetScore(args.value);
    }
    
    private void SetScore(int score)
    {
        _text.text = $"{(withPrefix?"Score ":"")}"+score;
    }
}
