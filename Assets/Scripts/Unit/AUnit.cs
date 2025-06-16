using UnityEngine;

public abstract class AUnit : MonoBehaviour, ISelectable
{
    public abstract void Init();
    public abstract void Tick();
    public abstract void DeInit();

    public virtual void OnSelect()
    {
        Debug.Log($"������ ������: {gameObject.name}");
    }
    public virtual void OnDeselect()
    {
        Debug.Log($"������: {gameObject.name} ���� � ������");
    }
}
