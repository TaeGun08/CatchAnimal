using System;
using UnityEngine;

public class ObstacleInteract : MonoBehaviour
{
    private IObstacleCollision obstacleCollision;

    private void Awake()
    {
        obstacleCollision = GetComponent<IObstacleCollision>();
    }

    [Header("ObstacleSize")]
    [SerializeField] private int obstacleWeight;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                if (obstacle.ObstacleWeight <= obstacleWeight)
                {
                    obstacle.Interact();
                    obstacle.gameObject.SetActive(false);
                }
                else
                {
                    obstacleCollision.HitObstacle();
                }
            }
        }
    }
}
