using UnityEngine;
using UnityEngine.Events;

public class Resource : MonoBehaviour, ITargetable
{
    public bool IsReserved { get; private set; }
    public AUnit ReservedBy {  get; private set; }

    public UnityEvent<Resource> onDeInit = new UnityEvent<Resource>();

    public Transform GetTransform()
    {
        return transform;
    }
    public bool TryReserve(AUnit unit)
    {
        if (ReservedBy == null)
        {
            IsReserved = true;
            ReservedBy = unit;
            return true;
        }
        return false;
    }
    public void Release(AUnit reserver)
    {
        if (ReservedBy == reserver)
        {
            IsReserved = false;
            ReservedBy = null;
        }
    }
    public void DeInit()
    {
        onDeInit?.Invoke(this);
        Destroy(gameObject);
    }
}
