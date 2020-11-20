using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public GameObject[] loot;
    private Life _life;

    private void OnEnable()
    {
        if (TryGetComponent<Life>(out _life) == false)
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
            Instantiate(lootObject, this.transform.position, Quaternion.identity);
        }
    }
}
