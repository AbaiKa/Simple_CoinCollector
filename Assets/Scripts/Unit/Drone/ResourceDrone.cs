using UnityEngine;

public class ResourceDrone : ADrone
{
    private Resource target;
    public override void SetTarget(ITargetable target)
    {
        this.target = target as Resource;
    }
    public override void Init()
    {
        
    }
    public override void DeInit()
    {
        if (target != null)
        {
            target.Release(this);
        }
        Destroy(gameObject);
    }

    public override void Tick()
    {
        if (target != null)
        {
            agent.SetDestination(target.GetTransform().position);
        }
    }
}
