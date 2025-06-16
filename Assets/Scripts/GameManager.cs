using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private BaseStation[] stations;

    private void Start()
    {
        for (int i = 0; i < stations.Length; i++)
        {
            stations[i].Init();
        }

        uiManager.Init(stations);
    }
}
