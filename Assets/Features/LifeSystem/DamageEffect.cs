using System;
using UniRx;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    private Life _life;
    public float damage = 1.0f;

    private void Start()
    {
        _life = GetComponentInParent<Life>();
    }

    public void DamageCauseSignalDetected(object sender, EventArgs args)
    {
        _life.DealDamage(damage);
    }
}