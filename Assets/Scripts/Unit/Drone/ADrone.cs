using UnityEngine;
using UnityEngine.AI;

public abstract class ADrone : AUnit
{
    [field: SerializeField] protected NavMeshAgent agent { get; private set; }
    protected BaseStation station { get; private set; }
    protected ITargetable target {  get; private set; }
    public void SetStation(BaseStation station)
    {
        this.station = station;
    }
    public void SetTarget(ITargetable target)
    {
        this.target = target;
    }
    public void SetSpeed(float value)
    {
        agent.speed = value;
    }
}
