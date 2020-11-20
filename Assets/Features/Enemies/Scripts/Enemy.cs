using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Life))]
public class Enemy : MonoBehaviour
{
    private Life _life;

    private void OnEnable()
    {
        _life = GetComponent<Life>();
        _life.Defeated += EnemyDefeated;
    }
    
    private void OnDisable()
    {
        _life.Defeated -= EnemyDefeated;
    }
    
    public void EnemyDefeated(object sender, EventArgs args)
    {
        Destroy(this.gameObject);
    }
}