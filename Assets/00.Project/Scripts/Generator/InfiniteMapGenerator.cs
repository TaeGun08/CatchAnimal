using System.Collections.Generic;
using UnityEngine;

public class InfiniteMapGenerator : MonoBehaviour
{
    private Transform target;
    
    [Header("Map Settings")] 
    [SerializeField] private GameObject[] mapPrefabs;
    [SerializeField] private float segmentLength;  
    [SerializeField] private int segmentCount;

    private Queue<GameObject> segmentPool = new Queue<GameObject>();
    private float nextSpawnZ;

    private void Start()
    {
        target = Player.Instance.transform;
        
        for (int i = 0; i < segmentCount; i++)
        {
            SpawnInitialSegment();
        }
    }

    private void Update()
    {
        if (segmentPool.Count == 0) return;

        GameObject firstSegment = segmentPool.Peek();
        float halfLengthZ = firstSegment.transform.position.z + segmentLength;
        
        if (target.position.z > halfLengthZ)
        {
            RecycleSegment();
        }
    }

    private void SpawnInitialSegment()
    {
        GameObject prefab = mapPrefabs[Random.Range(0, mapPrefabs.Length)];
        GameObject segment = Instantiate(prefab, new Vector3(0, 0, nextSpawnZ), Quaternion.identity, transform);
        segment.GetComponent<ObstacleSpawner>().SpawnObstacle();
        segmentPool.Enqueue(segment);
        nextSpawnZ += segmentLength;
    }

    private void RecycleSegment()
    {
        GameObject segment = segmentPool.Dequeue();  
        segment.transform.position = new Vector3(0, 0, nextSpawnZ);  
        segment.GetComponent<ObstacleSpawner>().SpawnObstacle();
        segmentPool.Enqueue(segment);
        nextSpawnZ += segmentLength;   
    }
}