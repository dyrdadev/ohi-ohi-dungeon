using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataRestater : MonoBehaviour
{
    private void Awake()
    {
        GameData.Instance.Reset();
    }
}
