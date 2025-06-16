using UnityEngine;
using UnityEngine.AI;

public abstract class ADrone : AUnit
{
    [field: SerializeField] protected NavMeshAgent agent { get; private set; }
    [SerializeField] private LineRenderer lineRenderer;
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
    public void DebugPath(bool value)
    {
        if (value && agent.hasPath)
        {
            lineRenderer.positionCount = agent.path.corners.Length;
            lineRenderer.SetPositions(agent.path.corners);
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
    }
}
