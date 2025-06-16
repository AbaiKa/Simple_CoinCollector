using UnityEngine;

public class ResourceDrone : ADrone
{
    public override void Init()
    {
        
    }
    public override void DeInit()
    {
        
    }

    public override void Tick()
    {
        if (target != null)
        {
            agent.SetDestination(target.GetTransform().position);
        }
    }
}
