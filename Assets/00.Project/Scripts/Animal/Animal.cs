using UnityEngine;

public class Animal : MonoBehaviour, IObstacleCollision
{
    public AnimalController AnimalController { get; private set; }
    
    [Header("Rinding Transform")]
    [SerializeField] private Vector3 ridingOffset;
    public Vector3 RidingOffset => ridingOffset;

    private void Awake()
    {
        AnimalController = GetComponent<AnimalController>();
    }

    public void HitObstacle()
    {
        if (Player.Instance.IsRiding == false) return;
        AnimalController.ChangeState<AnimalDeadState>();
    }
}
