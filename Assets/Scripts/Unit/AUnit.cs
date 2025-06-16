using UnityEngine;

public abstract class AUnit : MonoBehaviour, ISelectable
{
    public abstract void Tick();

    public virtual void OnSelect()
    {
        Debug.Log($"Выбран объект: {gameObject.name}");
    }
    public virtual void OnDeselect()
    {
        Debug.Log($"Объект: {gameObject.name} снят с выбора");
    }
}
