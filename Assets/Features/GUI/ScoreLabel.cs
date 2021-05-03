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
        
    }
    
    private void SetScore(int score)
    {
        _text.text = ""+score;
    }
}