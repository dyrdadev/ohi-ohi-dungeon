using System;
using UnityEngine;

[RequireComponent(typeof(Sensor))]
public class DamageEffect : MonoBehaviour
{
    private Life _life;
    private Sensor damageCause;

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