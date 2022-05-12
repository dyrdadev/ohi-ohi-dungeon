using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreLabel : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();

        SetLabelText(GameData.Instance.score);
    }

    private void SetLabelText(int score)
    {
        _text.text = ""+score;
    }
}