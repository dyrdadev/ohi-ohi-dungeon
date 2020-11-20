using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Life))]
public class Hero : MonoBehaviour
{
    private Life _life;

    private void OnEnable()
    {
        _life = GetComponent<Life>();
        _life.Defeated += PlayerDefeated;
    }
    
    private void OnDisable()
    {
        _life.Defeated -= PlayerDefeated;
    }
    
    public void PlayerDefeated(object sender, EventArgs args)
    {
        SceneLoader.LoadGameOver();
    }
}
