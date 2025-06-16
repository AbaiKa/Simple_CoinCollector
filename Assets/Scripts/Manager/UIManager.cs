using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIScorePanel scorePanel;
    [SerializeField] private UIDebugPanel debugPanel;

    public void Init(BaseStation[] stations)
    {
        scorePanel.Init(stations);
        debugPanel.Init();
    }
}
