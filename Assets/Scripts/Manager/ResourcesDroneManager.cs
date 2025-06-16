using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesDroneManager : MonoBehaviour
{
    [SerializeField]
    private ResourceDrone dronePrefab;
    [SerializeField]
    private Transform target;

    private void Start()
    {
        dronePrefab.SetTarget(target);
    }
    private void Update()
    {
        dronePrefab.Tick();
    }
}
