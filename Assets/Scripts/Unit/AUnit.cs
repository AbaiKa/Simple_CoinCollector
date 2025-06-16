using UnityEngine;
using UnityEngine.Events;

public abstract class AUnit : MonoBehaviour, ISelectable
{
    public UnitState State { get; private set; }
    public UnityEvent<UnitState> onStateChanged = new UnityEvent<UnitState>();

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
        onStateChanged?.Invoke(State);
    }
}