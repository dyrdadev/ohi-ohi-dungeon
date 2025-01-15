using UnityEngine;
using UnityEngine.UI;
using R3;

[RequireComponent(typeof(Image))]
public class AbilityIcon : MonoBehaviour
{
    private Image icon;

    [SerializeField] private float onCooldownAlpha = 100;

    private void Start()
    {
        icon = GetComponent<Image>();

        GameData.Instance.abilityAvailable
            .Subscribe(value => SetIcon(value))
            .AddTo(this);
    }

    private void SetIcon(bool value)
    {
        Color c = icon.color;
        c.a = value ? 1 : onCooldownAlpha / 255;
        icon.color = c;
    }
}
