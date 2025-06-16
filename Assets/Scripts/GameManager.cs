using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private BaseStation[] stations;
    [SerializeField] private FloatEventChannelSO gameSpeedEventSO;

    private void Start()
    {
        gameSpeedEventSO.OnRaised += ChangeGameSpeed;

        for (int i = 0; i < stations.Length; i++)
        {
            stations[i].Init();
        }

        uiManager.Init(stations);
    }

    private void ChangeGameSpeed(float speed)
    {
        Time.timeScale = speed;
    }
}
