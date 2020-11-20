using System;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    private Life _life;

    private void OnEnable()
    {
        _life = GetComponentInParent<Life>();
    }

    public void DamageCauseSignalDetected(object sender, EventArgs args)
    {
        _life.DealDamage(1.0f);
    }
}