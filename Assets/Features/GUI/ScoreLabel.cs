using UnityEngine;
using UnityEngine.UI;
using UniRx;

[RequireComponent(typeof(Text))]
public class ScoreLabel : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();

        SetScore(GameData.Instance.score.Value);
        GameData.Instance.score
            .Subscribe(score => SetScore(score))
            .AddTo(this);
    }



    private void SetScore(int score)
    {
        _text.text = ""+score;
    }
}