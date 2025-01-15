using System;
using R3;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinAnimationController animationController;
    public Sensor collectSensor;
    public int value = 1;

    private void Start()
    {
        collectSensor.SensorTriggered.Subscribe(CollectSignalDetected).AddTo(this);
    }

    private void Awake()
    {
        animationController.PlaySpawnAnimation();
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