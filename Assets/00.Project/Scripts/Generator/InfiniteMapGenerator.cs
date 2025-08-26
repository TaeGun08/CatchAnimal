using System.Collections.Generic;
using UnityEngine;

public class InfiniteMapGenerator : MonoBehaviour
{
    [Header("Map Settings")] 
    [SerializeField] private Transform target;
    [SerializeField] private GameObject[] mapPrefabs;
    [SerializeField] private float segmentLength = 100f;  
    [SerializeField] private int segmentCount = 3;

    private Queue<GameObject> segmentPool = new Queue<GameObject>();
    private float nextSpawnZ;

    private void Start()
    {
        for (int i = 0; i < segmentCount; i++)
        {
            SpawnInitialSegment();
        }
    }

    private void Update()
    {
        if (segmentPool.Count == 0) return;

        GameObject firstSegment = segmentPool.Peek();
        float halfLengthZ = firstSegment.transform.position.z + segmentLength / 2f;
        
        if (target.position.z > halfLengthZ + halfLengthZ * 0.25f)
        {
            RecycleSegment();
        }
    }

    private void SpawnInitialSegment()
    {
        GameObject prefab = mapPrefabs[Random.Range(0, mapPrefabs.Length)];
        GameObject segment = Instantiate(prefab, new Vector3(0, 0, nextSpawnZ), Quaternion.identity, transform);
        segmentPool.Enqueue(segment);
        nextSpawnZ += segmentLength;
    }

    private void RecycleSegment()
    {
        GameObject segment = segmentPool.Dequeue();  
        segment.transform.position = new Vector3(0, 0, nextSpawnZ);  
        segmentPool.Enqueue(segment);
        nextSpawnZ += segmentLength;   
    }
}