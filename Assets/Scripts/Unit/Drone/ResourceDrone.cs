using UnityEngine;

public class ResourceDrone : ADrone
{
    public override void Tick()
    {
        if(target != null)
        agent.SetDestination(target.position);
    }
}
