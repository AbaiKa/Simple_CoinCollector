using UnityEngine;

public class ResourcesDroneManager : MonoBehaviour
{
    [SerializeField]
    private ResourceDrone dronePrefab;

    private BaseStation station;

    public void Init(BaseStation station)
    {
        this.station = station;
    }
}
