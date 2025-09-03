using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("ObstacleSettings")]
    [SerializeField] private Transform[] spawnTrs;
    [SerializeField] private Obstacle[] obstacles;
    private List<GameObject> obj = new List<GameObject>();

    public void SpawnObstacle()
    {
        int randomSpawn = Random.Range(1, 4);
        Reset();
        for (int i = 0; i < randomSpawn; i++)
        {
            int randomObstacle = Random.Range(0, obstacles.Length);
            obj.Add(Instantiate(obstacles[randomObstacle], RandomTransform(), Quaternion.identity, transform).gameObject);
        }
    }

    private Vector3 RandomTransform()
    {
        while (true)
        {
            int random = Random.Range(0, spawnTrs.Length);
            if (spawnTrs[random].gameObject.activeSelf == false) continue;
            spawnTrs[random].gameObject.SetActive(false);
            return spawnTrs[random].position;
        }
    }

    private void Reset()
    {
        foreach (var trs in spawnTrs)
        {
            if (trs.gameObject.activeSelf == false) continue;
            trs.gameObject.SetActive(true);
        }

        foreach (var ob in obj)
        {
            Destroy(ob);
        }
        obj.Clear();
    }
}
