using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinAnimationController animationController;
    public int value = 1;

    private void Awake()
    {
        animationController.PlaySpawnAnimation();
    }

    public void Collect()
    {
        GameData.Instance.IncreaseScore(value);
        animationController.PlayCollectedAnimation();
        Destroy(gameObject, 3.0f);
    }
}