using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIScorePanel scorePanel;
    [SerializeField] private UIDebugPanel debugPanel;
    [SerializeField] private UIUnitInfo unitInfo;

    public void Init(BaseStation[] stations)
    {
        scorePanel.Init(stations);
        debugPanel.Init();
        unitInfo.Init();
    }
}
