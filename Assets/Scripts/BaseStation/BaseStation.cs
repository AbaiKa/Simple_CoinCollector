using UnityEngine;
using UnityEngine.Events;

public class BaseStation : MonoBehaviour
{
    [field: Header("Properties")]
    [field: SerializeField] public Faction Faction { get; private set; }

    [Header("Components")]
    [SerializeField] private MeshRenderer meshRenderer;

    [Header("Managers")]
    [SerializeField] private ResourcesDroneManager resourcesDroneManager;

    public UnityEvent<Faction, int> onScoreChanged = new UnityEvent<Faction, int>();

    private int score;

    public void Init()
    {
        score = 0;
        meshRenderer.material.color = new Color(Faction.Color.r, Faction.Color.g, Faction.Color.b, 0.5f);
        resourcesDroneManager.Init(this);
    }

    public void Deposit(int amount)
    {
        score += amount;
        onScoreChanged?.Invoke(Faction, score);
    }
}