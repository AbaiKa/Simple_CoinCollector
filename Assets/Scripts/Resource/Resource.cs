using UnityEngine;

public class Resource : MonoBehaviour, ITargetable
{
    public bool IsReserved { get; private set; }
    public AUnit ReservedBy {  get; private set; }

    public Transform GetTransform() => transform;
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
        Destroy(gameObject);
    }
}
