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
    }



    private void SetScore(int score)
    {
        _text.text = ""+score;
    }
}