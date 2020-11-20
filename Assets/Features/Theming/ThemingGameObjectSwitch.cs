using UnityEngine;

public class ThemingGameObjectSwitch : MonoBehaviour
{
    public GameObject demonsThemeInstance;
    public GameObject orcsThemeInstance;
    public GameObject undeadsThemeInstance;

    private void Start()
    {
        demonsThemeInstance.SetActive(GameData.Instance.currentLevelTheme == GameData.LevelTheme.Demons);
        undeadsThemeInstance.SetActive(GameData.Instance.currentLevelTheme == GameData.LevelTheme.Undeads);
        orcsThemeInstance.SetActive(GameData.Instance.currentLevelTheme == GameData.LevelTheme.Orcs);
    }
}