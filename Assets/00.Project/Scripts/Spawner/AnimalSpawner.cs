using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalSpawner : MonoBehaviour
{
    private Player player;

    [Header("Animals")] [SerializeField] private Animal[] animals;

    private void Start()
    {
        player = Player.Instance;
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            float randomSpawn = Random.Range(3f, 6f);
            float randomPosX = Random.Range(-6f, 6f);

            Instantiate(animals[Random.Range(0, animals.Length)],
                new Vector3(randomPosX, 0f, player.transform.position.z + 50f), Quaternion.identity, transform);

            yield return new WaitForSeconds(randomSpawn);
        }
    }
}