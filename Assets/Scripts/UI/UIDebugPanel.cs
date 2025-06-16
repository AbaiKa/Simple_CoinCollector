using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameSpeedText;
    [SerializeField] private Slider gameSpeedSlider;
    [SerializeField] private TextMeshProUGUI dronesCountText;
    [SerializeField] private Slider dronesCountSlider;
    [SerializeField] private TextMeshProUGUI dronesSpeedText;
    [SerializeField] private Slider dronesSpeedSlider;
    [SerializeField] private TMP_InputField resourcesSpeedIF;
    [SerializeField] private Toggle dronesPathToggle;

    public void Init()
    {
        
    }
}
