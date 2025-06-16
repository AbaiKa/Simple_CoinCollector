using UnityEngine;
using UnityEngine.AI;

public abstract class ADrone : AUnit
{
    [field: SerializeField] protected NavMeshAgent agent { get; private set; }
    protected Transform target {  get; private set; }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
