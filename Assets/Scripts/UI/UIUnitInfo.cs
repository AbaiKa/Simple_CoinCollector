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
        textComponent.text = $"�������: {faction}\t���: {type}\t ������: {status}";
    }
    private string GetStatus(UnitState state)
    {
        switch (state)
        {
            case UnitState.Searching:
                return "� ������ ��������";
            case UnitState.Working:
                return "�������� �������";
            case UnitState.Returning:
                return "����� �������";
            default:
                return "�������";
        }
    }
}
