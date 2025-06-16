using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    [SerializeField] private IntEventChannelSO spawnSpeedEventSO;
    [SerializeField] private Transform fieldTransform;
    [SerializeField] private Vector2 fieldSize = new Vector2(5f, 2f);
    [SerializeField] private Resource resourcePrefab;

    private float spawnInterval;
    private Coroutine spawnRoutine;
    private List<Resource> resources = new List<Resource>();
    public void Init()
    {
        spawnSpeedEventSO.onRaised += SetSpawnSpeed;
    }
    public bool TryGetNearest(Vector3 point, out Resource nearest)
    {
        nearest = null;
        float minDistanceSqr = Mathf.Infinity;

        var freeResources = resources.Where(r => !r.IsReserved);

        foreach (var resource in freeResources)
        {
            float distSqr = (resource.transform.position - point).sqrMagnitude;
            if (distSqr < minDistanceSqr)
            {
                minDistanceSqr = distSqr;
                nearest = resource;
            }
        }

        return nearest != null;
    }

    private void SetSpawnSpeed(int amountInMinutes)
    {
        spawnInterval = 60 / (float)Mathf.Max(1, amountInMinutes);

        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
        }
        spawnRoutine = StartCoroutine(SpawnRoutine());
    }
    private IEnumerator SpawnRoutine()
    {
        var interval = new WaitForSeconds(spawnInterval);
        while (true)
        {
            yield return interval;
            var pos = GetRandomPoint();
            Resource resource = Instantiate(resourcePrefab, pos, Quaternion.identity);
            resource.onDeInit.AddListener(OnDeInit);
            resources.Add(resource);
        }
    }
    private void OnDeInit(Resource resource)
    {
        resources.Remove(resource);
    }
    private Vector3 GetRandomPoint()
    {
        float halfX = fieldSize.x / 2f;
        float halfZ = fieldSize.y / 2f;

        float randomX = Random.Range(-halfX, halfX);
        float randomZ = Random.Range(-halfZ, halfZ);

        Vector3 center = fieldTransform.position;
        return new Vector3(center.x + randomX, center.y, center.z + randomZ);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = fieldTransform.position;
        Vector3 size = new Vector3(fieldSize.x, 0.1f, fieldSize.y);
        Gizmos.DrawWireCube(center, size);
    }
}
