using UnityEngine;

public class Player : SingletonBehaviour<Player>, IObstacleCollision
{
    private Animator animator;
    private Rigidbody rigidbody;
    
    public bool IsRiding { get; set; }

    protected virtual void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
    
    public void ChangeAnimation(string animation)
    {
        animator.SetTrigger(animation);
    }

    public void Riding(Animal animal)
    {
        rigidbody.isKinematic = true;
        animal.AnimalController.ChangeState<AnimalRunState>();
        transform.parent = animal.transform;
        transform.localPosition = animal.RidingOffset;
        IsRiding = true;
    }

    public void Dismount(AnimalController animalController)
    {
        rigidbody.isKinematic = false;
        animalController.ChangeState<AnimalAutoState>();
        transform.parent = GameManager.Instance.transform;
        IsRiding = false;
    }

    public void HitObstacle()
    {
        
    }
}
