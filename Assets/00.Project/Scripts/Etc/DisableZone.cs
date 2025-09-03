using UnityEngine;

public class DisableZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            AnimalController animalController = other.GetComponent<AnimalController>();
            animalController.ChangeState<AnimalAutoState>();
            gameObject.SetActive(false);
        }
    }
}
