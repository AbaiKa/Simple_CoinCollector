using TMPro;
using UnityEngine;

public class UIScoreItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    public void Set(string text)
    {
        textComponent.text = text;
    }
}
