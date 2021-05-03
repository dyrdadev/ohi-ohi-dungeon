using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(Sensor))]
public class DamageEffect : MonoBehaviour
{
    private Life _life;
    private Sensor damageCause;
    public float damage = 1.0f;

    private void Start()
    {
        _life = GetComponentInParent<Life>();

        damageCause = GetComponent<Sensor>();
    }

    public void DamageCauseSignalDetected(EventArgs args)
    {
        _life.DealDamage(damage);
    }
}