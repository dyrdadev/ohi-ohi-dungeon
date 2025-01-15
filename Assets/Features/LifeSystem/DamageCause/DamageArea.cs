using UnityEngine;

public class DamageArea : DamageCause
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageEffect = other.GetComponent<DamageEffect>();
        if (damageEffect)
        {
            damageEffect.Trigger(this);
        }
    }
}