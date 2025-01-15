using UnityEngine;
using UnityEngine.UI;
using R3;

[RequireComponent(typeof(Text))]
public class ScoreLabel : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();

        SetLabelText(GameData.Instance.score.Value);
        GameData.Instance.score
            .Subscribe(score => SetLabelText(score))
            .AddTo(this);
    }



    private void SetLabelText(int score)
    {
        _text.text = ""+score;
    }
}