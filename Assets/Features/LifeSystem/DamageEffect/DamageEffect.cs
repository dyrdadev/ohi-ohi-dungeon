using System;
using R3;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    private Life _life;

    private void Start()
    {
        _life = GetComponentInParent<Life>();
    }
    
    public void Trigger(DamageCause damageCause)
    {
        _life.DealDamage(damageCause.damage);
    }
}