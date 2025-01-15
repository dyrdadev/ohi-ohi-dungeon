using UnityEngine;

public class GameDataRestater : MonoBehaviour
{
    private void Awake()
    {
        GameData.Instance.Reset();
    }
}