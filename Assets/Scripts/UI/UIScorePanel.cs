using System.Collections.Generic;
using UnityEngine;

public class UIScorePanel : MonoBehaviour
{
    [SerializeField] private UIScoreItem scorePrefab;
    [SerializeField] private Transform container;

    private Dictionary<string, UIScoreItem> items = new Dictionary<string, UIScoreItem>();
    public void Init(BaseStation[] stations)
    {
        for (int i = 0; i < stations.Length; i++)
        {
            var score = Instantiate(scorePrefab, container);
            score.Set($"Team {stations[i].Faction.Name}: 0");
            items.Add(stations[i].Faction.Name, score);
            stations[i].onScoreChanged.AddListener(OnScoreChanged);
        }
    }

    private void OnScoreChanged(Faction faction, int score)
    {
        if (items.TryGetValue(faction.Name, out UIScoreItem item))
        {
            item.Set($"Team {faction.Name}: {score}");
        }
    }
}
