using UnityEngine;

public class Resource : MonoBehaviour, ITargetable
{
    public bool IsReserved { get; private set; }

    private AUnit reservedBy;

    public Transform GetTransform() => transform;
    public bool TryReserve(AUnit unit)
    {
        if (reservedBy == null)
        {
            reservedBy = unit;
            return true;
        }
        return false;
    }
    public void Release(AUnit unit)
    {
        if (reservedBy == unit)
        {
            reservedBy = null;
            Destroy(gameObject);
        }
    }
}
