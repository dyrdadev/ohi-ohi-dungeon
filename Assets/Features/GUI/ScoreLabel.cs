using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreLabel : MonoBehaviour
{
    private Text _text;

    private void Start()
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
        _text.text = "" + score;
    }
}