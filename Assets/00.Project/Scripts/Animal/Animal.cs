using UnityEngine;

public class Animal : MonoBehaviour
{
    public AnimalController AnimalController { get; private set; }

    [Header("Rinding Transform")]
    [SerializeField] private Vector3 ridingOffset;

    private void Awake()
    {
        AnimalController = GetComponent<AnimalController>();
    }
    
    public void Riding(Player player)
    {
        AnimalController.ChangeState<AnimalRunStateBase>();
        player.transform.parent = transform;
        player.transform.localPosition = ridingOffset;
    }

    public void Dismounting(Player player)
    {
        AnimalController.ChangeState<AnimalAutoStateBase>();
        player.transform.parent = GameManager.Instance.transform;
    }
}
