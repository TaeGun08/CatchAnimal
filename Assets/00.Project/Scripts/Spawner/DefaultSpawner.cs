using UnityEngine;

public class DefaultSpawner : MonoBehaviour
{
    [Header("DefaultSettings")] [SerializeField]
    private Animal animal;
    
    private void Start()
    {
        Instantiate(animal, transform.position, Quaternion.identity).Riding(Player.Instance);
    }
}
