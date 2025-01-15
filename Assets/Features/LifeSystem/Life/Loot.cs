using System;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private Life _life;
    public GameObject[] loot;

    private void OnEnable()
    {
        if (TryGetComponent(out _life) == false)
        {
            _life = GetComponentInParent<Life>();
        }

        _life.Defeated += OnDefeatedSignalDetected;
    }

    private void OnDisable()
    {
        _life.Defeated -= OnDefeatedSignalDetected;
    }


    public void OnDefeatedSignalDetected(object sender, EventArgs args)
    {
        // Spawn loot.
        foreach (var lootObject in loot)
        {
            Instantiate(lootObject, transform.position, Quaternion.identity);
        }
    }
}