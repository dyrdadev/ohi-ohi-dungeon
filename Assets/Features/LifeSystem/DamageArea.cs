using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public float damage = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var life = other.GetComponent<Life>();
        if (life)
        {
            life.DealDamage(damage);
        }
    }
}