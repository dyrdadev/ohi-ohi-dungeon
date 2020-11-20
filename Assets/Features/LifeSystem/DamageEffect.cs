using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Sensor))]
public class DamageEffect : MonoBehaviour
{
    private Sensor damageCause;
    private Life _life;

    private void OnEnable()
    {
        _life = GetComponentInParent<Life>();
        
        damageCause = GetComponent<Sensor>();
        damageCause.SensorTriggered += DamageCauseSignalDetected;
    }
    
    private void OnDisable()
    {
        damageCause.SensorTriggered -= DamageCauseSignalDetected;
    }
    
    public void DamageCauseSignalDetected(object sender, EventArgs args)
    {
        _life.DealDamage(1.0f);
    }
}