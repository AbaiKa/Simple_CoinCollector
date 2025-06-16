using System.Collections.Generic;
using UnityEngine;

public class ResourcesDroneManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    private IntEventChannelSO dronesCountEventSO;
    [SerializeField]
    private FloatEventChannelSO dronesSpeedEventSO;
    [SerializeField]
    private BoolEventChannelSO dronesPathEventSO;
    [SerializeField]
    private ResourceDrone dronePrefab;

    private BaseStation station;
    private bool debugPath;

    private List<ResourceDrone> drones = new List<ResourceDrone>();

    public void Init(BaseStation station)
    {
        this.station = station;
        dronesCountEventSO.onRaised += OnDronesCountChanged;
        dronesSpeedEventSO.onRaised += OnDronesSpeedChanged;
        dronesPathEventSO.onRaised += OnDronesPathChanged;
    }
    private void Update()
    {
        DebugPath(debugPath);
    }
    private void OnDronesCountChanged(int value)
    {
        value = Mathf.Max(1, value);

        int currentCount = drones.Count;

        if (value > currentCount)
        {
            int toAdd = value - currentCount;
            for (int i = 0; i < toAdd; i++)
            {
                Vector2 offset2D = Random.insideUnitCircle * 1.5f;
                Vector3 offset = new Vector3(offset2D.x, 0, offset2D.y);
                Vector3 spawnPosition = station.transform.position + offset;

                var drone = Instantiate(dronePrefab, spawnPosition, Quaternion.identity);
                drone.Init();
                drone.SetStation(station);
                drone.SetFaction(station.Faction);
                drones.Add(drone);
            }
        }
        else if (value < currentCount)
        {
            int toRemove = currentCount - value;
            for (int i = 0; i < toRemove; i++)
            {
                var last = drones[drones.Count - 1];
                drones.RemoveAt(drones.Count - 1);
                last.DeInit();
            }
        }
    }
    private void OnDronesSpeedChanged(float value)
    {
        for (int i = 0; i < drones.Count; i++)
        {
            drones[i].SetSpeed(value);
        }
    }
    private void OnDronesPathChanged(bool value)
    {
        debugPath = value;
    }
    private void DebugPath(bool value)
    {
        for (int i = 0; i < drones.Count; i++)
        {
            drones[i].DebugPath(value);
        }
    }
}
