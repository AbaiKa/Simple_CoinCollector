using UnityEngine;

public class BaseStation : MonoBehaviour
{
    [field: Header("Properties")]
    [field: SerializeField] public Faction Faction { get; private set; }

    [Header("Components")]
    [SerializeField] private MeshRenderer meshRenderer;

    [Header("Managers")]
    [SerializeField] private ResourcesDroneManager resourcesDroneManager;

    public void Init()
    {
        meshRenderer.material.color = new Color(Faction.Color.r, Faction.Color.g, Faction.Color.b, 0.5f);
        resourcesDroneManager.Init(this);
    }
}