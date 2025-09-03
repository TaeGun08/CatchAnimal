using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    
    [Header("ObstacleSettings")] [SerializeField]
    private int obstacleWeight;
    public int ObstacleWeight => obstacleWeight;

    public abstract void Interact();
}
