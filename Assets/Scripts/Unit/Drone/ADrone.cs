using UnityEngine;
using UnityEngine.AI;

public abstract class ADrone : AUnit
{
    [field: SerializeField] protected NavMeshAgent agent { get; private set; }
    protected BaseStation station { get; private set; }
    public abstract void SetTarget(ITargetable target);
    public void SetStation(BaseStation station)
    {
        this.station = station;
    }
    public void SetSpeed(float value)
    {
        agent.speed = value;
    }
}
