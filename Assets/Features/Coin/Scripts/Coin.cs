using System;
using UniRx;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinAnimationController animationController;
    public Sensor collectSensor;
    public int value = 1;

    private void Awake()
    {
        animationController.PlaySpawnAnimation();
    }
    
    private void Start()
    {
    }

    public void CollectSignalDetected(EventArgs args)
    {
        Collect();

        // Deactivate sensor.
        collectSensor.gameObject.SetActive(false);
    }

    public void Collect()
    {
        GameData.Instance.IncreaseScore(value);
        animationController.PlayCollectedAnimation();
        Destroy(gameObject, 3.0f);
    }
}