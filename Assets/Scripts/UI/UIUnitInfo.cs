using TMPro;
using UnityEngine;

public class UIUnitInfo : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI textComponent;

    private SelectionManager selectionManager;
    public void Init() 
    {
        panel.SetActive(false);
        selectionManager = FindObjectOfType<SelectionManager>();
        selectionManager.onSelect.AddListener(OnSelect);
        selectionManager.onDeselect.AddListener(OnDeselect);
    }
    private void OnSelect(AUnit unit)
    {
        panel.SetActive(true);
        unit.onStateChanged.AddListener(UpdateText);
        UpdateText(unit);
    }
    private void OnDeselect(AUnit unit)
    {
        panel.SetActive(false);
        unit.onStateChanged.RemoveListener(UpdateText);
        UpdateText(unit);
    }
    private void UpdateText(AUnit unit)
    {
        string faction = unit.Faction.Name;
        string type = unit.GetType().Name;
        string status = GetStatus(unit.State);
        textComponent.text = $"Фракция: {faction}\tТип: {type}\t Статус: {status}";
    }
    private string GetStatus(UnitState state)
    {
        switch (state)
        {
            case UnitState.Searching:
                return "В поиске ресурсов";
            case UnitState.Working:
                return "Добывает ресурсы";
            case UnitState.Returning:
                return "Несет ресурсы";
            default:
                return "АДЫХАЕМ";
        }
    }
}
