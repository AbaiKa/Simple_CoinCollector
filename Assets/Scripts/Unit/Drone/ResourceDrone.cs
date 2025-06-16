using UnityEngine;

public class ResourceDrone : ADrone
{
    [SerializeField] private float workTime;
    [SerializeField] private GameObject effectPrefab;

    private ResourcesManager resourcesManager;

    private Resource target;
    private float elapsedTime = 0;
    public override void Init()
    {
        //TODO: DI or Services
        resourcesManager = FindObjectOfType<ResourcesManager>();
        SetState(UnitState.Idle);
    }
    public override void DeInit()
    {
        if (target != null)
        {
            target.Release(this);
        }
        Destroy(gameObject);
    }
    public override void SetTarget(ITargetable target)
    {
        this.target = target as Resource;

        if (this.target != null)
        {
            agent.SetDestination(target.GetTransform().position);
        }
    }
    private void Update()
    {
        if (State == UnitState.Idle || State == UnitState.Searching)
        {
            Searching();
        }
        else
        {
            if (State == UnitState.Working)
            {
                Working();
            }
            else if(State == UnitState.Returning)
            {
                if (HasReachedDestination())
                {
                    station.Deposit(1);
                    SetState(UnitState.Searching);
                    Instantiate(effectPrefab, transform.position, Quaternion.identity);
                }
            }
        }
    }
    private void Searching()
    {
        if (target != null)
        {
            if (HasReachedDestination())
            {
                if (target.TryReserve(this))
                {
                    SetState(UnitState.Working);
                }
                else
                {
                    target = null;
                    agent.ResetPath();
                    SetState(UnitState.Idle);
                }
            }
        }
        else
        {
            if (resourcesManager.TryGetNearest(transform.position, out Resource target))
            {
                SetState(UnitState.Searching);
                SetTarget(target);
            }
        }
    }
    private void Working()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= workTime)
        {
            Returning();
            SetState(UnitState.Returning);
            target.DeInit();
            target = null;
            elapsedTime = 0;
        }
    }
    private void Returning()
    {
        Vector2 offset2D = Random.insideUnitCircle * 1.5f;
        Vector3 offset = new Vector3(offset2D.x, 0, offset2D.y);
        Vector3 stationPosition = station.transform.position + offset;
        agent.SetDestination(stationPosition);
    }
}
