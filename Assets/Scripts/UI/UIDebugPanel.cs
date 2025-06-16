using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugPanel : MonoBehaviour
{
    [Header("Game speed")]
    [SerializeField] private TextMeshProUGUI gameSpeedText;
    [SerializeField] private Slider gameSpeedSlider;
    [SerializeField] private FloatEventChannelSO gameSpeedEventSO;
    [Header("Drones count")]
    [SerializeField] private TextMeshProUGUI dronesCountText;
    [SerializeField] private Slider dronesCountSlider;
    [SerializeField] private IntEventChannelSO dronesCountEventSO;
    [Header("Drones speed")]
    [SerializeField] private TextMeshProUGUI dronesSpeedText;
    [SerializeField] private Slider dronesSpeedSlider;
    [SerializeField] private FloatEventChannelSO dronesSpeedEventSO;
    [Header("Resources speed")]
    [SerializeField] private TMP_InputField resourcesSpeedIF;
    [SerializeField] private IntEventChannelSO resourcesSpeedEventSO;
    [Header("Drones path")]
    [SerializeField] private Toggle dronesPathToggle;
    [SerializeField] private BoolEventChannelSO dronesPathEventSO;

    public void Init()
    {
        gameSpeedSlider.onValueChanged.AddListener(OnGameSpeedChanged);
        dronesCountSlider.onValueChanged.AddListener(OnDronesCountChanged);
        dronesSpeedSlider.onValueChanged.AddListener(OnDronesSpeedChanged);
        resourcesSpeedIF.onValueChanged.AddListener(OnResourcesSpeedChanged);
        dronesPathToggle.onValueChanged.AddListener(OnDronesPathChanged);
    }
    public void SetProperties(GameSettingsSO settings)
    {
        gameSpeedSlider.value = settings.GameSpeed;
        dronesCountSlider.value = settings.DronesCount;
        dronesSpeedSlider.value = settings.DronesSpeed;
        resourcesSpeedIF.text = settings.ResourcesSpeed.ToString();
        dronesPathToggle.isOn = settings.ShowDronesPath;
        OnDronesPathChanged(settings.ShowDronesPath);
    }

    private void OnGameSpeedChanged(float value)
    {
        float speed = MathF.Round(value, 1);
        gameSpeedEventSO.RaiseEvent(speed);
        gameSpeedText.text = $"Скорость игры: {speed}";
    }
    private void OnDronesCountChanged(float value)
    {
        int count = Mathf.RoundToInt(value);
        dronesCountEventSO.RaiseEvent(count);
        dronesCountText.text = $"Количество дронов: {count}";
    }
    private void OnDronesSpeedChanged(float value)
    {
        float speed = MathF.Round(value, 1);
        dronesSpeedEventSO.RaiseEvent(speed);
        dronesSpeedText.text = $"Скорость дронов: {speed}";
    }
    private void OnResourcesSpeedChanged(string newValue)
    {
        if (int.TryParse(newValue, out int speed))
        {
            resourcesSpeedEventSO.RaiseEvent(speed);
        }
    }
    private void OnDronesPathChanged(bool value)
    {
        dronesPathEventSO.RaiseEvent(value);
    }
}
