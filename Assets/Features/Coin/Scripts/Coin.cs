using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public Sensor collectSensor;
    public CoinAnimationController animationController;

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
        Destroy(this.gameObject, 3.0f);
    }

}