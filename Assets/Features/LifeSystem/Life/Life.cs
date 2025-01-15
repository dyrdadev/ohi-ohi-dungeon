using System;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private float _life = 1.0f;

    public float life
    {
        get => _life;
        set
        {
            _life = value;
            if (_life <= 0)
            {
                Defeat();
            }
        }
    }

    public event EventHandler Defeated;

    protected virtual void OnDefeated()
    {
        var handler = Defeated;
        handler?.Invoke(this, EventArgs.Empty);
    }

    public void DealDamage(float damage)
    {
        life -= damage;
    }

    public void Defeat()
    {
        OnDefeated();
    }
}