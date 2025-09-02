using UnityEngine;

public class DefaultSpawner : MonoBehaviour
{
    [Header("DefaultSettings")] [SerializeField]
    private Animal animal;
    
    private void Start()
    {
        Animal spawnAnimal = Instantiate(animal, transform.position, Quaternion.identity);
        spawnAnimal.Riding(Player.Instance);
        spawnAnimal.AnimalController.ChangeState<AnimalRunStateBase>();
    }
}
