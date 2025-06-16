using UnityEngine;
using UnityEngine.Events;

public abstract class AUnit : MonoBehaviour, ISelectable
{
    public UnitState State { get; private set; }
    public Faction Faction { get; private set; }

    public UnityEvent<AUnit> onStateChanged = new UnityEvent<AUnit>();

    public abstract void Init();
    public abstract void DeInit();

    public virtual void OnSelect()
    {
        Debug.Log($"������ ������: {gameObject.name}");
    }
    public virtual void OnDeselect()
    {
        Debug.Log($"������: {gameObject.name} ���� � ������");
    }

    public void SetState(UnitState state)
    {
        State = state;
        onStateChanged?.Invoke(this);
    }
    public void SetFaction(Faction faction)
    {
        Faction = faction;
    }
}