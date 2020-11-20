using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ThemingGameObjectSwitch : MonoBehaviour
{
    public GameObject demonsThemeInstance;
    public GameObject undeadsThemeInstance;
    public GameObject orcsThemeInstance;

    private void Start()
    {
        demonsThemeInstance.SetActive(GameData.Instance.currentLevelTheme == GameData.LevelTheme.Demons);
        undeadsThemeInstance.SetActive(GameData.Instance.currentLevelTheme == GameData.LevelTheme.Undeads);
        orcsThemeInstance.SetActive(GameData.Instance.currentLevelTheme == GameData.LevelTheme.Orcs);
    }

}
