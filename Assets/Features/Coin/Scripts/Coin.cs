using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinAnimationController animationController;
    public Sensor collectSensor;
    public int value = 1;

    private void OnEnable()
    {
        collectSensor.SensorTriggered += CollectSignalDetected;
    }

    private void OnDisable()
    {
        collectSensor.SensorTriggered -= CollectSignalDetected;
    }

    private void Awake()
    {
        animationController.PlaySpawnAnimation();
    }

    public void CollectSignalDetected(object sender, EventArgs args)
    {
        Collect();

        // Deactivate sensor.
        collectSensor.gameObject.SetActive(false);
    }

    public void Collect()
    {
        GameData.Instance.IncreaseScore(value);
        collectSensor.SensorTriggered -= CollectSignalDetected;
        animationController.PlayCollectedAnimation();
        Destroy(gameObject, 3.0f);
    }
}