using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public CoinAnimationController animationController;

    private void Awake()
    {
        animationController.PlaySpawnAnimation();
    }

    public void Collect()
    {
        GameData.Instance.IncreaseScore(value);
        animationController.PlayCollectedAnimation();
        Destroy(this.gameObject, 3.0f);
    }

}